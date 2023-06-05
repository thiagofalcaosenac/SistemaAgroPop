﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace SistemaAgroPop.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20230605014424_VacinaFornecida")]
    partial class VacinaFornecida
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Model.Fazenda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("enderecoid")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("qtdLimiteAnimal")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("enderecoid");

                    b.ToTable("Fazendas");
                });

            modelBuilder.Entity("Model.VacinaFornecida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataCompra")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataFabricacao")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataValidade")
                        .HasColumnType("date");

                    b.Property<float>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("VacinaFornecidas");
                });

            modelBuilder.Entity("Model.Fazenda", b =>
                {
                    b.HasOne("Model.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
