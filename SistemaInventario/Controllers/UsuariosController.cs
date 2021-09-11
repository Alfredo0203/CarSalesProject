﻿using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class UsuariosController : Controller
    { 
       private IUsuariosRepository usuariosRepository;

    //Constructor
    public UsuariosController()
    {
        this.usuariosRepository = new UsuariosRepository(new Contexto());
    }

    //Método para mostrar proveedores
    public ActionResult MostrarUsuarios()
    {
        var usuarios = usuariosRepository.listaUsuarios();
        return View(usuarios);
    }

    //EDITAR PROVEEDORES
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
    //AGREGAR PROVEEDOR
    public ActionResult EditarOCrearUsuarios(tabUsuarios usuarios)
    {
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

    //ELIMINAR PROVEEDOR
    public ActionResult EliminarUsuario(int idUsuario)
    {
        usuariosRepository.EliminarUsuario(idUsuario);
        return RedirectToAction("MostrarUsuarios");
    }
}
}