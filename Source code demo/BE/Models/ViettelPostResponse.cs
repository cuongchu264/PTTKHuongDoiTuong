using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakerShop.Models
{
    public class ViettelPostResponse
    {
        public int Status { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalElements { get; set; }
        public List<DataResponse> data { get; set; }
    }

    public class DataResponse
    {
        public int RN { get; set; }
        public int CUS_ID { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string ORDER_REFERENCE { get; set; }
        public int ORDER_STATUS { get; set; }
        public string ORDER_SYSTEMDATE { get; set; }
        public string RECEIVER_FULLNAME { get; set; }
        public string RECEIVER_ADDRESS { get; set; }
        public string RECEIVER_PHONE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public int MONEY_COLLECTION { get; set; }
        public int TOTAL { get; set; }
        public int ORDER_ACTION_505 { get; set; }
        public string SENDER_FULLNAME { get; set; }
        public string COLOR_STATUS { get; set; }
        public string MONEY_TOTAL { get; set; }
        public int ORDER_TYPE { get; set; }
        public string ORDER_SERVICE { get; set; }
        public int IS_RETURN { get; set; }
        public int IS_RESEND { get; set; }
        public bool IS_SPLIT_PACKAGE { get; set; }
        public bool EDIT_INFO { get; set; }
        public int IS_EDIT { get; set; }
        public string ORDER_NOTE { get; set; }
    }
}
