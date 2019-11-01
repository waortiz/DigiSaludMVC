﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiSalud.Models
{
    public class Cliente
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public bool Cotizante { get; set; }
        public List<int> Antecedentes { get; set; }
        public object Observaciones { get; internal set; }
    }
}