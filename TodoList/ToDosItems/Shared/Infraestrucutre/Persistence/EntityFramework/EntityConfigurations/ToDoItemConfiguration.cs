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

            builder.OwnsOne(t => t.TodoItemId, a =>
            {
                a.HasKey(v => v.Value);
                a.Property(v => v.Value)
                    .HasColumnName("todo_id");
            });
                

            // builder.OwnsOne(t => t.TodoItemId)
            //     .Property(v => v.Value)
            //     .HasField("todo_id");

            builder.OwnsOne(t => t.Title, a =>
            {
                a.Property(v => v.Value)
                    .HasColumnName("title");
            });
            
            // builder.OwnsOne(t => t.Title)
            //     .Property(v => v.Value)
            //     .HasField("title");

            builder.OwnsOne(t => t.Description, a =>
            {
                a.Property(v => v.Value)
                    .HasColumnName("description");
            });
            
            // builder.OwnsOne(t => t.Description)
            //     .Property(v => v.Value)
            //     .HasField("description");

            builder.OwnsOne(t => t.IsDone, a =>
            {
                a.Property(v => v.Value)
                    .HasColumnName("is_done");
            });
            
            // builder.OwnsOne(t => t.IsDone)
            //     .Property(v => v.Value)
            //     .HasField("is_done");

        }
    }
}
