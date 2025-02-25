using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Task2.POM;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Task2.Data;
using Task2.Helpers;
using Task2.AssistantMethods;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;

namespace Task2.TestMethods
{
    [TestClass]
    public class PaymentPageTest
    {
        public static ExtentReports extentReports = new ExtentReports();
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter(GlobalConstant.HTMLReportPath);

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            extentReports.AttachReporter(reporter);
            ManageDriver.MaximizeDriver();
            CommonMethods.NavigateToURL(GlobalConstant.loginLink);
            Login_POM login_POM = new Login_POM(ManageDriver.driver);
            login_POM.EnterEmail("hebajardat@yahoo.com");
            login_POM.EnterPassword("123456");
            login_POM.ClickSubmitButton();
            Thread.Sleep(3000);
            CommonMethods.NavigateToURL(GlobalConstant.ShoppingCartLink);
            Thread.Sleep(3000);
            Payment_AssistantMethods.ScrollToBottomAndClick();
            Thread.Sleep(3000);
        }
        [ClassCleanup]
        public static void ClassSetup()//بعد ال TestMethods
        {
            extentReports.Flush();
            ManageDriver.CloseDriver();
        }

        /// <summary>
        /// ////////TESTMETHODS
        /// </summary>
        [TestMethod]
        public void Test_ValidPayment()
        {
            var test = extentReports.CreateTest("Test Success Payment", "verify that the payment process works correctly when valid payment information is provided.");
            try
            {
                
                Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                Thread.Sleep(3000);
                Payment_AssistantMethods.PayButtonAndClick();
                Thread.Sleep(3000);

                Payment_Info payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(2);
                Payment_AssistantMethods.FillPaymentForm(payment);

                string expectedText = "The operation was performed successfully";
                string actualText = ManageDriver.driver.FindElement(By.XPath("//h5[@class='text-center' and text()='The operation was performed successfully']")).Text;

                Assert.IsTrue(Payment_AssistantMethods.CheckSuccessPayment(payment.CardNumber));
                Console.WriteLine($"Test Case completed Successfully");
                test.Pass("Test Case completed Successfully");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Error: Index was outside the bounds of the array. Details: {ex.Message}");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Error: Element not found. Details: {ex.Message}");
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine($"Error: Timeout occurred. Details: {ex.Message}");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                {
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                else
                {
                    Console.WriteLine("Browser session is not active, cannot take screenshot.");
                }
            }
        }



        [TestMethod]
        public void Test_InvalidCardHoldersName()
        {
            var test = extentReports.CreateTest("Verify Payment Failure with an Invalid Cardholder's Name", "ensures that the payment system correctly rejects transactions when an invalid card number is entered.");
            for (int i = 3; i <= 6; i++)
            {

                try
                {
                    Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                    CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                    Thread.Sleep(3000);
                    Payment_AssistantMethods.PayButtonAndClick();
                    Thread.Sleep(3000);

                    Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(i);
                    Payment_AssistantMethods.FillPaymentForm(Payment);

                    switch (i) 
                    {
                        case 3:
                            string expectedValidation0 = "the card info is incorrect";
                            string actualValidation0 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation0, actualValidation0);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;
                            
                        case 4:
                            string expectedValidation = "the card info is incorrect";
                            string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;
                            
                        case 5:
                            string expectedValidation2 = "the card info is incorrect";
                            string actualValidation2 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation2, actualValidation2);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;
                            
                        case 6:
                            string expectedValidation3 = "the card info is incorrect";
                            string actualValidation3 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation3, actualValidation3);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;
                        
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                    {
                        string screenShotPath = CommonMethods.TakeScreenShot();
                        test.AddScreenCaptureFromPath(screenShotPath);
                    }
                    else
                    {
                        Console.WriteLine("Browser session is not active, cannot take screenshot.");
                    }
                    Console.WriteLine($"Test Case {i} failed: {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void Test_InvalidCardNumber()
        {
            var test = extentReports.CreateTest("Verify Payment Failure with an Invalid Card Number", "verifies that the payment system does not accept transactions when the cardholder's name is invalid.");
            for (int i = 7; i <= 11; i++)
            {
                try
                {
                    
                    Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                    CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                    Thread.Sleep(3000);
                    Payment_AssistantMethods.PayButtonAndClick();
                    Thread.Sleep(3000);

                    Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(i);
                    Payment_AssistantMethods.FillPaymentForm(Payment);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)ManageDriver.driver;
                    string script = @"var elements = document.getElementsByTagName('*');
                       for (var i = 0; i < elements.length; i++)
                        { 
                       if (elements[i].textContent && elements[i].textContent.includes('the card info is incorrect'))
                        { 
                       return elements[i].outerHTML; 
                        }
                        }
                        return 'No matching element found';";

                    string result = (string)js.ExecuteScript(script);
                    Console.WriteLine("Found element with error message: " + result);

                    switch (i) 
                    {
                        case 7:
                            string expectedValidation0 = "the card info is incorrect";
                            string actualValidation0 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation0, actualValidation0);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 8:
                            string expectedValidation = "the card info is incorrect";
                            string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 9:
                            string expectedValidation2 = "the card info is incorrect";
                            string actualValidation2 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation2, actualValidation2);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 10:
                            string expectedValidation3 = "the card info is incorrect";
                            string actualValidation3 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation3, actualValidation3);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;
                        case 11:
                            string expectedValidation4 = "the card info is incorrect";
                            string actualValidation4 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation4, actualValidation4);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        default:
                            break;
                    } 
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                    {
                        string screenShotPath = CommonMethods.TakeScreenShot();
                        test.AddScreenCaptureFromPath(screenShotPath);
                    }
                    else
                    {
                        Console.WriteLine("Browser session is not active, cannot take screenshot.");
                    }
                    Console.WriteLine($"Test Case {i} failed: {ex.Message}");
                }

            }
        }

        [TestMethod]
        public void Test_InvalidCVV()
        {
            var test = extentReports.CreateTest("Verify Payment Failure with an Invalid CVV", "ensures that the payment system correctly rejects transactions when an invalid CVV is entered.");


            for (int i = 12; i <= 15; i++)
            {
                try
                {
                    
                    Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                    CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                    Thread.Sleep(3000);
                    Payment_AssistantMethods.PayButtonAndClick();
                    Thread.Sleep(3000);

                    Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(i);
                    Payment_AssistantMethods.FillPaymentForm(Payment);
                    switch (i) 
                    {
                        case 12:
                            string expectedValidation0 = "the card info is incorrect";
                            string actualValidation0 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation0, actualValidation0);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 13:
                            string expectedValidation = "the card info is incorrect";
                            string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 14:
                            string expectedValidation2 = "the card info is incorrect";
                            string actualValidation2 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation2, actualValidation2);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 15:
                            string expectedValidation3 = "the card info is incorrect";
                            string actualValidation3 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation3, actualValidation3);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                    {
                        string screenShotPath = CommonMethods.TakeScreenShot();
                        test.AddScreenCaptureFromPath(screenShotPath);
                    }
                    else
                    {
                        Console.WriteLine("Browser session is not active, cannot take screenshot.");
                    }
                }
            }
        }

        [TestMethod]
        public void Test_InvalidExpirationDate()
        {
            var test = extentReports.CreateTest("Verify Payment Failure with an Invalid Expiration Date", "ensures that the payment system correctly rejects transactions when an invalid expiration date is entered. ");


            for (int i = 16; i <= 17; i++)
            {

                try
                {
                    Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                    CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                    Thread.Sleep(3000);
                    Payment_AssistantMethods.PayButtonAndClick();
                    Thread.Sleep(3000);


                    Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(i);
                    Payment_AssistantMethods.FillPaymentForm(Payment);
                    switch (i) 
                    {
                        case 16:
                            string expectedValidation0 = "the card info is incorrect";
                            string actualValidation0 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation0, actualValidation0);
                            test.Pass("Test Case completed Successfully");

                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        case 17:
                            string expectedValidation = "the card info is incorrect";
                            string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                            Assert.AreEqual(expectedValidation, actualValidation); 
                            test.Pass("Test Case completed Successfully");
                            Console.WriteLine($"Test Case {i} completed Successfully");
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    test.Fail(ex.Message);
                    if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                    {
                        string screenShotPath = CommonMethods.TakeScreenShot();
                        test.AddScreenCaptureFromPath(screenShotPath);
                    }
                    else
                    {
                        Console.WriteLine("Browser session is not active, cannot take screenshot.");
                    }
                }
            }
        }

        [TestMethod]
        public void Test_Click_BackLink()
        {
            var test = extentReports.CreateTest("Verify Functionality of the Back Link on the Payment Page", "ensures that clicking the Backlink on the payment page correctly navigates the user back to the shopping cart.");

            try
            {
                Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                Thread.Sleep(3000);
                
                Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(18);

                Payment_AssistantMethods.FillPaymentForm1(Payment);
                Payment_AssistantMethods.BackLinkAndClick();

                string expectedUrl = "https://localhost:44349/User/ShoppingCart";
                string actualUrl = ManageDriver.driver.Url;
                Assert.AreEqual(expectedUrl, actualUrl, "Back link did not redirect to the expected page.");
                test.Pass("Test Case completed Successfully");
                Console.WriteLine("Test Click_BackLink completed Successfully");
            }
            catch (Exception ex)
            {
                test.Fail(ex.Message);
                if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                {
                    string screenShotPath = CommonMethods.TakeScreenShot();
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
                else
                {
                    Console.WriteLine("Browser session is not active, cannot take screenshot.");
                }
                Console.WriteLine($"Test Click_BackLink failed: {ex.Message}");
            }
        }

        [TestMethod]
        public void Test_InvalidCardHoldersName_InvalidCardNumber()
        {
            var test = extentReports.CreateTest("Verify Payment Failure with Invalid Cardholder Name and Invalid Card Number",
                "ensures that the payment form correctly validates both an invalid cardholder name and an invalid card number.");

            try
            {
                WebDriverWait wait = new WebDriverWait(ManageDriver.driver, TimeSpan.FromSeconds(10));

                for (int i = 19; i <= 21; i++)
                {
                    try
                    {

                        Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
                        CommonMethods.NavigateToURL(GlobalConstant.paymentLink);
                        Thread.Sleep(3000);
                        Payment_AssistantMethods.PayButtonAndClick();
                        Thread.Sleep(3000);

                        Payment_Info Payment = Payment_AssistantMethods.ReadPaymentDataFromExcel(i);
                        Payment_AssistantMethods.FillPaymentForm(Payment);
                        switch (i)
                        {
                            case 19:
                                string expectedValidation0 = "the card info is incorrect";
                                string actualValidation0 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                                Assert.AreEqual(expectedValidation0, actualValidation0);
                                test.Pass("Test Case completed Successfully");

                                Console.WriteLine($"Test Case {i} completed Successfully");
                                break;

                            case 20:
                                string expectedValidation = "the card info is incorrect";
                                string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                                Assert.AreEqual(expectedValidation, actualValidation);
                                test.Pass("Test Case completed Successfully");
                                Console.WriteLine($"Test Case {i} completed Successfully");
                                break;

                            case 21:
                                string expectedValidation2 = "the card info is incorrect";
                                string actualValidation2 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;
                                Assert.AreEqual(expectedValidation2, actualValidation2);
                                test.Pass("Test Case completed Successfully");

                                Console.WriteLine($"Test Case {i} completed Successfully");
                                break;
                            default:
                                break;
                        } 
                    }
                    catch (Exception ex)
                    {
                        test.Fail($"Test Case {i} failed: {ex.Message}\n{ex.StackTrace}");
                        if (ManageDriver.driver != null && ((IJavaScriptExecutor)ManageDriver.driver).ExecuteScript("return document.readyState").Equals("complete"))
                        {
                            test.AddScreenCaptureFromPath(CommonMethods.TakeScreenShot());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                test.Fail($"Unexpected error: {ex.Message}\n{ex.StackTrace}");
            }
            
        }




    }


}

    

