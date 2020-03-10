using CrudSemBD.Context;
using CrudSemBD.Models;
using CrudSemBD.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudSemBD.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            using (var contexto = new DBCrud())
            {
                var buscaPessoas = contexto.Pessoas.AsNoTracking().ToList();
                var pessoaViewModel = new List<PessoaViewModel>();

                if (buscaPessoas != null)
                {
                    foreach (var item in buscaPessoas)
                    {
                        pessoaViewModel.Add(new PessoaViewModel
                        {
                            idPessoa = item.idPessoa,
                            idSexo = item.idSexo,
                            dtNascimento = item.dtNascimento.ToString("dd/MM/yyy"),
                            nmPessoa = item.nmPessoa,
                            pessoaCPF = item.pessoaCPF,
                            descricaoSexo = item.Sexo.descricaoSexo
                        });
                    }
                }

                return View(pessoaViewModel);
            }
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();

            if(buscaPessoa == null)
            {
                return View();
            }

            pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
            pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;
            pessoaViewModel.idSexo = buscaPessoa.idSexo;
            pessoaViewModel.dtNascimento = buscaPessoa.dtNascimento.ToString("dd/MM/yyyy");
            pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
            pessoaViewModel.descricaoSexo = buscaPessoa.Sexo.descricaoSexo;

            return View(pessoaViewModel);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            PreencherViewBag();

            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(var context = new DBCrud())
                    {
                        context.Pessoas.Add(new PessoaModel
                        {
                            nmPessoa = model.nmPessoa,
                            dtNascimento = Convert.ToDateTime(model.dtNascimento),
                            idPessoa = model.idPessoa,
                            idSexo = model.idSexo,
                            pessoaCPF = model.pessoaCPF
                        });

                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();

            if(buscaPessoa == null)
            {
                return View();
            }

            pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
            pessoaViewModel.idSexo = buscaPessoa.idSexo;
            pessoaViewModel.dtNascimento = buscaPessoa.dtNascimento.ToString("dd/MM/yyyy");
            pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
            pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;

            PreencherViewBag();

            return View(pessoaViewModel);

        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(var context = new DBCrud())
                    {
                        var buscaPessoa = context.Pessoas.Find(model.idPessoa);

                        if(buscaPessoa != null)
                        {
                            buscaPessoa.idSexo = model.idSexo;
                            buscaPessoa.nmPessoa = model.nmPessoa;
                            buscaPessoa.pessoaCPF = model.pessoaCPF;
                            buscaPessoa.dtNascimento = Convert.ToDateTime(model.dtNascimento);

                            context.SaveChanges();
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var buscaPessoa = BuscaPessoaById(id);
            var pessoaViewModel = new PessoaViewModel();
            
            if(buscaPessoa != null)
            {
                pessoaViewModel.idPessoa = buscaPessoa.idPessoa;
                pessoaViewModel.idSexo = buscaPessoa.idSexo;
                pessoaViewModel.dtNascimento = buscaPessoa.dtNascimento.ToString("dd/MM/yyy");
                pessoaViewModel.pessoaCPF = buscaPessoa.pessoaCPF;
                pessoaViewModel.nmPessoa = buscaPessoa.nmPessoa;
                pessoaViewModel.descricaoSexo = buscaPessoa.Sexo.descricaoSexo;
            }
          
            return View(pessoaViewModel);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        public ActionResult Delete(PessoaViewModel model)
        {
            try
            {
                using(var context = new DBCrud())
                {
                    var buscaPessoa = context.Pessoas.Find(model.idPessoa);

                    if(buscaPessoa != null)
                    {
                        context.Pessoas.Remove(buscaPessoa);
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {                
                return View(model);
            }
        }

        public PessoaModel BuscaPessoaById(int id)
        {
            using (var contexto = new DBCrud())
            {
                var buscaPessoa = contexto.Pessoas.Include("Sexo").AsNoTracking().FirstOrDefault(x => x.idPessoa == id);

                if (buscaPessoa != null)
                {
                    return buscaPessoa;
                }

                return null;
            }
        }
        public void PreencherViewBag()
        {
            using (var context = new DBCrud())
            {
                ViewBag.listaSexo = context.Sexos.AsNoTracking().ToList();
            }
        }
    }
}
