using EmprestimoJogo.Data;
using EmprestimoJogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoJogo.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _db; //criando uma varivael de leitura
        public EmprestimoController(ApplicationDbContext db) 
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            //gerar um IEnumerable chamado emprestimos usando a tabela Emprestimos do banco
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);//retornando para a view
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if(id == null || id == 0) // se o id for nulo ou 0 retorna erro
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id); //busca um id expecifico no banco

            if(emprestimo == null) 
            {
                return NotFound();
            }

            return View(emprestimo); //se não for nulo nem zero, retorna a view com o emprestimo
        }
        [HttpPost]
        //Recebe um emprestimos Model do tipo emprestimo
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid) //se o estado da model esta valida adiciona e salva as mudanças no db.
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro REALIZADO!!!";
                return RedirectToAction("Index");//redireciona o usuario para a Action Index
            }
            TempData["MensagemErro"] = "ERRO verifique e tente novamente!!!";

            return View(); //se o model state não for valido o usuario continua na view
        }
        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if(ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo); //faz as mudanças e salva no db
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição REALIZADA!!!"; //retorna um feedback sobre a ação
                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "ERRO verifique e tente novamente!!!";
            return View(emprestimo);
        }
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound(); 
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if(emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }
        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if(emprestimo == null)
            {
                return NotFound();
                TempData["MensagemErro"] = "ERRO verifique e tente novamente!!!";
            }
            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Excluido com SUCESSO!!!";

            return RedirectToAction("Index");
        }
    }
}
