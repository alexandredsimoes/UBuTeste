using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUBus.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        public Itinerario Itinerario { get; set; }        
        public int ItinerarioId { get; set; }
        public Funcionario Motorista { get; set; }
        public int MotoristaId { get; set; }

    }
}
