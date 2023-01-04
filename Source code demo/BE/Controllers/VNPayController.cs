using SneakerShop.IService.VNPay;
using SneakerShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly IVNPayService _vnpayService;
        public VNPayController(IVNPayService vNPayService)
        {
            this._vnpayService = vNPayService;
        }

        [HttpPost]
        public string Post([FromBody] OrderInfo order)
        {
            return this._vnpayService.CreateOrder(order);
        }
    }
}
