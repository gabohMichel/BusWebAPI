using BusWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.DbContexts;

public partial class BusDBContext : DbContext
{
    public BusDBContext()
    {
    }

    public BusDBContext(DbContextOptions<BusDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatCategory> CatCategory { get; set; }

    public virtual DbSet<CatStatusBus> CatStatusBus { get; set; }

    public virtual DbSet<TabBus> TabBus { get; set; }

    public virtual DbSet<TabBusSchedule> TabBusSchedule { get; set; }

    public virtual DbSet<TabRoute> TabRoute { get; set; }

    public virtual DbSet<TabSeat> TabSeat { get; set; }

    public virtual DbSet<TabTicket> TabTicket { get; set; }

    public virtual DbSet<TabUser> TabUser { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GABRIEL;Initial Catalog=BusDB;User Id=sa;Password=Sql1234.;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CatCateg__3214EC074FFC13DA");

            entity.Property(e => e.Label).HasMaxLength(50);
        });

        modelBuilder.Entity<CatStatusBus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CatStatu__3214EC07CA408838");

            entity.Property(e => e.Label).HasMaxLength(50);
        });

        modelBuilder.Entity<TabBus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabBus__3214EC0718831237");

            entity.HasIndex(e => e.Plates, "UQ__TabBus__77C52A36BE793CE5").IsUnique();

            entity.Property(e => e.Plates)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TabBus)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__TabBus__IdCatego__49C3F6B7");

            entity.HasOne(d => d.IdStatusBusNavigation).WithMany(p => p.TabBus)
                .HasForeignKey(d => d.IdStatusBus)
                .HasConstraintName("FK__TabBus__IdStatus__3D5E1FD2");
        });

        modelBuilder.Entity<TabBusSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabBusSc__3214EC07B4F87BEE");

            entity.Property(e => e.ArrivingTime).HasColumnType("datetime");
            entity.Property(e => e.DepartureTime).HasColumnType("datetime");

            entity.HasOne(d => d.IdRouteNavigation).WithMany(p => p.TabBusSchedule)
                .HasForeignKey(d => d.IdRoute)
                .HasConstraintName("FK__TabBusSch__IdRou__403A8C7D");
        });

        modelBuilder.Entity<TabRoute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabRoute__3214EC07200BBB2D");

            entity.Property(e => e.ArrivingPoint)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeparturePoint)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabSeat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabSeat__3214EC07C6F3DD7F");

            entity.Property(e => e.Seat)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdTicketNavigation).WithMany(p => p.TabSeat)
                .HasForeignKey(d => d.IdTicket)
                .HasConstraintName("FK__TabSeat__IdTicke__46E78A0C");
        });

        modelBuilder.Entity<TabTicket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabTicke__3214EC0736E56C29");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdBusScheduleNavigation).WithMany(p => p.TabTicket)
                .HasForeignKey(d => d.IdBusSchedule)
                .HasConstraintName("FK__TabTicket__IdBus__440B1D61");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TabTicket)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__TabTicket__IdBus__4316F928");
        });

        modelBuilder.Entity<TabUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TabUser__3214EC07E0BEE380");

            entity.HasIndex(e => e.UserName, "UQ__TabUser__C9F2845621AFFE9E").IsUnique();

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
