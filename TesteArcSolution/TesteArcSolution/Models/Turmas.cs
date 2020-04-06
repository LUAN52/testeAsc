using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAscSoltuion.Models
{
    public class Turmas
    {
        public Turmas( List<Alunos> alunos,string turma)
        {
            this.IdTurma = IdTurma;
            this.alunos = alunos;
        }

        public string IdTurma { get; set; }
        public List<Alunos> alunos { get; }

       public void AddAluno(Alunos aluno)
        {
            alunos.Add(aluno);
        }

         
    }
}


