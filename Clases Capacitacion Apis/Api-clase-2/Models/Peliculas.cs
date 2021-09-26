using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
            MySqlCommand miComando = new MySqlCommand();
            MySqlConnection miConexion = new MySqlConnection("“server=127.0.0.1; database=peliculas; Uid=root; pwd=;”");
            miComando.Connection = miConexion;
            miComando.CommandType = System.Data.CommandType.Text;
            miComando.CommandText = "select * from pelis where id=@Id";
            miComando.Parameters.AddWithValue("@Id", id);

            DataTable miTabla = new DataTable();
            MySqlDataAdapter miAdaptador = new MySqlDataAdapter();
            miAdaptador.SelectCommand = miComando;
            miAdaptador.Fill(miTabla);

            Pelicula unaPelicula = new Pelicula();
            if (miTabla.Rows.Count>0)
            {
                unaPelicula.Id = id;
                unaPelicula.Titulo = (string)miTabla.Rows[0]["titulo"];
                unaPelicula.Año = (string)miTabla.Rows[0]["año"];
                unaPelicula.Genero = (string)miTabla.Rows[0]["genero"];
            }
            else
            {
                unaPelicula = null;
            }
            return unaPelicula;

            //Hacer con conexion a MySql usando 
           /* Pelicula peli = new Pelicula();
            peli.Genero = "Accion";
            peli.Titulo = "Terminator";
            peli.Id = id;

            return peli;*/
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
        public string Año { get; set; }

    }
}
