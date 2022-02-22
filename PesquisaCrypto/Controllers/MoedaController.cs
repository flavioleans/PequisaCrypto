using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PesquisaCrypto.Models;

namespace PesquisaCrypto.Controllers
{
    public class MoedaController : Controller
    {
        private readonly MoedaContexto _context;

        public MoedaController(MoedaContexto context)
        {
            _context = context;
        }

        // GET: Moeda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moedas.ToListAsync());
        }

        public async Task<IActionResult> EscolhaDeMoeda(List<Moeda> moedas)
        {
            foreach (var item in moedas)
            {
                if (item.CheckBoxMarcado == true)
                {
                    Moeda moeda = await _context.Moedas.FirstAsync(x => x.MoedaId == item.MoedaId);
                    moeda.Quantidade = moeda.Quantidade + 1;
                    _context.Update(moeda);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
           
        }

        public JsonResult DadosGrafico()
        {
            return Json(_context.Moedas.Select(x => new { x.Nome, x.Quantidade }));
        }

        // GET: Moeda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moeda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoedaId,Nome,Quantidade")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                moeda.Quantidade = 0;
                _context.Add(moeda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moeda);
        }


    }
}
