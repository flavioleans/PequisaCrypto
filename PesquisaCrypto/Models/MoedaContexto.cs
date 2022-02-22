using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCrypto.Models
{
    public class MoedaContexto:DbContext
    {
        public DbSet<Moeda> Moedas { get; set; }
        public MoedaContexto(DbContextOptions<MoedaContexto> opcoes) : base(opcoes)
        {

        }
    }
}
