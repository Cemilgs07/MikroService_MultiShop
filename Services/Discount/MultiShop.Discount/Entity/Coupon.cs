namespace MultiShop.Discount.Entity
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponCode{ get; set; }
        public int rate{ get; set; }
        public bool Active{ get; set; }
        public DateTime ValidDate{ get; set; }
    }
}
