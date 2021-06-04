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
            
            builder.HasKey(t => t.TodoItemId);
        }
    }
}
