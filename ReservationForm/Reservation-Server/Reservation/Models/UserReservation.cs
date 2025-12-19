using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Models
{
    public class UserReservation
    {
        public int Id { get; set; }
        public bool IsBoarding { get; set; }
        public bool IsFooding { get; set; }
        public bool IsSightseeing { get; set; }
        public bool IsTermAccepted { get; set; }
        //Foreign keys
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int TourPackageId { get; set; }
        public TourPackage TourPackage { get; set; }
        public int CouponId { get; set; }
        public DiscountCoupon Coupon { get; set; }

    }
}
