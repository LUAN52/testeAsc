using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAsc.Models;

namespace TesteAsc.Controllers
{
    public class AprendendoController : Controller
    {
        private LeituraArquvio arquivo = new LeituraArquvio();
        public List<AlunosAprovados> aprovados = new List<AlunosAprovados>();
        private List<AlunosReprovados> reprovados = new List<AlunosReprovados>();
        
        public IActionResult Competidores()
        {
            var estado = new EstadoAlunos(aprovados, reprovados);
            estado.VerificarAprovados();

            return View(estado.BuscarCompetidores());
        }

        public IActionResult VencedorCompeticao()
        {
            var estado = new EstadoAlunos(aprovados, reprovados);
            estado.VerificarAprovados();
            var competidores=  estado.BuscarCompetidores();


            return View(estado.VencedorCompeticao(competidores));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaAlunos()
        {
            return View(arquivo.LerArquivo());
        }


    }
}
