using AppTodoList.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AppTodoList.Infraestructure.Data.Map
{
    public class TarefaMap:EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            ToTable("Tarefa");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(x => x.Titulo)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Descricao).HasMaxLength(150);

            HasOptional(x => x.Categoria);                
            HasOptional(x => x.Usuario);
        }
    }
}
