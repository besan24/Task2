//using Task2.Helpers;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Metadata;
//using System.Text;
//using System.Threading.Tasks;
//using Task2.POM;
////using Task2.Data;
//using Task2.Data;

//namespace Task2.TestMethods
//{
//    [TestClass]
//    public class Login_TestMethods
//    {
//        [TestMethod]
//        public void TestLoginForAdmin_ValidEmailAndPassword()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.loginLink);
//            Thread.Sleep(10000);

//            IWebElement email = ManageDriver.driver.FindElement(By.XPath("//div/input[@id='Email']"));
//            email.SendKeys("hebajardat@yahoo.com");

//            IWebElement password = ManageDriver.driver.FindElement(By.XPath("//div/input[@id='myPass1']"));
//            password.SendKeys("123456");

//            IWebElement submitButton = ManageDriver.driver.FindElement(By.XPath("//div/button[contains(text(), 'Login')]"));
//            submitButton.Click();

//            Thread.Sleep(3000);
//            string expectedURL = "https://localhost:44349/User";
//            string actualURL = ManageDriver.driver.Url;

//            Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the Expected URL");
//            Console.WriteLine("Test Case Completed Successfully");
//            ManageDriver.driver.Quit();
//        }

//        [TestMethod]
//        public void TestLogin_EmptyEmailAndPassword()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.loginLink);
//            Thread.Sleep(10000);

//            Login_POM login_POM = new Login_POM(ManageDriver.driver);
//            login_POM.EnterEmail("");
//            login_POM.EnterPassword("");
//            login_POM.ClickSubmitButton();


//            string expectedURL = GlobalConstant.loginLink;
//            string actualURL = ManageDriver.driver.Url;

//            Assert.AreEqual(actualURL, expectedURL);
//            Console.WriteLine("Test Case Completed Successfully");
//            ManageDriver.driver.Quit();

//        }

//        [TestMethod]
//        public void TestLogin_ValidEmailWithInvalidPassword()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.loginLink);
//            Thread.Sleep(10000);

//            Login_POM login_POM = new Login_POM(ManageDriver.driver);
//            login_POM.EnterEmail("hebajardat@yahoo.com");
//            login_POM.EnterPassword("123");
//            login_POM.ClickSubmitButton();
//            //IWebElement email = driver.FindElement(By.XPath("//div/input[@id='Email']"));
//            //email.SendKeys("AhmOmari@outlook.com");

//            //IWebElement password = driver.FindElement(By.XPath("//div/input[@id='myPass1']"));
//            //password.SendKeys("123");

//            //IWebElement submitButton = driver.FindElement(By.XPath("//div/button[contains(text(), 'Login')]"));
//            //submitButton.Click();

//            string expectedURL = GlobalConstant.loginLink;
//            string actualURL = ManageDriver.driver.Url;

//            Assert.AreEqual(actualURL, expectedURL);
//            Console.WriteLine("Test Case Completed Successfully");
//            ManageDriver.driver.Quit();
//        }
//    }
//}