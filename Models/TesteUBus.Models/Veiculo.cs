using System;
using System.Collections.Generic;

namespace TesteUBus.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public TipoVeiculo Tipo { get; set; }
        public MarcaVeiculo Marca { get; set; }
        public int MarcaId { get; set; }
        public IList<ComplementoVeiculo> Complementos { get; set; }
    }
}
