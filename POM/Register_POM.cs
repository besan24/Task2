using Task2.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Data;


namespace Task2.POM
{
    public class Register_POM
    {
        public IWebDriver _webDriver;
        public Register_POM(IWebDriver driver) // IwebDriver driver = new chromeDriver()
        {
            _webDriver = driver; // _webDriver = new chromeDriver()
        }
        By fname = By.XPath("//div/input[@id='Fname']");
        By lname = By.XPath("//div/input[@id='Lname']");
        By genderMale = By.XPath("//div/input[@type='radio'][1]");
        By genderFemale = By.XPath("//div/input[@type='radio'][2]");
        By Dateofbirth = By.XPath("//div/input[@id='Dateofbirth']");
        By phoneNumber = By.XPath("//div/input[@id='Phonenumber']");
        By email = By.XPath("//div/input[@id='Email']");
        By password = By.XPath("//div/input[@id='myPass']");
        By passwordConfirmation = By.XPath("//div/input[@id='myPass2']");
        By Image = By.XPath("//div/input[@id='ImageFileUser']");
        By submitButtonn = By.XPath("//div/button[contains(text(), 'Submit')]");
        By loginLink = By.XPath("//div/p/a[.='Login']");

        public void EnterFirstName(string value)
        {
            IWebElement element = _webDriver.FindElement(fname);

            CommonMethods.Highlightelement(element);
            element.SendKeys(value);
        }

        public void EnterLastName(string value)
        {
            IWebElement element = _webDriver.FindElement(lname);
            element.SendKeys(value);
        }
        public void MaleButton()
        {
            IWebElement element = _webDriver.FindElement(genderMale);
            element.Click();
        }

        public void FemaleButton()
        {
            IWebElement element = _webDriver.FindElement(genderFemale);
            element.Click();
        }
        public void DateOfBirth(string value)
        {
            IWebElement element = _webDriver.FindElement(Dateofbirth);
            element.SendKeys(value);
        }
        public void EnterPhoneNumber(string value)
        {
            IWebElement element = _webDriver.FindElement(phoneNumber);
            element.SendKeys(value);
        }
        public void EnterEmail(string value)
        {
            IWebElement element = _webDriver.FindElement(email);
            element.SendKeys(value);
        }
        public void UploadImage(string imagePath)
        {
            IWebElement uploadElement = _webDriver.FindElement(Image);
            uploadElement.SendKeys(imagePath);
        }
        public void EnterPassword(string value)
        {
            IWebElement element = _webDriver.FindElement(password);
            element.SendKeys(value);
        }

        public void EnterConfirmationPassword(string value)
        {
            IWebElement element = _webDriver.FindElement(passwordConfirmation);
            element.SendKeys(value);
        }

        public void ClickSubmitButton1()
        {
            IWebElement element = _webDriver.FindElement(submitButtonn);
            element.Click();
        }
        public void ClickLoginLink()
        {
            IWebElement element = _webDriver.FindElement(loginLink);
            element.Click();
        }
    }  
}