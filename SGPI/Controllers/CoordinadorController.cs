using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGPI.Controllers
{
    public class CoordinadorController : Controller
    {
        SGPDBContext context;

        public CoordinadorController(SGPDBContext contexto)
        {
            context = contexto;
        }

        // GET: CoordinadorController
        public ActionResult MenuCoordinador()
        {
            return View();
        }

        // GET: CoordinadorController/Details/5
        public IActionResult ConsultarEstudiante()
        {
            //Usuario user = new Usuario();
            ViewBag.programas = context.Programas.ToList();
            var listaUsuarios = context.Usuarios.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            foreach (var user in listaUsuarios)
            {
                if (user.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (user.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }
            }
            ViewBag.programa = listaprogramas;
            return View(listaUsuarios);
        }

        [HttpPost]
        public IActionResult ConsultarEstudiante(Usuario user,string documento)
        {
            var listaEstudiantes = context.Usuarios.Where(u => u.Documento.Contains(documento) && 
            u.IdRol==3 && u.IdPrograma==user.IdPrograma).ToList();
            ViewBag.programas = context.Programas.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            foreach (var estudiante in listaEstudiantes)
            {
                if (user.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (estudiante.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }
            }
            ViewBag.programa = listaprogramas;
            if (listaEstudiantes != null)
            {
                return View(listaEstudiantes);
            }
            else
            {
                return View();
            }
        }

        // GET: CoordinadorController/Create
        public ActionResult ProgramarAsignatura()
        {
            var listaAsignaturas = context.Programacions.ToList();
            ViewBag.programas = context.Programas.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            List<string> listaInicio = new List<string>();
            List<string> listaFin = new List<string>();
            foreach (var asignatura in listaAsignaturas)
            {
                if (asignatura.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (asignatura.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                            if (asignatura.FechaIncio != null && asignatura.FechaFin != null)
                            {
                                var fechaInicio = asignatura.FechaIncio.ToString();
                                var fechaFin = asignatura.FechaFin.ToString();
                                var fecha = fechaInicio.Split(" ");
                                listaInicio.Add(fecha[0]);
                                fecha = fechaFin.Split(" ");
                                listaFin.Add(fecha[0]);
                                //fechaInicio = "";
                                //fechaFin = "";
                            }
                            else
                            {
                                listaInicio.Add("No fecha");
                                listaFin.Add("No fecha");
                            }
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }
            }
            ViewBag.programa = listaprogramas;
            ViewBag.fechaInicio = listaInicio;
            ViewBag.fechaFin = listaFin;
            if (listaAsignaturas != null)
            {
                return View(listaAsignaturas);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult ProgramarAsignatura(Programacion program,DateTime FInicio)
        {
            var listaAsignaturas = context.Programacions.Where(p => p.IdPrograma == program.IdPrograma &&
            p.FechaIncio == FInicio).ToList();
            ViewBag.programas = context.Programas.ToList();
            var listaprogram = context.Programas.ToList();
            List<string> listaprogramas = new List<string>();
            List<string> listaInicio = new List<string>();
            List<string> listaFin = new List<string>();
            foreach (var asignatura in listaAsignaturas)
            {
                if (asignatura.IdPrograma != null)
                {
                    foreach (var programa in listaprogram)
                    {
                        if (asignatura.IdPrograma == programa.IdPrograma)
                        {
                            listaprogramas.Add(programa.ValPrograma);
                            if (asignatura.FechaIncio != null && asignatura.FechaFin != null)
                            {
                                var fechaInicio = asignatura.FechaIncio.ToString();
                                var fechaFin = asignatura.FechaFin.ToString();
                                var fecha = fechaInicio.Split(" ");
                                listaInicio.Add(fecha[0]);
                                fecha = fechaFin.Split(" ");
                                listaFin.Add(fecha[0]);
                            }
                            else
                            {
                                listaInicio.Add("No fecha");
                                listaFin.Add("No fecha");
                            }
                        }
                    }
                }
                else
                {
                    listaprogramas.Add("no programa");
                }
            }
            ViewBag.programa = listaprogramas;
            ViewBag.fechaInicio = listaInicio;
            ViewBag.fechaFin = listaFin;
            if (listaAsignaturas != null)
            {
                return View(listaAsignaturas);
            }
            else
            {
                return View();
            }
        }

        // GET: CoordinadorController/Create
        public ActionResult Homologar()
        {
            return View();
        }

        // GET: CoordinadorController/Create
        public ActionResult EntrevistaAdmicion(int id)
        {
            ViewBag.tipodoc = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            var listaUsuarios = context.Usuarios.Where(u => u.IdUsuario == id).ToList();
            if (listaUsuarios != null)
            {
                return View(listaUsuarios.SingleOrDefault());
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult EntrevistaAdmicion(DateTime fecha,string estado,bool check,int id)
        {
            var entrevista = new Entrevistum();
            entrevista.Estado = estado;
            entrevista.FechaEntrevista = fecha;
            entrevista.IdUsuario = id;
            context.Add(entrevista);
            context.SaveChanges();
            ViewBag.tipodoc = context.Documentos.ToList();
            ViewBag.programa = context.Programas.ToList();
            ViewBag.rol = context.Rols.ToList();
            ViewBag.genero = context.Generos.ToList();
            return RedirectToAction("MenuCoordinador");
        }

        // GET: CoordinadorController/Create
        public ActionResult Anadir()
        {
            ViewBag.programas = context.Programas.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Anadir(Programacion program)
        {
            var id = context.Programacions.ToList();
            int cont = id.Count();
            cont++;
            program.IdProgramacion = cont;
            context.Add(program);
            context.SaveChanges();
            ViewBag.programas = context.Programas.ToList();
            return RedirectToAction("Anadir");
        }
    }
}
