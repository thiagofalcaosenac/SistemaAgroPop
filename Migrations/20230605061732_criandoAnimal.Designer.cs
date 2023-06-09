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
    [Migration("20230605061732_criandoAnimal")]
    partial class criandoAnimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Model.Animal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cor")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("fazendaid")
                        .HasColumnType("int");

                    b.Property<int>("nroRegistro")
                        .HasColumnType("int");

                    b.Property<int>("origem")
                        .HasColumnType("int");

                    b.Property<int>("peso")
                        .HasColumnType("int");

                    b.Property<int>("racaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("fazendaid");

                    b.HasIndex("racaid");

                    b.ToTable("Animals");
                });

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

            modelBuilder.Entity("Model.Raca", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("enderecoid")
                        .HasColumnType("int");

                    b.Property<string>("especie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("porte")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("enderecoid");

                    b.ToTable("Racas");
                });

            modelBuilder.Entity("Model.Animal", b =>
                {
                    b.HasOne("Model.Fazenda", "fazenda")
                        .WithMany()
                        .HasForeignKey("fazendaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Raca", "raca")
                        .WithMany()
                        .HasForeignKey("racaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("fazenda");

                    b.Navigation("raca");
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

            modelBuilder.Entity("Model.Raca", b =>
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
