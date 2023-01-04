using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string BankCode { get; set; }
        public string BankTranNo { get; set; }
        public string CardType { get; set; }
        public int BillId { get; set; }
        public string PayDate { get; set; }
        public string Status { get; set; }
        public string TransactionNo { get; set; }

    }
}
