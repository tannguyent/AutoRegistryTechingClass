using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AutoRegistryTechingClass.AutoRegistry.Data;

namespace AutoRegistryTechingClass.Migrations
{
    [DbContext(typeof(RegisteredClassManagerContext))]
    [Migration("20160723182233_RegisteredClassMigration")]
    partial class RegisteredClassMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("AutoRegistryTechingClass.AutoRegistry.Data.RegisteredClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassId");

                    b.Property<string>("ClassName");

                    b.Property<bool>("Registered")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("RegisteredClass");
                });
        }
    }
}
