﻿namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>()
                 .HasKey(k => new { k.SongId, k.PerformerId });

            builder.Entity<Song>()
                .HasMany(s => s.SongPerformers)
                .WithOne(sp => sp.Song)
                .HasForeignKey(sp => sp.SongId);

            builder.Entity<Performer>()
                .HasMany(p => p.PerformerSongs)
                .WithOne(ps => ps.Performer)
                .HasForeignKey(ps => ps.PerformerId);
        }
    }
}