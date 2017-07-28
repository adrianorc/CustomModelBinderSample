using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Frota
    {
        public Frota()
        {
            Veiculos = new List<Veiculo>();
        }

        public int TotalVeiculos { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
    }
}
