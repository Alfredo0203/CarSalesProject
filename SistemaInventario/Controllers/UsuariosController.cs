﻿using BAL.IServices;
using BAL.Services;
using DAL.Seguridad;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    [Admin]
    public class UsuariosController : Controller
    { 
       private IUsuariosRepository usuariosRepository;

    //Constructor
    public UsuariosController()
    {
        this.usuariosRepository = new UsuariosRepository(new Contexto());
    }

    //Método para mostrar usuarios
    public ActionResult MostrarUsuarios()
    {
        var usuarios = usuariosRepository.listaUsuarios();
        return View(usuarios);
    }

    //EDITAR USUARIO
    public ActionResult EditarOCrearUsuarios(int idUsuario = 0)
    {
        var usuarios = new tabUsuarios();

        if (idUsuario > 0)
        {
            usuarios = usuariosRepository.ObtenenerUsuarioPorId(idUsuario);
        }
        return View(usuarios);
    }

    [HttpPost]
    //AGREGAR USUARIO
    public ActionResult EditarOCrearUsuarios(tabUsuarios usuarios)
    {
            if (usuariosRepository.ExisteDato(usuarios.correo))
            {
                ModelState.AddModelError("CorreoExiste", "Este correo ya está en uso");
            }
            if (ModelState.IsValid)
        {
            var creado = usuariosRepository.CrearOEditarUsuario(usuarios);
                if (creado)
            {
                return RedirectToAction("MostrarUsuarios");
            }
        }
        return View(usuarios);
    }

        //ELIMINAR USUARIO
        public ActionResult EliminarUsuario(int idUsuario = 0, bool success = false)
    {
            if(idUsuario > 0 && success == true)
        usuariosRepository.EliminarUsuario(idUsuario);
        return RedirectToAction("MostrarUsuarios");
    }
}
}