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
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return context.Especies.OrderBy(b => b.Nome);
        }

        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(f => f.EspecieId == id).First();
        }

        public void GravarEspecie(Especie especie)
        {
            if (especie.EspecieId == 0)
            {
                context.Especies.Add(especie);
            }
            else
            {
                context.Entry(especie).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie especie = ObterEspeciePorId(id);
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}
