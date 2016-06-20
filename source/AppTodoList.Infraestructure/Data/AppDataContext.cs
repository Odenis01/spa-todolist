using AppTodoList.Domain.Models;
using AppTodoList.Infraestructure.Data.Map;
using System.Data.Entity;

namespace AppTodoList.Infraestructure.Data
{
   public class AppDataContext:DbContext
    {
       public AppDataContext():base("AppContectionString")
       {
           Configuration.LazyLoadingEnabled = false;
           Configuration.ProxyCreationEnabled = false;           
       }
       public DbSet<Usuario> Usuarios { get; set; }
       public DbSet<Categoria> Categorias { get; set; }
       public DbSet<Tarefa> Tarefas{ get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {

           modelBuilder.Configurations.Add(new CategoriaMap());
           modelBuilder.Configurations.Add(new UsuarioMap());
           modelBuilder.Configurations.Add(new TarefaMap());

           modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar"));

           modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

           base.OnModelCreating(modelBuilder);
       } 
    }
}
