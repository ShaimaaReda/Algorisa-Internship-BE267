using Azure;
using Core.Domain.Model;
using Core.IRepository;
using Core.IService.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<DiscountCoupon> _UserRepository;
        public CouponService(IRepository<DiscountCoupon> UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<bool> Add(DiscountCoupon entity)
        {
            try
            {
                if (entity != null)
                {
                    await _UserRepository.AddAsync(entity);
                    await _UserRepository.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Deactivate(Guid id)
        {
            try
            {
                var obj = await _UserRepository.GetAllWhereAsync(a=>a.Id==id); 
                var coupon = obj.FirstOrDefault();
                if (coupon != null)
                {
                    coupon.IsActive = false;
                    await _UserRepository.EditAsync(coupon);
                    await _UserRepository.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var obj = await _UserRepository.GetAllWhereAsync(w => w.Id == id);
                var coupon = obj.FirstOrDefault();
                if (coupon != null)
                {
                    await _UserRepository.DeleteAsync(coupon);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            };
        }

        public async Task<bool> Update(DiscountCoupon Model)
        {
            try
            {
                if (Model != null)
                {
                    await _UserRepository.EditAsync(Model);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
