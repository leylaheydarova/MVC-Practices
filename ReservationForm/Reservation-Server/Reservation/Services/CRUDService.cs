using Reservation.Contexts;
using Reservation.Models;
using Reservation.ViewModels;

namespace Reservation.Services
{
    public class CRUDService //Create, Delete, Update, GetById, GetAll
    {
        ReservationDbContext _context;

        public CRUDService(ReservationDbContext context)
        {
            _context = context;
        }

        public string CreateTourPackage(string cityname)
        {
            var package = new TourPackage()
            {
                CityName = cityname
            };
            _context.Add(package);
            var count = _context.SaveChanges();
            if (count == 0) return "Adding failed";
            return "Added succesfully!";
        }

        public List<TourPackage> GetAllPackages()
        {
            return _context.TourPackages.ToList();
        }

        public TourPackage GetTourPage(int id)
        {
            var package = _context.TourPackages.FirstOrDefault(t => t.Id == id);
            if (package is null) throw new Exception("Package not found");
            return package;
        }

        public DiscountCoupon GetDiscountByName(string coupon)
        {
            var discount = _context.DiscountCoupons.FirstOrDefault(d => d.Coupon == coupon);
            if (discount is null) throw new Exception("coupon not found!");
            return discount;
        }

        public string Reserve(ReservationViewModel model)
        {
            var customer = new Customer()
            {
                FullName = model.Fullname,
                Email = model.Email
            };
            _context.Customers.Add(customer);

            var coupon = _context.DiscountCoupons.FirstOrDefault(c => c.Coupon == model.Coupon);
            if (coupon is null) throw new Exception("coupon not found!");
            if (coupon.ExpireDate <= DateTime.UtcNow.AddHours(4)) throw new Exception("coupon expired!");

            var reservation = new UserReservation()
            {
                CustomerId = customer.Id,
                IsBoarding = model.IsBoarding,
                IsFooding = model.IsFooding,
                IsSightseeing = model.IsSightseeing,
                IsTermAccepted = model.IsTermAccepted,
                TourPackageId = model.TourPackageId,
                CouponId = coupon.Id,
            };
            _context.Reservations.Add(reservation);
            var count = _context.SaveChanges();
            if (count == 0) return "Reserve failed";
            return "Reservation succeeded";
        }
    }
}
