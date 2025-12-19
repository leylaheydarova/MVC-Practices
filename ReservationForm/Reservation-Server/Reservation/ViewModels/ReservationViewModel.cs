using System.ComponentModel.DataAnnotations;

namespace Reservation.ViewModels
{
    public class ReservationViewModel
    {
        public string Fullname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int TourPackageId { get; set; }
        public bool IsBoarding { get; set; }
        public bool IsFooding { get; set; }
        public bool IsSightseeing { get; set; }
        [Required(ErrorMessage = "Terms must be accepted!")]
        public bool IsTermAccepted { get; set; }
        public string Coupon { get; set; }
    }
}
