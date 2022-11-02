using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class ConsultaServico
    {
        private ConsultaDAL consultaDAL = new ConsultaDAL();
        public IQueryable<Consulta> ObterConsultasClassificadosPorData()
        {
            return consultaDAL.ObterConsultasClassificadosPorData();
        }

        public Consulta ObterConsultaPorId(long id)
        {
            return consultaDAL.ObterConsultaPorId(id);
        }
        public void GravarConsulta(Consulta consulta)
        {
            consultaDAL.GravarConsulta(consulta);
        }

        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = consultaDAL.ObterConsultaPorId(id);
            consultaDAL.EliminarConsultaPorId(id);
            return consulta;
        }

    }
}
