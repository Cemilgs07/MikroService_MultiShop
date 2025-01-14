namespace MultiShop.Discount.Dtos
{
    public class UptadeDiscountCouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int rate { get; set; }
        public bool Active { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
