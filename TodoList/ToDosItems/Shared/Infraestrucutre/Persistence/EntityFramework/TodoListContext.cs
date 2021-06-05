using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ToDosItems.Domain;

namespace TodoList.ToDosItems.Shared.Infraestrucutre.Persistence.EntityFramework
{
    public class TodoListContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        // public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=todo_list_application;Uid=root;Pwd=*Saass_2021@mySQL*;");
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ToDoItemConfiguration());
        }
    }
}
