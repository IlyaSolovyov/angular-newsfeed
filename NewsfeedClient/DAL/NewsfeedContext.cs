using Microsoft.EntityFrameworkCore;
using NewsfeedClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.DAL
{
    public class NewsfeedContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Digest> Digests { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Subscriptions
            modelBuilder.Entity<Subscription>()
                .HasKey(sub => new { sub.UserId , sub.DigestId });

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(sub => sub.UserId);

            modelBuilder.Entity<Subscription>()
                   .HasOne(s => s.Digest)
                .WithMany(d => d.Subscribers)
                .HasForeignKey(sub => sub.DigestId);
            #endregion

            #region DigestSources
            modelBuilder.Entity<DigestSource>()
                .HasKey(ds => new { ds.DigestId, ds.SourceId });

            modelBuilder.Entity<DigestSource>()
                .HasOne(ds => ds.Digest)
                .WithMany(d => d.DigestSources)
                .HasForeignKey(ds => ds.DigestId);

            modelBuilder.Entity<DigestSource>()
                 .HasOne(ds => ds.Source)
                .WithMany(s => s.DigestSources)
                .HasForeignKey(ds => ds.SourceId);
            #endregion
        }

    }
}
