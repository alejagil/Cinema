using Cinema_AGV.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_AGV
{
    public class Peliculas
    {
        public string Nombre { get; set; }
        public string FechaEstreno { get; set; }
        public string Genero { get; set; }
        public string Recomendacion { get; set; }  
        public int Duracion { get; set; }
        public string Imagen { get; set; }
        public List<Funciones> Funciones { get; set; }

    }
}
