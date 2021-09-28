using BAL.IServices;
using DAL.Encriptado;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
   public class UsuariosRepository : IUsuariosRepository, IDisposable
    {
        //VARIABLE QUE ALMACENA CLASE OBJETO
        private readonly Contexto contexto;
        //CONSTRUCTOR
        public UsuariosRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }
        
        //IMPLEMENTACIÓN DE MÉTODOS

        //LISTAR USUARIOS
        public List<tabUsuarios> listaUsuarios()
        {
            var usuarios = contexto.tabUsuarios.ToList();
            return (usuarios);
        }
        //OBTENER USUARIO POR ID
        public tabUsuarios ObtenenerUsuarioPorId(int idUsuario)
        {
            var usuario = contexto.tabUsuarios.FirstOrDefault(x => x.idUsuario == idUsuario);
            return usuario;
        }
        //CREAR O EDITAR USUARIOS
        public bool CrearOEditarUsuario(tabUsuarios usuarios)
        {
            bool success;
            try
            {
                usuarios.pass = EncriptarPassword.EncriptarPass(usuarios.pass);
                if (usuarios.idUsuario > 0)
                {
                    contexto.Entry(usuarios).State = EntityState.Modified;

                }
                else
                {
                    contexto.Entry(usuarios).State = EntityState.Added;
                    
                }
                contexto.SaveChanges();
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }
        //ELIMINAR USUARIO
        public void EliminarUsuario(int idUsuario)
        {
            var usuario = ObtenenerUsuarioPorId(idUsuario);
            if (usuario != null)
            {
                contexto.Entry(usuario).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
