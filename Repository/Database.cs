using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class Database : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fazenda> Fazendas { get; set; }
        public DbSet<Vacina> Vacinas { get; set; }
        private string _connectionString = "Server=localhost;User Id=root;Database=sistemaagropop;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
    }
}