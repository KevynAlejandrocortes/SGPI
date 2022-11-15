using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SGPI.Controllers
{
    public class LoginController : Controller
    {
        SGPDBContext context;

        public LoginController(SGPDBContext contexto)
        {
            context = contexto;
        }

        // GET: LoginController
        public ActionResult Login()
        {
            bool mensaje = false;
            return View(mensaje);
        }

        [HttpPost]
        public ActionResult Login(string documento,string contracena)
        {
            var usuario = context.Usuarios.Where(u => u.Documento == documento && u.Contraseña == contracena).ToList();
            try
            {
                if (usuario[0].IdRol == 1)
                {
                    return Redirect("/Administrador/MenuAdministrador");
                }
                else if (usuario[0].IdRol == 2)
                {
                    return Redirect("/Coordinador/MenuCoordinador");
                }
                else if (usuario[0].IdRol == 3)
                {
                    return Redirect("/Estudiante/MenuEstudiante");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception e)
            {
                return View();
            }
            
        }

        // GET: LoginController/Details/5
        public ActionResult OlvidoContracena()
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
