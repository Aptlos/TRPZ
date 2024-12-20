﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ReportContext : DbContext
{
    public DbSet<Reason> Phones { get; set; }
    public DbSet<Report> Orders { get; set; }
    public ReportContext(DbContextOptions options)
        : base(options)
    {
    }
}