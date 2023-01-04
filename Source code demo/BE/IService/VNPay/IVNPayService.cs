using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.IService.VNPay
{
    public interface IVNPayService
    {
        string CreateOrder(OrderInfo orderInfo);
    }
}
