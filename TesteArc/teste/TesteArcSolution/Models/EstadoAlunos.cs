using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteArcSolutions.Models
{
    public class EstadoAlunos
    {
        private LeituraArquvio arquivo = new LeituraArquvio();


        private List<AlunosCompeticao> competicao = new List<AlunosCompeticao>();
        private List<AlunosAprovados> aprovados;
        private List<AlunosReprovados> reprovados;

        public EstadoAlunos(List<AlunosAprovados> aprovados, List<AlunosReprovados> reprovados)
        {
            this.aprovados = aprovados;
            this.reprovados = reprovados;
        }

        public void VerificarAprovados()
        {
            var turmas = arquivo.LerArquivo();

            foreach (var turma in turmas)
            {
                foreach (var aluno in turma.alunos)
                {
                    var media = Calculo.veriricarMedia(aluno.Provas);

                    if (media > 6)
                    {
                        aprovados.Add(new AlunosAprovados(aluno.Provas, aluno.Nome, media));
                    }
                    else
                    {
                        if (media > 4 && media < 6)
                        {

                            var notaRecuperacao = Calculo.gerarNota();
                            var novaMedia = (media + notaRecuperacao) / 2;
                            Provas p = new Provas(novaMedia, "recuperacao");
                            p.Nota = notaRecuperacao;
                            aluno.AddProva(p);
                            if (novaMedia >= 5)
                            {
                                aprovados.Add(new AlunosAprovados(aluno.Provas, aluno.Nome, novaMedia));
                            }
                            else
                            {
                                reprovados.Add(new AlunosReprovados(aluno.Provas, aluno.Nome, novaMedia));
                            }
                        }
                    }
                }
            }
            
        }

        private List<AlunosAprovados> AlunosEmCompeticao()
        {

            var alunoOrdernado = aprovados.OrderByDescending(aluno => aluno.Media).ToList();
            var emCompeticao = alunoOrdernado.Take(5).ToList();

            return emCompeticao;
        }


        public List<AlunosCompeticao> BuscarCompetidores()
        {
            var competidores = AlunosEmCompeticao();

            foreach (var item in competidores)
            {
                var notaComp = Calculo.gerarNota();
                var prova = new Provas(notaComp, "competicao");
                item.AddProva(prova);
                competicao.Add(new AlunosCompeticao(item.Provas, item.Nome, notaComp));
            }

            return competicao;

        }


        public AlunosCompeticao VencedorCompeticao(List<AlunosCompeticao> alunos)
        {
            var ganhadorCompeticao = alunos.OrderByDescending(p => p.Media).Take(1);
            return ganhadorCompeticao.FirstOrDefault();

        }

    }

}
