﻿using Auth.API.Entities;
using Auth.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data;

/// <summary>
/// AuthDbContext is a class that inherits from DbContext. 
/// It represents the database context for the authentication system.
/// </summary>
public class AuthDbContext : DbContext
{

    /// <summary>
    /// Initializes a new instance of the AuthDbContext class.
    /// </summary>
    /// <param name="options">The options to be used by a DbContext.</param>
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
    : base(options)
    { }

    /// <summary>
    /// A DbSet of SystemUser entities.
    /// </summary>
    public DbSet<SystemUser> SystemUsers { get; set; }

    /// <summary>
    /// Overrides OnModelCreating method to configure the model creating process.
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder instance to be used for model creating.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SystemUser>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<SystemUser>()
            .HasKey(u => u.Guid);

        modelBuilder.Entity<SystemUser>().HasData(
            new SystemUser(
                id: Guid.Parse("e5c54eb6-18b5-4442-8e31-b023c9b72add"),
                firstName: "Mladen",
                lastName: "Draganović",
                username: "mdraganov",
                password: "sifra",
                role: SystemUserRole.Admin
                )
        );
    }
}
