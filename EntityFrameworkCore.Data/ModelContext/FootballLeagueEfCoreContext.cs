using System;
using System.Collections.Generic;
using EntityFrameworkCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data.ModelContext;

public partial class FootballLeagueEfCoreContext : DbContext
{
    public FootballLeagueEfCoreContext()
    {
    }

    public FootballLeagueEfCoreContext(DbContextOptions<FootballLeagueEfCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamsCoachesLeague> TeamsCoachesLeagues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FootballLeague_EfCore;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Audit__3214EC07B0B3BBD9");

            entity.ToTable("Audit");

            entity.Property(e => e.Action).HasMaxLength(255);
            entity.Property(e => e.DateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TableName).HasMaxLength(255);
        });

        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coach__3214EC071F90CEF4");

            entity.ToTable("Coach");

            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Team).WithMany(p => p.Coaches)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_Coach_Team");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__League__3214EC07D4D8371B");

            entity.ToTable("League");

            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Match__3214EC07534CBA4D");

            entity.ToTable("Match");

            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TicketPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.MatchAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_AwayTeam");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.MatchHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Match_HomeTeam");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Team__3214EC072150C312");

            entity.ToTable("Team");

            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.League).WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_League");
        });

        modelBuilder.Entity<TeamsCoachesLeague>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TeamsCoachesLeague");

            entity.Property(e => e.CoachName).HasMaxLength(255);
            entity.Property(e => e.LeagueName).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
