using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TicTacToe.Utils;

namespace TicTacToe.Models.Context
{
    public class TicTacToeContext : DbContext
    {
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        public TicTacToeContext(DbContextOptions<TicTacToeContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasIndex(t => t.RoomCode).IsUnique(true);
            var roomMB = modelBuilder.Entity<Room>();
            roomMB.ToTable("rooms");
            roomMB.HasKey(t => t.Id);
            roomMB.Property(t => t.Id)
                .HasColumnType("int")
                .HasColumnName("id")
                .IsRequired(true);
            
            roomMB.Property(t => t.RoomCode)
                .HasColumnType("varchar(255)")
                .HasColumnName("room_code")
                .IsRequired(true);

            roomMB.Property(t => t.Creator)
                .HasColumnType("varchar(255)")
                .HasColumnName("creator");
            
            roomMB.Property(t => t.Created)
                .HasColumnType("datetime")
                .HasColumnName("created")
                .HasDefaultValue(DateTime.UtcNow);
            
            roomMB.Property(t => t.Winner)
                .HasColumnType("varchar(255)")
                .HasColumnName("winner")
                .IsRequired(false);

            roomMB.Property(t => t.CurrentTurnTeam)
                .HasColumnType("varchar(255)")
                .HasColumnName("current_turn_team")
                .IsRequired(false);

            roomMB.Property(t => t.PlayersInRoom)
                .HasColumnType("text")
                .HasColumnName("players_in_room")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)
                )
                .HasDefaultValue(new Dictionary<string, string>()
                {
                    {GameTeam.TEAM_X, "" },
                    {GameTeam.TEAM_O, "" }
                });

            roomMB.Property(t => t.GameArea)
               .HasColumnType("text")
               .HasColumnName("game_area")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<int, string>>(v)
                )
               .HasDefaultValue(new Dictionary<int, string>()
               {
                    {1, "" },
                    {2, "" },
                    {3, "" },
                    {4, "" },
                    {5, "" },
                    {6, "" },
                    {7, "" },
                    {8, "" },
                    {9, "" }
               });
        }
    }
}