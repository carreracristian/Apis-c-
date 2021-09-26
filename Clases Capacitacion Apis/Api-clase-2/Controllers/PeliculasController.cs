using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_clase_2.Models;

namespace Api_clase_2.Controllers
{
    public class PeliculasController : ControllerBase
    {
        [HttpGet]
        [Route("api/peliculas")]
        public IActionResult Get()
        {
            var peliculas = Peliculas.getAll();
            return Ok(peliculas);
        }
        [HttpGet]
        [Route("api/peliculas/{id}")]
        public IActionResult GetById(int id)
        {
            var pelicula = Peliculas.getById(id);
            return Ok(pelicula);
        }
        [HttpPost]
        [Route("api/peliculas")]
        public IActionResult Create(Pelicula model)
        {
            //return Ok("Se cargo pelicula con Titulo: "+model.Titulo+" y Genero: "+model.Genero);
            //Pelicula peli =  Peliculas.createNew(model);
            return Ok(model);

        }
    }
}
