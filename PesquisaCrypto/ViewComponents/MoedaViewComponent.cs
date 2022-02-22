using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PesquisaCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCrypto.ViewComponents
{
    public class MoedaViewComponent : ViewComponent
    {
        private readonly MoedaContexto _moedaContexto;
        public MoedaViewComponent(MoedaContexto moedaContexto)
        {
            _moedaContexto = moedaContexto;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _moedaContexto.Moedas.ToListAsync());
        }
    }
}
