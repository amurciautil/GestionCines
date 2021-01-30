﻿using System.ComponentModel;

namespace GestionCines
{
    class Pelicula : INotifyPropertyChanged
    {
        public int IDPELICULA { get; set; }
        public string TITULO { get; set; }
        public string CARTEL { get; set; }
        public int AÑO { get; set; }
        public string GENERO { get; set; }
        public string CALIFICACION { get; set; }

        public Pelicula()
        {
        }

        public Pelicula(int idPelicula, string titulo, string cartel, int año, string genero, string calificacion)
        {
            IDPELICULA = idPelicula;
            TITULO = titulo;
            CARTEL = cartel;
            AÑO = año;
            GENERO = genero;
            CALIFICACION = calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}