using Core.Domain.Model;
using Core.IService.Admin;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Algoriza_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponSettingController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponSettingController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost(nameof(AddCoupon))]
        public IActionResult AddCoupon([FromBody] CouponModel coupon)
        {
            if (coupon != null)
            {
                var Model = new DiscountCoupon
                {
                    DiscountCode = coupon.DiscountCode,
                    Value = coupon.Value,
                    IsActive = coupon.IsActive,
                    discount = (DiscountType)Enum.Parse(typeof(DiscountType), coupon.Discount)
                };
                var check = _couponService.Add(Model);

                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPut(nameof(UpdateCoupon))]
        public IActionResult UpdateCoupon([FromBody] CouponModel coupon)
        {
            if (coupon != null)
            {
                var Model = new DiscountCoupon
                {
                    Id = (Guid)coupon.Id,
                    DiscountCode = coupon.DiscountCode,
                    Value = coupon.Value,
                    IsActive = coupon.IsActive,
                    discount = (DiscountType)Enum.Parse(typeof(DiscountType), coupon.Discount)
                };
                _couponService.Update(Model);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCoupon(Guid id)
        {
            if (id != null)
            {
                _couponService.Delete(id);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete(nameof(DeactivateCoupon))]
        public async Task<IActionResult> DeactivateCoupon([FromQuery]Guid id)
        {
            if (id != null)
            {
                await _couponService.Deactivate(id);
                return Ok("Deactive Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
