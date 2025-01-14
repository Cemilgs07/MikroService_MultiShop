namespace MultiShop.Discount.Dtos
{
    public class CreateDiscountCouponDto
    {
     
        public string CouponCode { get; set; }
        public int rate { get; set; }
        public bool Active { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
