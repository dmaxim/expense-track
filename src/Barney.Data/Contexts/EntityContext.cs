

using System;
using System.Collections.ObjectModel;
using Barney.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Contracts;

namespace Barney.Data.Contexts
{
    public class EntityContext : DbContext, IEntityContext
    {
        private readonly string _connectionString;
        private const string DefaultSchema = "dbo";


		public EntityContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Expose the underlying database context
        /// </summary>
        public DbContext Context => this;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: new Collection<int>());
                });


            base.OnConfiguring(optionsBuilder);


        }

        /// <inheritdoc />
        /// <summary>
        /// Initialize the database model mapping
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapEntitiesToTable(modelBuilder);

         
        }

        private void MapEntitiesToTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employer>()
                .ToTable("Employer", DefaultSchema)
                .Property(properties => properties.Name)
                .HasColumnName("EmployerName")
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(properties => properties.Description)
                .HasColumnName("EmployerDescription")
                .IsUnicode(false);

            modelBuilder.Entity<Expense>()
                .ToTable("Expense", DefaultSchema)
                .Property(properties => properties.Description)
                .HasColumnName("ExpenseDescription")
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseClassification>()
                .ToTable("ExpenseClassification", DefaultSchema)
                .Property(properties => properties.Name)
                .HasColumnName("ClassificationName")
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseOwner>()
                .ToTable("ExpenseOwner", DefaultSchema)
                .Property(properties => properties.OwnerUserId)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseOwner>()
                .Property(properties => properties.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<ExpenseOwner>()
                .Property(properties => properties.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Income>()
                .ToTable("Income", DefaultSchema);

            modelBuilder.Entity<IncomeClassification>()
                .ToTable("IncomeClassification", DefaultSchema)
                .Property(properties => properties.Name)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeClassification>()
                .Property(properties => properties.Description)
                .IsUnicode(false);
        }
    }
}
