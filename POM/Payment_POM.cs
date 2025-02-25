using OpenQA.Selenium;
using Task2.POM;
using Task2.Data;
using OpenQA.Selenium.Support.UI;
using Task2.Helpers;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;

namespace Task2.POM
{
    public class Payment_POM
    {
        public IWebDriver _webDriver;

        public Payment_POM(IWebDriver driver)
        {
            _webDriver = driver;
        }

        // تعريف العناصر باستخدام XPath
        By menue =  By.XPath("//ul[@id='eeerd']");
        By cardholderName = By.XPath("//div/input[@name='cardholderame']");
        By cardNumber = By.XPath("//div/input[@name='cardNumber']");
        By cvv = By.XPath("//div/input[@name='cvv']");
        By expireDateField = By.XPath("//input[@name='expire' and @type='month']");
        By rememberMe = By.XPath("//div/input[@name='rememberMe']");
        By payButton = By.XPath("//button[contains(text(), 'Pay')]");
        By BackLink = By.XPath("//a[@href='/User/ShoppingCart']");
        By checkButton =By.XPath("//a[@class='btn btn-info mt-2' and contains(text(), 'Checkout')]");


        public void EnterCardholderName(string name)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(cardholderName);
            CommonMethods.Highlightelement(element);
            element.Clear(); 
            element.SendKeys(name);
        }

        public void EnterCardNumber(string number)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(cardNumber);
            CommonMethods.Highlightelement(element);
            element.Clear();
            element.SendKeys(number);
            
        }

        public void EnterCVV(string cvvValue)
        {

            IWebElement element = CommonMethods.WaitAndFindElement(cvv);
            CommonMethods.Highlightelement(element);
            element.Clear();
            element.SendKeys(cvvValue);

        }

        public void EnterexpireDateField(string year, string month)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            IWebElement expireDateField = wait.Until(drv => drv.FindElement(By.XPath("//input[@name='expire' and @type='month']")));
            string expireDate = $"{year}-{month.PadLeft(2, '0')}"; 
            IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;
            js.ExecuteScript("arguments[0].value = arguments[1];", expireDateField, expireDate);
            js.ExecuteScript("arguments[0].dispatchEvent(new Event('change'));", expireDateField);
        }



        public void SetRememberMe(bool rememberMeValue)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(rememberMe);
            CommonMethods.Highlightelement(element);
            element.Click();
        }
        public void ClickBackLink()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(BackLink);
            CommonMethods.Highlightelement(element);
            element.Click();
        }

        public void ClickPayButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(payButton);
            CommonMethods.Highlightelement(element);
            element.Click();
        }
        public  void ClickcheckButton()

        {
            IWebElement element = CommonMethods.WaitAndFindElement(checkButton);
            CommonMethods.Highlightelement(element);
            element.Click();
        }

        public bool IsCardholderNameEmpty()
        {
            IWebElement element = _webDriver.FindElement(cardholderName);
            return string.IsNullOrEmpty(element.GetAttribute("value"));
        }

        public bool IsCardNumberEmpty()
        {
            IWebElement element = _webDriver.FindElement(cardNumber);
            return string.IsNullOrEmpty(element.GetAttribute("value"));
        }

        public bool IsCVVEmpty()
        {
            IWebElement element = _webDriver.FindElement(cvv);
            return string.IsNullOrEmpty(element.GetAttribute("value"));
        }
        public bool IsPaymentSuccessful()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            IWebElement successMessage = wait.Until(drv => drv.FindElement(By.XPath("//div[@class='payment-status' and contains(text(), 'Success')]")));
            return successMessage != null;
        }
    }
}
