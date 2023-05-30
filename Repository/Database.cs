using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Database : DbContext
    {
        //public DbSet<Endereco> Enderecos { get; set; }

        private string _connectionString = "Server=localhost;User Id=root;Database=sistemaagropop;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
    }
}