using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Data;

namespace Task2.Data
{
    public class Payment_Info
    {
        public Payment_Info(string cardNumber = "", string cardHolderName = "", string expirationDate = "", string cvv = "", bool rememberMe = false, bool BackLink = false)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
            CVV = cvv;
            RememberMe = rememberMe;
            HasBackLink = BackLink;
        }

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public bool RememberMe { get; set; }
        public bool HasBackLink { get; set; } 

        public void SetExpirationDate(string year, string month)
        {
           
            ExpirationDate = $"{year}-{month.PadLeft(2, '0')}";
        }
        public (string Year, string Month) GetExpirationDateParts()
        {
            var parts = ExpirationDate.Split('-');
            string year = parts.Length > 0 ? parts[0] : "";
            string month = parts.Length > 1 ? parts[1] : "";
            return (year, month);
        }
    }
}

