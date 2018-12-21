using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUBus.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public DateTime Hora { get; set; }
        public double Valor { get; set; }
    }
}
