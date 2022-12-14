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
    public class VeterinarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Exame> ObterExamesClassificadosPorNome()
        {
            return context.Exames.OrderBy(b => b.Descricao);
        }

        public Exame ObterExamePorId(long id)
        {
            return context.Exames.Where(f => f.ExameId == id).First();
        }

        public void GravarExame(Exame exame)
        {
            if (exame.ExameId == 0)
            {
                context.Exames.Add(exame);
            }
            else
            {
                context.Entry(exame).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Exame EliminarExamePorId(long id)
        {
            Exame exame = ObterExamePorId(id);
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }

    }
}
