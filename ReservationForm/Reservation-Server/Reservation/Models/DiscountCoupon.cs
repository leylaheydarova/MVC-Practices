namespace Reservation.Models
{
    public class DiscountCoupon
    {
        public int Id { get; set; }
        public string Coupon { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
