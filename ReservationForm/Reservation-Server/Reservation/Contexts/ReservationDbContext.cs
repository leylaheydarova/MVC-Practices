using Microsoft.EntityFrameworkCore;
using Reservation.Models;

namespace Reservation.Contexts
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserReservation> Reservations { get; set; }
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        {
        }
    }
}
