using SneakerShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly SneakerShopDbContext _context;

        public DeliveryController(SneakerShopDbContext context)
        {
            _context = context;
        }

        [HttpGet("ViettelPost/ListOrder")]
        public ViettelPostResponse GetListCreatedOrder()
        {
            var client = new RestClient("https://api.viettelpost.vn/api/supperapp/orderByStatusWeb");
            //client.Timeout = -1;
            var request = new RestRequest("", Method.Post);
            //var request = new RestRequest();  1233333
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("connection", "keep-alive");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("origin", "https://viettelpost.vn");
            request.AddHeader("referer", "https://viettelpost.vn/");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 Edg/108.0.1462.46");
            request.AddHeader("sec-ch-ua", "\"Not?A_Brand\"; v = \"8\", \"Chromium\"; v = \"108\", \"Microsoft Edge\"; v = \"108\"");          
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("token", "eyJhbGciOiJFUzI1NiJ9.eyJzdWIiOiIwOTA1MTcxMzcwIiwiU1NPSWQiOiIzMjEyZTkzNC0yMmVkLTQ1YjMtOThjNy01MmYyY2ZjZTRiZjAiLCJVc2VySWQiOjk2MTQyNzEsIkZyb21Tb3VyY2UiOjMsIlRva2VuIjoiQjIyQTNGODk3QzU5RUI5RUYwODNBNTc0NEEwNkY1Q0UiLCJleHAiOjE3MDIzNzE2MDUsIlBhcnRuZXIiOjB9.f-9lK7D6c4GoE24GwWe7PJvYVBqotcHb9ePulsv2KXw-QdQcHBOi7jgAhtaswutjGo65I3IB8hBqMuPAP1FXNA");
            request.AddHeader("traceparent", "00-f5f0d85768693f59fe5ce505485ec99e-fb8cbd77123f4efe-01");

            var jsonBody = "{\"TYPE\":0,\"INVENTORY\":-1,\"ORDER505\":-1,\"STATUS\":\"-100,-101,-102,-108,-109,-110,100,102,103,104,105,107,200,201,202,300,301,302,303,320,400,500,501,502,503,504,505,506,507,508,509,515,550,551,570\",\"DATE_TO\":\"15/12/2022\",\"DATE_FROM\":\"02/12/2022\",\"PAGE_INDEX\":1,\"PAGE_SIZE\":10,\"OTHER_PROPERTIES\":\"\",\"ORDER_PAYMENT\":\"\",\"deviceId\":\"34ffumako51vzqoz8ig16g\"}";
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response = client.Execute(request);
            var viettelPostResponse = JsonConvert.DeserializeObject<ViettelPostResponse>(response.Content);
            return viettelPostResponse;
        }

        [HttpGet("ViettelPost/CheckOrderCreated")]
        public bool CheckCreatedOrder(int billId)
        {
            var viettelPostResponse = GetListCreatedOrder();
            var listCreatedOrder = viettelPostResponse.Data.data;

            foreach (var order in listCreatedOrder)
            {
                var ID = order.ORDER_NOTE.Replace("ID:", "");
                if (billId == Convert.ToInt32(ID))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
