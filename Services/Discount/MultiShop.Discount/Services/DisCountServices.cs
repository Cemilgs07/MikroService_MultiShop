using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DisCountServices : IDiscountServices
    {
        private readonly DapperContext _context;

        public DisCountServices(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponCode,rate,Active,ValidDate) values (@CouponCode,@rate,@Active,@ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode",createCouponDto.CouponCode);
            parameters.Add("@rate", createCouponDto.rate);
            parameters.Add("@Active", createCouponDto.Active);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "Delete From Coupons where CouponId=@CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("CouponId",id);
            using (var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
               var values=  await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId ";
             var parameters= new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdDiscountCouponDto>(query, parameters);

                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UptadeDiscountCouponDto uptadeCouponDto)
        {
            string query = "UPDATE Coupons SET CouponCode = @couponCode, rate = @rate, Active = @active, ValidDate = @validate WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponCode", uptadeCouponDto.CouponCode);
            parameters.Add("rate", uptadeCouponDto.rate);
            parameters.Add("active", uptadeCouponDto.Active);
            parameters.Add("validate", uptadeCouponDto.ValidDate);
            parameters.Add("couponId", uptadeCouponDto.CouponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
