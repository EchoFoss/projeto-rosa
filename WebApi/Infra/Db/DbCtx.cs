using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Infra.Db;

public class DbCtx(DbContextOptions<DbCtx> options) : DbContext(options)
{
    public DbSet<Perfil> Perfis { get; set; }
}