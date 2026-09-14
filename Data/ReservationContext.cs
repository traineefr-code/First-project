using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {
        }

        public DbSet<ReservationDetails> Reservations { get; set; } = null!;
    }
}