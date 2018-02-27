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
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<DigestSource> DigestSources { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Subscriptions
            modelBuilder.Entity<Subscription>()
                .HasKey(sub => new { sub.UserId , sub.DigestId });

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(sub => sub.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Digest)
                .WithMany(d => d.Subscribers)
                .HasForeignKey(sub => sub.DigestId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region DigestSources
            modelBuilder.Entity<DigestSource>()
                .HasKey(ds => new { ds.DigestId, ds.SourceId });

            modelBuilder.Entity<DigestSource>()
                .HasOne(ds => ds.Digest)
                .WithMany(d => d.DigestSources)
                .HasForeignKey(ds => ds.DigestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DigestSource>()
                 .HasOne(ds => ds.Source)
                .WithMany(s => s.DigestSources)
                .HasForeignKey(ds => ds.SourceId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Friendships
            modelBuilder.Entity<Friendship>()
                .HasKey(f => new { f.Friend1Id, f.Friend2Id });

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend1)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.Friend1Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Friendship>()
                .HasOne(f => f.Friend2)
                .WithMany()
                .HasForeignKey(f => f.Friend2Id)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

        public NewsfeedContext(DbContextOptions<NewsfeedContext> options)
       : base(options)
        { }

    }
}
