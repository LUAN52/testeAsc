using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAscSoltuion.Models
{
    public class AlunosAprovados : Alunos
    {
        // deixei essa classe indentica a de alunos repovados pois ainda sei como eu faria para criar duas tabelas diferentes apartir de unica classe//
        public AlunosAprovados(List<Provas> provas,string nome, double media) :base(provas,nome)
        {
            Media = media;
        }

        public double   Media { get; set; }


    }
}
