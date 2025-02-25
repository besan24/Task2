using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Data
{
    public static class GlobalConstant
    {
        public readonly static string loginLink = "https://localhost:44349/Auth/Login";
        public readonly static string registerLink = "https://localhost:44349/Auth/RegisterUser";
        public readonly static string HerfaTestDataPath = "C:\\Users\\Alaa Smer\\Downloads\\HerfaTestData.xlsx";
        public readonly static string paymentLink = "https://localhost:44349/User/PayForTheOrder";
        public readonly static string UserLink = "https://localhost:44349/User";
        public readonly static string ShoppingCartLink = "https://localhost:44349/User/ShoppingCart";
        public static readonly string ConnectionString = "Server=LAPTOP-F8OJEBDA\\SQLEXPRESS;Database=HERFA SYSTEM;Integrated Security=True;Connect Timeout=60;";
        public static readonly string ImagesPath = "C:\\Users\\Alaa Smer\\Desktop\\Besan2\\Task2\\Data\\Imeges\\";
        public readonly static string HTMLReportPath = "C:\\Users\\Alaa Smer\\Desktop\\Besan2\\Task2\\Data\\HTMLReport\\";
    }
}