using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class EspecieServico
    {
        private EspecieDAL EspecieDAL = new EspecieDAL();
        public IQueryable<Especie> ObterEspeciesClassificadosPorNome()
        {
            return EspecieDAL.ObterEspeciesClassificadosPorNome();
        }

        public Especie ObterEspeciePorId(long id)
        {
            return EspecieDAL.ObterEspeciePorId(id);
        }
        public void GravarEspecie(Especie Especie)
        {
            EspecieDAL.GravarEspecie(Especie);
        }

        public Especie EliminarEspeciePorId(long id)
        {
            Especie Especie = EspecieDAL.ObterEspeciePorId(id);
            EspecieDAL.EliminarEspeciePorId(id);
            return Especie;
        }
    }
}
