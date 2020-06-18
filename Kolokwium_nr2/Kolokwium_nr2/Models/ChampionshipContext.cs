using Microsoft.EntityFrameworkCore;

namespace Kolokwium_nr2.Models
{
    public class ChampionshipContext : DbContext
    {

        public ChampionshipContext()
        {

        }

        public ChampionshipContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Championship> Championships { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(k => k.IdPlayer);
                opt.Property(k => k.IdPlayer).ValueGeneratedOnAdd();

                opt.Property(m => m.FirstName).HasMaxLength(30).IsRequired();
                opt.Property(m => m.LastName).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(k => k.IdChampionship);
                opt.Property(k => k.IdChampionship).ValueGeneratedOnAdd();

                opt.Property(m => m.OfficialName).HasMaxLength(100).IsRequired();
                
            });

            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(k => k.IdTeam);
                opt.Property(k => k.IdTeam).ValueGeneratedOnAdd();

                opt.Property(m => m.TeamName).HasMaxLength(30).IsRequired();

            });


            modelBuilder.Entity<ChampionshipTeam>(opt =>
            {
                opt.HasKey(k => k.IdTeam);
                opt.HasKey(k => k.IdChampionship);

                opt.HasOne(m => m.Championship).WithMany(m => m.ChampionshipTeams).HasForeignKey(k => k.IdChampionship);
                opt.HasOne(m => m.Team).WithMany(m => m.ChampionshipTeams).HasForeignKey(k => k.IdTeam);

                opt.ToTable("Championship_Team");

            });


            modelBuilder.Entity<PlayerTeam>(opt =>
            {
                opt.HasKey(k => k.IdPlayer);
                opt.HasKey(k => k.IdTeam);

                opt.Property(m => m.Comment).HasMaxLength(300);

                opt.HasOne(m => m.Team).WithMany(m => m.PlayerTeams).HasForeignKey(k => k.IdTeam);
                opt.HasOne(m => m.Player).WithMany(m => m.PlayerTeams).HasForeignKey(k => k.IdPlayer);

                opt.ToTable("Player_Team");

            });


        }


    }
}
