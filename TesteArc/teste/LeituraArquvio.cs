using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAsc.Models;

namespace TesteAsc
{
    public class LeituraArquvio
    {
        public List<Turmas> turmas = new List<Turmas>();
        public List<Turmas> LerArquivo()
        {
            using (var lerAquivo = new StreamReader("nome.csv"))
            {
                while (!lerAquivo.EndOfStream)
                {
                    var linha = lerAquivo.ReadLine().Split(";");

                    var nTurma = linha[0];
                    var nomeAluno = linha[1];
                    var notaA = double.Parse(linha[2], CultureInfo.InvariantCulture);
                    var notaB = double.Parse(linha[3], CultureInfo.InvariantCulture);
                    var notaC = double.Parse(linha[4], CultureInfo.InvariantCulture);


                    Provas prova1 = new Provas(notaA,"bimestral");
                    Provas prova2 = new Provas(notaB,"bismetral");
                    Provas prova3 = new Provas(notaC,"bimestral");

                    Alunos aluno = new Alunos(new List<Provas>(), nomeAluno);

                    aluno.AddProva(prova1);
                    aluno.AddProva(prova2);
                    aluno.AddProva(prova3);

                    var turma = turmas.Find(p => p.IdTurma == nTurma);

                    if (turma == null)
                    {
                        Turmas turma1 = new Turmas(new List<Alunos>(), nTurma);
                        turma1.AddAluno(aluno);
                        turmas.Add(turma1);
                    }
                    else
                    {
                        var aluno1 = turma.alunos.Find(prop => prop.Nome == nomeAluno);
                        if (aluno != null)
                        {
                            turma.AddAluno(aluno);
                        }

                    }


                }
            }
            return turmas;
        }
    }
}
