using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.EntityFramework.EntityConfigurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder) 
        {
            builder.ToTable("todo_item");

            builder.HasKey(x => x.TodoItemId);

            builder.Property(x => x.TodoItemId)
                .HasConversion(v => v.Value, v => new ToDoId(v))
                .HasColumnName("todo_id")
                .HasColumnType("BINARY(36)")
                .HasMaxLength(34);
            
            builder.Property(x => x.Title)
                .HasConversion(v => v.Value, v => new ToDoTitle(v))
                .HasColumnName("title");
            
            builder.Property(x => x.Description)
                .HasConversion(v => v.Value, v => new ToDoDescription(v))
                .HasColumnName("description");
            
            builder.Property(x => x.IsDone)
                .HasConversion(v => v.Value, v => new ToDoIsDone(v))
                .HasColumnName("is_done");
        }
    }
}
