using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAsc.Models;

namespace TesteAsc
{
    public class AlunosReprovados : Alunos
    {
        public AlunosReprovados(List<Provas>provas,string nome,double media):base(provas,nome)
        {
            Media = media;
            
        }


        public double Media { get; set; }


    }
}
