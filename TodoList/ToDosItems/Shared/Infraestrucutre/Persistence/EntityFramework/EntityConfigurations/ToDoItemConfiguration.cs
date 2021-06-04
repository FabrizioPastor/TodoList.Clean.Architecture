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
            builder.ToTable("todo_item").OwnsOne(t => t.TodoItemId)
                .HasKey(v => v.Value);

            builder.OwnsOne(t => t.TodoItemId)
                .Property(v => v.Value)
                .HasField("todo_id");

            builder.OwnsOne(t => t.Title)
                .Property(v => v.Value)
                .HasField("title");

            builder.OwnsOne(t => t.Description)
                .Property(v => v.Value)
                .HasField("description");

            builder.OwnsOne(t => t.IsDone)
                .Property(v => v.Value)
                .HasField("is_done");
        }
    }
}
