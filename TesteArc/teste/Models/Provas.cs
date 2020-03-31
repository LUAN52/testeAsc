using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAsc.Models
{
    public class Provas
    {

        public Provas(double nota,string tipoProva)
        {
            Nota = nota;
            TipoProva = tipoProva;

        }

        public string TipoProva { get; set; }
        public int Id { get; }
        public double Nota { get; set; }

      
    }
}
