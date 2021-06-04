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
            builder.ToTable("todo_item").HasKey(t => t.TodoItemId);
            builder.Property(t => t.TodoItemId)
                .HasField("todo_id");
            builder.OwnsOne(t => t.Title)
                .Property(v => v.Value)
                .HasField("title");
            builder.Property(t => t.Description)
                .HasField("description");
            builder.Property(t => t.IsDone)
                .HasField("is_done");
        }
    }
}
