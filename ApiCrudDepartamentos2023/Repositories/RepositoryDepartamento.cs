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

        public async Task InsertDepartamentoAsync(int id,string nombre,string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDept = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;

            this.context.Departamentos.Add(departamento);
           await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(Departamento dept)
        {
            Departamento departamento = this.FindDepartamento(dept.IdDept);
            departamento.Nombre = dept.Nombre;
            departamento.Localidad = dept.Localidad;

            await this.context.SaveChangesAsync(true);
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento departamento = this.FindDepartamento(id);

            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
