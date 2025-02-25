//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Task2.POM;
//using Task2.Helpers;
//using Task2.Data;
//using Task2.AssistantMethods;

//namespace Task2.TestMethods
//{
//    [TestClass]
//    public class Register_TestMethods
//    {
//        [TestMethod]
//        public void TestRegister_validData()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.registerLink);
//            Thread.Sleep(7000);

//            User user = Register_AssistantMethods.ReadRegisterDataFromExcel(2);
//            Register_AssistantMethods.FillRegisterForm(user);


//            Assert.IsTrue(Register_AssistantMethods.CheckSuccessRegister(user.Email));
//            Console.WriteLine("Test Case completed Successfully");
//        }

//        [TestMethod]
//        public void TestRegister_ConfirmationPassword()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.registerLink);
//            Thread.Sleep(7000);
//            User user = Register_AssistantMethods.ReadRegisterDataFromExcel(9);
//            Register_AssistantMethods.FillRegisterForm(user);

//            string expectedText = "bad";
//            string actualText = ManageDriver.driver.FindElement(By.XPath("//div/span[@id='confirmMessage']")).Text;

//            Assert.AreEqual(expectedText, actualText);
//            Console.WriteLine("Test Case Completed Successfully");
//        }

//        [TestMethod]
//        public void TestRegister_InvalidPhoneNumber()
//        {
//            ManageDriver.MaximizeDriver();
//            CommonMethods.NavigateToURL(GlobalConstant.registerLink);
//            Thread.Sleep(7000);

//            User user = new User("Bayan", "Mohammad", "Bayan@gmail.com", "123", "123", "0785", "01-01-1999", Gender.Female);
//            Register_AssistantMethods.FillRegisterForm(user);

//            string expectedText = "The PhoneNumber entered is incorrect.";
//            ManageDriver.driver.FindElement(By.XPath("//div/button[@aria-label='Close']")).Click();
//            string actualText = ManageDriver.driver.FindElement(By.XPath("//div/span[.='The PhoneNumber entered is incorrect.']")).Text;
//            Assert.AreEqual(expectedText, actualText);
//            Console.WriteLine("The Test Case has been completed successfully");

//        }

//        [TestMethod]
//        public void TestRegister_InvalidEmail()
//        {
//            ManageDriver.MaximizeDriver();
//            Thread.Sleep(7000);
//            for (int i = 3; i <= 5; i++)
//            {
//                try
//                {
//                    CommonMethods.NavigateToURL(GlobalConstant.registerLink);


//                    User user = Register_AssistantMethods.ReadRegisterDataFromExcel(i);

//                    Register_AssistantMethods.FillRegisterForm(user);

//                    string expectedURL = GlobalConstant.registerLink;  // Register
//                    string actualURL = ManageDriver.driver.Url; // Login
//                    Assert.AreEqual(actualURL, expectedURL);// not equal => Exception / stop the program
//                    Console.WriteLine("The Test Case has been completed successfully");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }



//        }
//        [TestMethod]
//        public void TestRegister_InvalidBirthDate()
//        {
//            ManageDriver.MaximizeDriver();

//            for (int i = 6; i <= 8; i++) // i=8
//            {
//                try
//                {


//                    CommonMethods.NavigateToURL(GlobalConstant.registerLink);
//                    Thread.Sleep(7000);


//                    User user = Register_AssistantMethods.ReadRegisterDataFromExcel(i); //7
//                    Register_AssistantMethods.FillRegisterForm(user);

//                    switch (i) // 7
//                    {
//                        case 6:
//                            string expectedValidation = "the age can't be in the future";
//                            string actualValidation = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text; ;

//                            Assert.AreEqual(expectedValidation, actualValidation);
//                            Console.WriteLine($"Test Case {i} completed Successfully");
//                            break;
//                        case 7:
//                            string expectedValidation2 = "the age under the legal age";
//                            string actualValidation2 = ManageDriver.driver.FindElement(By.XPath("ul/li")).Text;

//                            Assert.AreEqual(expectedValidation2, actualValidation2);
//                            Console.WriteLine($"Test Case {i} completed Successfully");
//                            break;

//                        case 8:
//                            string expectedURL = GlobalConstant.registerLink;
//                            string actualURL = ManageDriver.driver.Url;

//                            Assert.AreEqual(expectedURL, actualURL);
//                            Console.WriteLine($"Test Case {i} completed Successfully");
//                            break;
//                        default:
//                            break;
//                    }

//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            }

//        }
//    }
    
//}
