using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OncologyCore.Model;

public partial class OncologyReceiptsContext : DbContext
{
    public OncologyReceiptsContext()
    {
    }

    public OncologyReceiptsContext(DbContextOptions<OncologyReceiptsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cycle> Cycles { get; set; }

    public virtual DbSet<CycleItem> CycleItems { get; set; }

    public virtual DbSet<Diagnostic> Diagnostics { get; set; }

    public virtual DbSet<Medicament> Medicaments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TreatmentItem> TreatmentItems { get; set; }

    public virtual DbSet<__MigrationHistory> __MigrationHistories { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cycle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Cycles");

            entity.HasIndex(e => e.DiagnosticId, "IX_DiagnosticId");

            entity.HasIndex(e => e.TreatmentId, "IX_TreatmentId");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Diagnostic).WithMany(p => p.Cycles)
                .HasForeignKey(d => d.DiagnosticId)
                .HasConstraintName("FK_dbo.Cycles_dbo.Diagnostics_DiagnosticId");

            entity.HasOne(d => d.Treatment).WithMany(p => p.Cycles)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Cycles_dbo.Treatments_TreatmentId");
        });

        modelBuilder.Entity<CycleItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.CycleItems");

            entity.HasIndex(e => e.CycleId, "IX_CycleId");

            entity.HasIndex(e => e.MedicamentId, "IX_MedicamentId");

            entity.HasIndex(e => e.TreatmentItemId, "IX_TreatmentItemId");

            entity.HasOne(d => d.Cycle).WithMany(p => p.CycleItems)
                .HasForeignKey(d => d.CycleId)
                .HasConstraintName("FK_dbo.CycleItems_dbo.Cycles_CycleId");

            entity.HasOne(d => d.Medicament).WithMany(p => p.CycleItems)
                .HasForeignKey(d => d.MedicamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.CycleItems_dbo.Medicaments_MedicamentId");

            entity.HasOne(d => d.TreatmentItem).WithMany(p => p.CycleItems)
                .HasForeignKey(d => d.TreatmentItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.CycleItems_dbo.TreatmentItems_TreatmentItemId");
        });

        modelBuilder.Entity<Diagnostic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Diagnostics");

            entity.HasIndex(e => e.PatientId, "IX_PatientId");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Localization).HasMaxLength(200);

            entity.HasOne(d => d.Patient).WithMany(p => p.Diagnostics)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_dbo.Diagnostics_dbo.Patients_PatientId");
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Medicaments");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Patients");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CNP).HasMaxLength(13);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Treatments");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TreatmentItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.TreatmentItems");

            entity.HasIndex(e => e.MedicamentId, "IX_MedicamentId");

            entity.HasIndex(e => e.TreatmentId, "IX_TreatmentId");

            entity.Property(e => e.Description).HasMaxLength(300);

            entity.HasOne(d => d.Medicament).WithMany(p => p.TreatmentItems)
                .HasForeignKey(d => d.MedicamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TreatmentItems_dbo.Medicaments_MedicamentId");

            entity.HasOne(d => d.Treatment).WithMany(p => p.TreatmentItems)
                .HasForeignKey(d => d.TreatmentId)
                .HasConstraintName("FK_dbo.TreatmentItems_dbo.Treatments_TreatmentId");
        });

        modelBuilder.Entity<__MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
