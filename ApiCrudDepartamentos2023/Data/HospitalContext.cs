using ApiCrudDepartamentos2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudDepartamentos2023.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
