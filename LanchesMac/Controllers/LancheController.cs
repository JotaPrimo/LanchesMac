﻿using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository repository)
        {
            _lancheRepository = repository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.GetAll.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.GetAll.
                    Where(l => l.Categoria.CategoriaNome == categoria)
                    .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.GetAll.FirstOrDefault(l => l.Id == lancheId);
            return View(lanche);
        }

    }
}
