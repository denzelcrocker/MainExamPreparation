﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Train;

public partial class ExapPreparationEfContext : DbContext
{
    public ExapPreparationEfContext()
    {
    }

    public ExapPreparationEfContext(DbContextOptions<ExapPreparationEfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Children> Childrens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = ngknn.ru; Database = ExapPreparationEF; User = 33П; Password = 12357; TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Children>(entity =>
        {
            entity.Property(e => e.Birthday).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
