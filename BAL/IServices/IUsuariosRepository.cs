using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    interface IUsuariosRepository : IDisposable
    {
        //MÉTODO LISTAR USUARIOS
        List<tabUsuarios> listaUsuarios();
        //CREAR O EDITAR USUARIOS
        bool CrearOEditarUsuario(tabUsuarios usuarios);
        //OBTENER USUARIO POR ID
        tabUsuarios ObtenenerUsuarioPorId(int idUsuario);
        //ELIMINAR USUARIO
        void EliminarUsuario(int idUsuario);
    }
}
