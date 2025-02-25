using Task2.Helpers;
using Task2.POM;
using OpenQA.Selenium;
using Task2.Data;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.POM

{

    public class Login_POM

    {

        public IWebDriver _webDriver;

        public Login_POM(IWebDriver driver) // IwebDriver driver = new chromeDriver()

        {

            _webDriver = driver; // _webDriver = new chromeDriver()

        }


        By email = By.XPath("//div/input[@id='Email']");

        By password = By.XPath("//div/input[@id='myPass1']");

        By submitButton = By.XPath("//div/button[contains(text(), 'Login')]");

        By RememberMe = By.XPath("//div/input[@id='RememberMe']");

        By showPassword = By.XPath("(//div/input[@type='checkbox'])[2]");

        By forgotPassword = By.XPath("//div/a[@href='/Auth/ForgotPassword']");

        By registerLink = By.XPath("//div/p/a[.='Register']");


        public void EnterEmail(string value)

        {
            IWebElement element = _webDriver.FindElement(email);
            CommonMethods.Highlightelement(element);

            element.SendKeys(value);

        }

        public void EnterPassword(string value)

        {

            IWebElement element = _webDriver.FindElement(password);
            CommonMethods.Highlightelement(element);

            element.SendKeys(value);

        }

        public void ClickSubmitButton()

        {

            IWebElement element = _webDriver.FindElement(submitButton);
            CommonMethods.Highlightelement(element);


            element.Click();

        }

        public void ClickRememberMe()

        {

            IWebElement element = _webDriver.FindElement(RememberMe);
            CommonMethods.Highlightelement(element);


            element.Click();

        }

        public void ClickShowPassword()

        {

            IWebElement element = _webDriver.FindElement(showPassword);
            CommonMethods.Highlightelement(element);


            element.Click();

        }

        public void ClickForgotPassword()

        {

            IWebElement element = _webDriver.FindElement(forgotPassword);
            CommonMethods.Highlightelement(element);


            element.Click();

        }

        public void ClickRegisterLink()

        {

            IWebElement element = _webDriver.FindElement(registerLink);
            CommonMethods.Highlightelement(element);


            element.Click();

        }


    }

}
