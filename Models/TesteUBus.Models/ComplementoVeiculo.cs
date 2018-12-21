using System;
using System.Collections.Generic;
using System.Text;

namespace TesteUBus.Models
{
    public class ComplementoVeiculo
    {
        public int Id { get; set; }
        public TipoComplemento Tipo { get; set; }
        public int TipoComplementoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
        public string Valor { get; set; }
    }
}
