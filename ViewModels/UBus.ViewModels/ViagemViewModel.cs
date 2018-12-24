using System;
using System.ComponentModel.DataAnnotations;

namespace UBus.ViewModels
{
    public class ViagemViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a data da viagem")]
        [Display(Name = "Data da viagem")]
        public DateTime Data { get; set; }
        [Display(Name = "Placa")]
        public string VeiculoPlaca { get; set; }
        [Required(ErrorMessage = "Informe o veículo")]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }
        [Display(Name = "Itinerário")]
        public string ItinerarioNome { get; set; }
        [Required(ErrorMessage = "Informe o itinerário")]
        [Display(Name = "Itinerário")]
        public int ItinerarioId { get; set; }
        [Display(Name = "Motorista")]
        public string MotoristaNome { get; set; }
        [Required(ErrorMessage = "Informe o motorista")]
        [Display(Name = "Motorista")]
        public int MotoristaId { get; set; }
    }
}
