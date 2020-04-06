using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAsc.Models
{
    public class Alunos
    {
        public Alunos(List<Provas> provas,string nome)
        {
            Provas = provas;
            this.Nome = nome;
        }

        public int Id { get; }
        public string Nome { get; }
        public List<Provas> Provas { get;  }

        public void AddProva(Provas prova)
        {
            Provas.Add(prova);
        }
    }
}
