using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTarefas.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.DataBase
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefa {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("DataSource=ApiDb.db; Cache=Shared");
    }
}