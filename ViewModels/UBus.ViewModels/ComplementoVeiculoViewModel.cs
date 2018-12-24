using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBus.ViewModels
{
    public class ComplementoVeiculoViewModel
    {
        public int Id { get; set; }
        public int TipoComplementoId { get; set; }
        public string TipoComplementoNome { get; set; }
        public int VeiculoId { get; set; }
        public string VeiculoPlaca { get; set; }

        public int VeiculoModeloId { get; set; }
        public string VeiculoModeloNome { get; set; }
    }
}
