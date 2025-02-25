using Bytescout.Spreadsheet;
using Task2.Data;
using Task2.Helpers;
using System;
using System.Threading;
using Task2.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Oracle.ManagedDataAccess.Client;
using OpenQA.Selenium.Interactions;

namespace Task2.AssistantMethods
{
    public class Payment_AssistantMethods
    {
        private IWebDriver driver;
        private string email;
        private string password;


        public void PerformPayment(Payment_Info paymentInfo)
        {
            try
            {
                if (driver == null)
                {
                    throw new Exception("WebDriver session is not active.");
                }

                CommonMethods.NavigateToURL(GlobalConstant.paymentLink);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 2);");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                By payButton = By.XPath("//button[contains(text(), 'Pay')]");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(payButton));
                FillPaymentForm(paymentInfo);

                driver.FindElement(payButton).Click();

                wait.Until(d => d.FindElement(By.XPath("//div[contains(text(), 'Payment successful')]")));
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error in PerformPayment: {ex.Message}");
                throw;
            }
        }



        public static void PayButtonAndClick()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)ManageDriver.driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 2);");
            Thread.Sleep(4000); 

        
            WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));
            By payButton = By.XPath("//button[contains(text(), 'Pay')]");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(payButton));

            ManageDriver.driver.FindElement(payButton).Click();
        }
        

        public static void ScrollToBottomAndClick()
        {
            try
            {
                
                IJavaScriptExecutor js = (IJavaScriptExecutor)ManageDriver.driver;
                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 2);");

                Thread.Sleep(2000);  

                
                WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));
                By checkButton = By.XPath("//a[contains(text(), 'Checkout')]");
                IWebElement button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(checkButton));

               
                if (!button.Displayed || !button.Enabled)
                {
                    Console.WriteLine(" Checkout button is not visible or clickable.");
                    return;
                }

                
                Actions actions = new Actions(ManageDriver.driver);
                actions.MoveToElement(button).Click().Perform();  
                Thread.Sleep(5000);  
                Console.WriteLine("Checkout button clicked successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error in ScrollToBottomAndClick: {ex.Message}");
                throw;
            }
        }

        public static void FillPaymentForm(Payment_Info paymentInfo)
        {
            try
            {
                Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));

                payment_POM.EnterCardholderName("");
                wait.Until(d => payment_POM.IsCardholderNameEmpty());
                payment_POM.EnterCardholderName(paymentInfo.CardHolderName);

   
                payment_POM.EnterCardNumber("");
                wait.Until(d => payment_POM.IsCardNumberEmpty());
                payment_POM.EnterCardNumber(paymentInfo.CardNumber);

     
                payment_POM.EnterCVV("");
                wait.Until(d => payment_POM.IsCVVEmpty());
                payment_POM.EnterCVV(paymentInfo.CVV);

                SetExpirationDate(payment_POM, paymentInfo.ExpirationDate);

           
                payment_POM.SetRememberMe(paymentInfo.RememberMe);

           
                payment_POM.ClickPayButton();

                wait.Until(d => payment_POM.IsPaymentSuccessful());

                Console.WriteLine("FillPaymentForm executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FillPaymentForm: {ex.Message}");
            }
        }
        public static void BackLinkAndClick()
        {
            WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));
            By Backlink = By.XPath("//a[@href='/User/ShoppingCart']");

            try
            {
                IReadOnlyCollection<IWebElement> elements = ManageDriver.driver.FindElements(Backlink);
                if (elements.Count == 0)
                {
                    Console.WriteLine("Back link is not found on the page! Printing page source...");
                    Console.WriteLine(ManageDriver.driver.PageSource);
                    return;
                }

                IWebElement backLinkElement = ManageDriver.driver.FindElement(Backlink);
                Console.WriteLine("Back link Displayed: " + backLinkElement.Displayed);
                Console.WriteLine("Back link Enabled: " + backLinkElement.Enabled);
                Console.WriteLine("Back link Location: " + backLinkElement.Location);
                Console.WriteLine("Back link Size: " + backLinkElement.Size);

                WebDriverWait waitForPage = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));
                waitForPage.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)ManageDriver.driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", backLinkElement);
                Thread.Sleep(1000);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(backLinkElement));

                js.ExecuteScript("arguments[0].click();", backLinkElement);

                Console.WriteLine("Clicked on Back Link");
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in BackLinkAndClick: {ex.Message}");
            }
        }




        public static void FillPaymentForm1(Payment_Info paymentInfo)
        {
            try
            {
                Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(30));

                payment_POM.EnterCardholderName("");
                wait.Until(d => payment_POM.IsCardholderNameEmpty());
                payment_POM.EnterCardholderName(paymentInfo.CardHolderName);

                payment_POM.EnterCardNumber("");
                wait.Until(d => payment_POM.IsCardNumberEmpty());
                payment_POM.EnterCardNumber(paymentInfo.CardNumber);

                payment_POM.EnterCVV("");
                wait.Until(d => payment_POM.IsCVVEmpty());
                payment_POM.EnterCVV(paymentInfo.CVV);
                SetExpirationDate(payment_POM, paymentInfo.ExpirationDate);

                payment_POM.SetRememberMe(paymentInfo.RememberMe);

                Console.WriteLine(" click Back Link");
                BackLinkAndClick();

                Console.WriteLine("Return to shopping page");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in FillPaymentForm1: {ex.Message}");
            }
        }


        private static void SetExpirationDate(Payment_POM payment_POM, string expirationDate)
        {
            try
            {
                string[] dateParts = expirationDate.Split('-');
                if (dateParts.Length == 2)
                {
                    string expiryYear = dateParts[0];
                    string expiryMonth = dateParts[1];
                    payment_POM.EnterexpireDateField(expiryYear, expiryMonth);
                }
                else
                {
                    throw new Exception("Format of ExpirationDate is incorrect. Expected format: YYYY-MM");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting expiration date: {ex.Message}");
                throw;
            }
        }
        public static Payment_Info ReadPaymentDataFromExcel(int row)
        {
            try
            {
                Worksheet paymentWorkSheet = CommonMethods.ReadExcelPayment("Payment");

                Payment_Info paymentInfo = new Payment_Info
                {
                    CardHolderName = Convert.ToString(paymentWorkSheet.Cell(row, 2).Value),
                    CardNumber = Convert.ToString(paymentWorkSheet.Cell(row, 3).Value),
                    CVV = Convert.ToString(paymentWorkSheet.Cell(row, 4).Value),
                    ExpirationDate = Convert.ToString(paymentWorkSheet.Cell(row, 5).Value),
                    RememberMe = Convert.ToBoolean(paymentWorkSheet.Cell(row, 7).Value),
                    HasBackLink = Convert.ToBoolean(paymentWorkSheet.Cell(row, 8).Value)
                };

                return paymentInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from Excel for row {row}: {ex.Message}");
                throw;
            }
        }

     
        public static bool CheckSuccessPayment(string AVAILABLEBALANCE)
        {
            try
            {
                bool isPaymentSuccess = false;
                using (OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString))
                {
                    oracleConnection.Open();

                    string query = "  select count(*) from BANKVISA_FP where AVAILABLEBALANCE= :value";
                    using (OracleCommand command = new OracleCommand(query, oracleConnection))
                    {
                        command.Parameters.Add(new OracleParameter(":value", AVAILABLEBALANCE));
                        int result = Convert.ToInt32(command.ExecuteScalar());
                        isPaymentSuccess = result > 0;
                    }
                }
                return isPaymentSuccess;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error checking payment success for card {AVAILABLEBALANCE}: {ex.Message}");
                return false;
            }
        }
    }
}






//using Bytescout.Spreadsheet;
//using Task2.Data;
//using Task2.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Task2.POM;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System.Threading;
//using OpenQA.Selenium.Support.UI;
//using Oracle.ManagedDataAccess.Client;

//namespace Task2.AssistantMethods
//{
//    public class Payment_AssistantMethods
//    {
//        // طريقة لملء نموذج الدفع
//        public static void FillPaymentForm(Payment_Info paymentInfo)
//        {
//            try
//            {
//                Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);

//                // إدخال بيانات الدفع
//                payment_POM.EnterCardholderName(paymentInfo.CardHolderName);
//                Thread.Sleep(2000); // انتظار 2 ثوانٍ لضمان إدخال البيانات
//                payment_POM.EnterCardNumber(paymentInfo.CardNumber);
//                Thread.Sleep(2000);
//                payment_POM.EnterCVV(paymentInfo.CVV);
//                Thread.Sleep(2000);

//                // تقسيم تاريخ الانتهاء إلى سنة وشهر
//                string[] dateParts = paymentInfo.ExpirationDate.Split('-'); // يفترض أن التنسيق هو "YYYY-MM"
//                string expiryYear = dateParts[0];  // السنة
//                string expiryMonth = dateParts[1]; // الشهر
//                payment_POM.EnterexpireDateField(expiryYear, expiryMonth);
//                Thread.Sleep(2000);

//                payment_POM.SetRememberMe(paymentInfo.RememberMe);

//                // النقر على زر الدفع
//                payment_POM.ClickPayButton();
//                Thread.Sleep(5000); // انتظار 5 ثوانٍ لرؤية النتيجة
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error in FillPaymentForm: {ex.Message}");
//                throw; // إعادة رمي الاستثناء بعد تسجيله
//            }
//        }

//        // طريقة لقراءة بيانات الدفع من ملف Excel
//        public static Payment_Info ReadPaymentDataFromExcel(int row)
//        {
//            try
//            {
//                // التأكد من تحميل البيانات من ورقة العمل الصحيحة
//                Worksheet paymentWorkSheet = CommonMethods.ReadExcelPayment("Payment");

//                Payment_Info paymentInfo = new Payment_Info();
//                paymentInfo.CardHolderName = Convert.ToString(paymentWorkSheet.Cell(row, 2).Value);
//                paymentInfo.CardNumber = Convert.ToString(paymentWorkSheet.Cell(row, 3).Value);
//                paymentInfo.CVV = Convert.ToString(paymentWorkSheet.Cell(row, 4).Value);
//                paymentInfo.ExpirationDate = Convert.ToString(paymentWorkSheet.Cell(row, 5).Value);
//                paymentInfo.RememberMe = Convert.ToBoolean(paymentWorkSheet.Cell(row, 7).Value);
//                paymentInfo.HasBackLink = Convert.ToBoolean(paymentWorkSheet.Cell(row, 8).Value);

//                return paymentInfo;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"❌ Error reading data from Excel for row {row}: {ex.Message}");
//                throw; // إعادة رمي الاستثناء بعد تسجيله
//            }
//        }


//        // طريقة للتحقق من نجاح عملية الدفع
//        public static bool CheckSuccessPayment(string cardNumber)
//        {
//            try
//            {
//                bool isPaymentSuccess = false;

//                // الاتصال بقاعدة البيانات للتحقق من نجاح العملية
//                OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString);
//                oracleConnection.Open();

//                string query = "select count(*) from payments where card_number = :value";
//                OracleCommand command = new OracleCommand(query, oracleConnection);
//                command.Parameters.Add(new OracleParameter(":value", cardNumber));
//                int result = Convert.ToInt32(command.ExecuteScalar()); // 0 or 1
//                isPaymentSuccess = result > 0;

//                return isPaymentSuccess;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error checking payment success for card {cardNumber}: {ex.Message}");
//                return false; // في حالة حدوث خطأ، نعيد قيمة false
//            }
//        }
//    }
//}
