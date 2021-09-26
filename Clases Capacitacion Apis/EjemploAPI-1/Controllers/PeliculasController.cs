using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace EjemploAPI_1.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok("Ok al getById "+Id);
        }
        [HttpGet("{YearFrom}/{YearTo}")]
        public IActionResult GetByYear(string YearFrom, string YearTo)
        {
            return Ok("Ok al getByYar ");
        }
        [HttpGet]
        public IActionResult Get()
        {
            ArrayList lista = new ArrayList();

            MySqlConnection miConeccion = new MySqlConnection();
            miConeccion.ConnectionString = "cadena de conexion a la db";
            bool SePudoAbrir = true;

            try
            {
                miConeccion.Open();
            }
            catch (SystemException error)
            {
                SePudoAbrir = false;
                Console.WriteLine("Se pudrio todo: " + error.Message);
            }
            if (SePudoAbrir)
            {
                MySqlCommand miComando = new MySqlCommand();
                miComando.CommandType = System.Data.CommandType.Text;
                miComando.CommandText = "Select id, titulo, genero from peliculas";
                miComando.Connection = miConeccion;

                DataTable miTabla = new DataTable();
                MySqlDataAdapter miAdaptador = new MySqlDataAdapter();
                miAdaptador.SelectCommand = miComando;

                bool sePudoLeer = true;
                try
                {
                    miAdaptador.Fill(miTabla);

                }
                catch (SystemException error)
                {
                    SePudoAbrir = false;
                    Console.WriteLine("Se pudrio todo: " + error.Message);
                }
                if (sePudoLeer)
                {
                    foreach (DataRow UnaFila in miTabla.Rows)
                    {
                        int Id = (int)UnaFila["Id"];
                        string Titulo = (string)UnaFila["Titulo"];
                        string Genero = (string)UnaFila["Genero"];

                        lista.Add(new { Id, Titulo, GeneroDeLaPelicula = Genero });
                    }
                }
            }

            lista.Add(new { Id = 1, Nombre = "Volver al futuro" });
            lista.Add(new { Id = 2, Nombre = "Volver al futuro 2" });
            lista.Add(new { Id = 3, Nombre = "Volver al futuro 3" });

            return Ok(lista);
        }
    }
}
