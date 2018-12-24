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
        public string Nome { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public double Valor { get; set; }
        public int RotaId { get; set; }
        public Rota Rota { get; set; }
    }
}
