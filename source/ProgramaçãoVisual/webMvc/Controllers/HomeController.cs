using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webMvc.Models;

namespace webMvc.Controllers
{
    public class HomeController: Controller
    {
        private static  IList<Pessoa> PessoaList = new List<Pessoa>
        {
            new Pessoa{id = 1, Nome = "Joao"},
            new Pessoa{id = 2, Nome = "Joao"},
            new Pessoa{id = 3, Nome = "Joao"}
        };

        public IList<Pessoa> GetPessoas()
        {
            return PessoaList;
        }
        public Pessoa AddPessoa(string nome)
        {
            try {
                var pessoa = new Pessoa {Nome = nome};
                pessoa.id = PessoaList.Max(p =>p.id) +1;
                PessoaList.Add(pessoa);
                return pessoa;
            } catch {}
            return null;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
