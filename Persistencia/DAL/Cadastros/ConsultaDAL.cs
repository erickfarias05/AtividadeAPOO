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
            return context.Consultas.Include(c => c.Exame).OrderBy(n => n.Data_hora);
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(p => p.ConsultaId == id).Include(c => c.Exame).First();
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
