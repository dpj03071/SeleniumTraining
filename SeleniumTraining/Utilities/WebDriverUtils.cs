using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Utilities
{
    public class WebDriverUtils
    {
        public WebDriver Driver;

        public WebDriverUtils(WebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }

        public List<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by).ToList();
        }

        public void ClickElement(By by)
        {
            IWebElement element = Driver.FindElement(by);
            Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public void WaitForElementDisplayed(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(5000));
            wait.Until(fun => Driver.FindElement(by).Displayed);
        }

        public void EnterTextInTextBox(By by, string text)
        {
            Driver.FindElement(by).SendKeys(text);
        }

        public string GetAttribute(By by, string attributeName)
        {
            return Driver.FindElement(by).GetAttribute(attributeName);
        }
    }
}