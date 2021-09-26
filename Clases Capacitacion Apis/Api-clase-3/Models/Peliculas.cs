using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_clase_2.Models
{
    public static class Peliculas
    {
        public static List<Pelicula> getAll()
        {
            //Hacer con conexion a MySql
            List<Pelicula> list = new List<Pelicula>();
            Pelicula peli = new Pelicula();
            peli.Genero = "Accion";
            peli.Titulo = "Terminator 3";
            peli.Id = 10;

            list.Add(peli);
            return list;
        }
        public static Pelicula getById(int id)
        {
            //Hacer con conexion a MySql usando 
            Pelicula peli = new Pelicula();
            peli.Genero = "Accion";
            peli.Titulo = "Terminator";
            peli.Id = id;

            return peli;
        }
        /*public static createNew(Pelicula unaPeli)
        {
            Insert into Peliculas(Propiedades) values(Valores de unaPeli)
        }*/
    }
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
    }
}
