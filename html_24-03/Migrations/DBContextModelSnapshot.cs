﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using html_24_03.Models;

#nullable disable

namespace html_24_03.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("html_24_03.Models.Aluno", b =>
                {
                    b.Property<int>("alunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("alunoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("alunoId"), 1L, 1);

                    b.Property<int?>("alunoCursoId")
                        .HasColumnType("int")
                        .HasColumnName("alunoCursoId");

                    b.Property<string>("alunoNome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("alunoNome");

                    b.HasKey("alunoId");

                    b.HasIndex("alunoCursoId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("html_24_03.Models.Cursos", b =>
                {
                    b.Property<int>("cursosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cursoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cursosId"), 1L, 1);

                    b.Property<string>("cursoNome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cursoNome");

                    b.HasKey("cursosId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("html_24_03.Models.Noticia", b =>
                {
                    b.Property<int>("noticiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("noticiaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("noticiaId"), 1L, 1);

                    b.Property<string>("noticiaDescr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noticiaDescr");

                    b.Property<string>("noticiaImg")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noticiaImg");

                    b.Property<string>("noticiaTexto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noticiaTexto");

                    b.Property<string>("noticiaTitulo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noticiaTitulo");

                    b.HasKey("noticiaId");

                    b.ToTable("Noticia");
                });

            modelBuilder.Entity("html_24_03.Models.Professores", b =>
                {
                    b.Property<int>("ProfessoresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfessoresId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessoresId"), 1L, 1);

                    b.Property<int?>("ProfessoresCursoId")
                        .HasColumnType("int")
                        .HasColumnName("ProfessoresCursoId");

                    b.Property<string>("ProfessoresNome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ProfessoresNome");

                    b.HasKey("ProfessoresId");

                    b.HasIndex("ProfessoresCursoId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("html_24_03.Models.Aluno", b =>
                {
                    b.HasOne("html_24_03.Models.Cursos", "alunoCurso")
                        .WithMany("cursoAluno")
                        .HasForeignKey("alunoCursoId");

                    b.Navigation("alunoCurso");
                });

            modelBuilder.Entity("html_24_03.Models.Professores", b =>
                {
                    b.HasOne("html_24_03.Models.Cursos", "ProfessoresCurso")
                        .WithMany("cursoProfessor")
                        .HasForeignKey("ProfessoresCursoId");

                    b.Navigation("ProfessoresCurso");
                });

            modelBuilder.Entity("html_24_03.Models.Cursos", b =>
                {
                    b.Navigation("cursoAluno");

                    b.Navigation("cursoProfessor");
                });
#pragma warning restore 612, 618
        }
    }
}