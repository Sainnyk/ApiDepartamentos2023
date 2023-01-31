using ApiCrudDepartamentos2023.Data;
using ApiCrudDepartamentos2023.Models;

namespace ApiCrudDepartamentos2023.Repositories
{
    public class RepositoryDepartamento
    {

        private HospitalContext context;
        public RepositoryDepartamento(HospitalContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id)
        {
            var consulta = from datos in this.context.Departamentos where datos.IdDept == id select datos;
            return consulta.FirstOrDefault();
        }

        public List<Departamento> FindLocalidad(string localidad)
        {
            var consulta = from datos in this.context.Departamentos where datos.Localidad == localidad select datos;
            return consulta.ToList();
        }
    }
}
