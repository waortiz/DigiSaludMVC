using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiSalud.Models
{
    public class Cliente
    {
        public string PrimerNombre { get; set; }
        public List<int> Antecedentes { get; set; }
    }
}