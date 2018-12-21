using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUBus.Models
{
    public class TipoComplemento
    {
        public int Id { get; set; }
        public TipoExibicao TipoExibicao { get; set; }
        public string DescricaoAdicional { get; set; }
    }
}
