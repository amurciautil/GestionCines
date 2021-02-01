﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCines
{
    class SesionesVM : INotifyPropertyChanged
    {
        public Sesion SESIONSELECCIONADA { get; set; }
        public Sesion SESIONFORMULARIO { get; set; }

        public ObservableCollection<Sesion> SESIONES { get; set; }
        public ObservableCollection<Pelicula> PELICULAS { get; set; }
        public ObservableCollection<Sala> SALAS { get; set; }
        public Modo ACCION { get; set; }

        private readonly ServicioBaseDatos bbdd;

        public SesionesVM() 
        {
            bbdd = new ServicioBaseDatos();
            SESIONFORMULARIO = new Sesion();
            SESIONES = bbdd.ObtenerSesiones();
            PELICULAS = bbdd.ObtenerPeliculas();
            SALAS = bbdd.ObtenerSalas(true);   
            ACCION = Modo.Insertar;
        }
        public void AñadirSesion()
        {
            SESIONFORMULARIO = new Sesion();
            ACCION = Modo.Insertar;
        }
        public void EditarSesion()
        {
            SESIONFORMULARIO = new Sesion(SESIONSELECCIONADA);
            ACCION = Modo.Actualizar;
        }
        public void BorrarSesion()
        {
            SESIONFORMULARIO = new Sesion(SESIONSELECCIONADA);
            bbdd.BorrarSesion(SESIONFORMULARIO);
            SESIONES = bbdd.ObtenerSesiones();
        }
        public bool HaySesionSeleccionada()
        {
            return SESIONSELECCIONADA != null;
        }
        public bool FormularioOk()
        {
             return SESIONFORMULARIO.HORA != "" && 
                   SESIONFORMULARIO.PELICULA != null &&
                   SESIONFORMULARIO.SALA != null;
        }
        public void GuardarCambios()
        {
            if (ACCION == Modo.Insertar)
            {
                bbdd.InsertarSesion(SESIONFORMULARIO);
            }
            else
                bbdd.ActualizarSesion(SESIONFORMULARIO);
            SESIONFORMULARIO = new Sesion();
            SESIONES = bbdd.ObtenerSesiones();
        }
        public void Cancelar()
        {
            SESIONFORMULARIO = new Sesion();
        }
        public bool HayDatos()
        {
            return SESIONFORMULARIO.HORA != null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
