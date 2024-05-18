using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp
{
    public partial class tvdbContext : DbContext
    {
        public tvdbContext()
        {
        }

        public tvdbContext(DbContextOptions<tvdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benutzter> Benutzters { get; set; } = null!;
        public virtual DbSet<Kunden> Kundens { get; set; } = null!;
        public virtual DbSet<Tier> Tiers { get; set; } = null!;
        public virtual DbSet<Tr> Trs { get; set; } = null!;
        public virtual DbSet<Tum> Ta { get; set; } = null!;
        public virtual DbSet<Versicherungsantrag> Versicherungsantrags { get; set; } = null!;
        public virtual DbSet<Versicherungsvorschlaege> Versicherungsvorschlaeges { get; set; } = null!;
        public virtual DbSet<Zahlungsweise> Zahlungsweises { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tvdb;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benutzter>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__Benutzte__4B26EFE6343DC26B");

                entity.ToTable("Benutzter");

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.Adresse).HasMaxLength(50);

                entity.Property(e => e.Benutztername).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Erstelungsdatum).HasColumnType("datetime");

                entity.Property(e => e.Nachname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Rolle).HasMaxLength(50);

                entity.Property(e => e.Vorname).HasMaxLength(50);
            });

            modelBuilder.Entity<Kunden>(entity =>
            {
                entity.HasKey(e => e.KId)
                    .HasName("PK__Kunden__746E9B41027373AD");

                entity.ToTable("Kunden");

                entity.Property(e => e.KId).HasColumnName("K_ID");

                entity.Property(e => e.Adresse).HasMaxLength(50);

                entity.Property(e => e.Anrede).HasMaxLength(50);

                entity.Property(e => e.Bankdaten).HasMaxLength(50);

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.Nachname).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Vorname).HasMaxLength(50);
            });

            modelBuilder.Entity<Tier>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("PK__Tier__83BB1FB27476291A");

                entity.ToTable("Tier");

                entity.Property(e => e.TId).HasColumnName("T_ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TrId).HasColumnName("TR_ID");

                entity.Property(e => e.VId).HasColumnName("V_ID");

                entity.HasOne(d => d.Tr)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.TrId)
                    .HasConstraintName("fk_TR");

                entity.HasOne(d => d.VIdNavigation)
                    .WithMany(p => p.Tiers)
                    .HasForeignKey(d => d.VId)
                    .HasConstraintName("fk_V1");
            });

            modelBuilder.Entity<Tr>(entity =>
            {
                entity.ToTable("TR");

                entity.Property(e => e.TrId).HasColumnName("TR_ID");

                entity.Property(e => e.Rasse).HasMaxLength(50);

                entity.Property(e => e.TaId).HasColumnName("TA_ID");

                entity.HasOne(d => d.Ta)
                    .WithMany(p => p.Trs)
                    .HasForeignKey(d => d.TaId)
                    .HasConstraintName("fk_AT");
            });

            modelBuilder.Entity<Tum>(entity =>
            {
                entity.HasKey(e => e.TaId)
                    .HasName("PK__TA__2F5D55506D35BB13");

                entity.ToTable("TA");

                entity.Property(e => e.TaId).HasColumnName("TA_ID");

                entity.Property(e => e.Tierart).HasMaxLength(50);
            });

            modelBuilder.Entity<Versicherungsantrag>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__Versiche__71AC6D41C6D3AF4A");

                entity.ToTable("Versicherungsantrag");

                entity.Property(e => e.AId).HasColumnName("A_ID");

                entity.Property(e => e.Antragsbeschreibung).HasMaxLength(255);

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.KId).HasColumnName("K_ID");

                entity.Property(e => e.VId).HasColumnName("V_ID");

                entity.Property(e => e.Versicherungsbeiträge).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.BIdNavigation)
                    .WithMany(p => p.Versicherungsantrags)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("fk_B1");

                entity.HasOne(d => d.KIdNavigation)
                    .WithMany(p => p.Versicherungsantrags)
                    .HasForeignKey(d => d.KId)
                    .HasConstraintName("fk_K");

                entity.HasOne(d => d.VIdNavigation)
                    .WithMany(p => p.Versicherungsantrags)
                    .HasForeignKey(d => d.VId)
                    .HasConstraintName("fk_V");
            });

            modelBuilder.Entity<Versicherungsvorschlaege>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("PK__Versiche__B35D77AC2D049AA5");

                entity.ToTable("Versicherungsvorschlaege");

                entity.Property(e => e.VId).HasColumnName("V_ID");

                entity.Property(e => e.BId).HasColumnName("B_ID");

                entity.Property(e => e.Beginn).HasColumnType("datetime");

                entity.Property(e => e.ZId).HasColumnName("Z_ID");

                entity.HasOne(d => d.BIdNavigation)
                    .WithMany(p => p.Versicherungsvorschlaeges)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("fk_B");

                entity.HasOne(d => d.ZIdNavigation)
                    .WithMany(p => p.Versicherungsvorschlaeges)
                    .HasForeignKey(d => d.ZId)
                    .HasConstraintName("fk_Z");
            });

            modelBuilder.Entity<Zahlungsweise>(entity =>
            {
                entity.HasKey(e => e.ZId)
                    .HasName("PK__Zahlungs__CA5FB3EAECF8C716");

                entity.ToTable("Zahlungsweise");

                entity.Property(e => e.ZId).HasColumnName("Z_ID");

                entity.Property(e => e.Zahlungsweise1)
                    .HasMaxLength(50)
                    .HasColumnName("Zahlungsweise");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
