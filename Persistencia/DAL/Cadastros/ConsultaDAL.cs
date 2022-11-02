using Modelo.Cadastros;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadosPorData()
        {
            return context.Consultas.OrderBy(b => b.Data_hora);
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(f => f.ConsultaId == id).First();
        }

        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.ConsultaId == 0)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = ObterConsultaPorId(id);
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }

    }
}
