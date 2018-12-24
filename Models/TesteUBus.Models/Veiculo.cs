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
        public string Placa { get; set; }
        public ModeloVeiculo Modelo { get; set; }
        public int ModeloId { get; set; }
        public List<ComplementoVeiculo> Complementos { get; set; }
        public List<Viagem> Viagens { get; set; }

        public Veiculo()
        {
            Viagens = new List<Viagem>();
            Complementos = new List<ComplementoVeiculo>();
        }
    }
}
