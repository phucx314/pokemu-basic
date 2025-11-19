using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.Database
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        private readonly ICurrentUserContext _currentUserContext;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, ICurrentUserContext currentUserContext) : base(options)
        {
            _currentUserContext = currentUserContext;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        #region DbSet Declarations
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<PackRarityDropRate> PackRarityDropRates { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<CardSuperType> CardSuperTypes { get; set; }
        public DbSet<CardSubType> CardSubTypes { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Expansion> Expansions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleEntityStateChange();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleEntityStateChange()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }
        }
    }
}
