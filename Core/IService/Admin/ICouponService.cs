using Core.Domain.Model;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.Admin
{
    public interface ICouponService
    {
        Task<bool> Add(DiscountCoupon Model);
        Task<bool> Delete(Guid id);
        Task<bool> Update(DiscountCoupon Model);
        Task<bool> Deactivate(Guid id);
    }
}
