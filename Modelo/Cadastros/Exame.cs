using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Modelo.Cadastros
{
    public class Exame
    {
        public long ExameId { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
