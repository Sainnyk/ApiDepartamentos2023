using ApiCrudDepartamentos2023.Models;
using ApiCrudDepartamentos2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudDepartamentos2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamento repo;
        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Departamento>> GetDepartamentos()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return departamentos;
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> FindDepartamento(int id)
        {
            Departamento departamento= this.repo.FindDepartamento(id);
            return departamento;
        }

        [HttpGet]
        [Route("[action]/{localidad}")]
        public ActionResult<List<Departamento>> DepartamentosLocalidad(string localidad)
        {
            List<Departamento> departamentos = this.repo.FindLocalidad(localidad);
            return departamentos;
        }

        //Vamos a tener dos metodos diferentes para Insertar
        //1) En el primer método iran los valores por URL
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task InsertDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id,nombre,localidad);
        }

        //2) La segunda forma recibirá el departamento por body con JSON.
        //Este metodo es el que tiene por defecto cualquier controller para post, por lo que no hay que usar Route
        [HttpPost]
        public async Task InsertarDepartamento(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDept,dept.Nombre,dept.Localidad);

        }

        //El metodo Put por defecto tambien recibe un objeto
        [HttpPut]
        public async Task UpdateDepartamento(Departamento dept)
        {
            await this.repo.UpdateDepartamentoAsync(dept);
        }

        //El metodo delete por defecto recibe un parametro por defecto {ID}
        [HttpDelete("{id}")]
        public async Task DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
        }
    }
}
