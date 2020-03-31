using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAsc.Models
{
    public class AlunosCompeticao : Alunos
    {
        public double Media { get; set; }
        public AlunosCompeticao(List<Provas> provas, string nome,double media) : base(provas, nome)
        {

            Media = media;
        }



       
    }
}
