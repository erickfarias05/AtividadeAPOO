using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class VeterinarioServico
    {
        private VeterinarioDAL veterinarioDAL = new VeterinarioDAL();
        public IQueryable<Veterinario> ObterVeterinariosClassificadosPorCrmv()
        {
            return veterinarioDAL.ObterVeterinariosClassificadosPorCrmv();
        }

        public Veterinario ObterVeterinarioPorId(long id)
        {
            return veterinarioDAL.ObterVeterinarioPorId(id);
        }
        public void GravarVeterinario(Veterinario veterinario)
        {
            veterinarioDAL.GravarVeterinario(veterinario);
        }

        public Veterinario EliminarVeterinarioPorId(long id)
        {
            Veterinario veterinario = veterinarioDAL.ObterVeterinarioPorId(id);
            veterinarioDAL.EliminarVeterinarioPorId(id);
            return veterinario;
        }

    }
}
