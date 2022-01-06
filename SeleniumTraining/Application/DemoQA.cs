using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTraining.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Application
{
    public class DemoQA
    {
        public WebDriver Driver { get; set; }

        public DemoQA(WebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void NavigateToDemoQA()
        {
            BrowserUtils.NavigateTo("https://demoqa.com/");
        }

        public void ClickOnCardName(string cardName)
        {
            string cardXPath = String.Format("//div[@class='card-body']//h5[contains(text(), '{0}')]", cardName);
            IWebElement element = Driver.FindElement(By.XPath(cardXPath));
            Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public void WaitForElementsPageOpened()
        {
            string XPath = "//*[contains(text(), 'Please select an item from left to start practice.')]";
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(5000));
            wait.Until(fun => Driver.FindElement(By.XPath(XPath)).Displayed);
        }

        public void WaitForRadioButtonPageOpened()
        {
            string XPath = "//div[contains(text(), 'Do you like the site?')]";
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(5000));
            wait.Until(fun => Driver.FindElement(By.XPath(XPath)).Displayed);
        }

        public void NavigateToCard(string cardName)
        {
            ClickOnCardName(cardName);
            switch (cardName)
            {
                case "Elements":
                    WaitForElementsPageOpened();
                    break;
            }
        }

        public void OpenElementsMenu(string elementName)
        {
            string xpathElementsMenuHeader = "//div[@class='header-text' and contains(text(), 'Elements')]";
            string xpath = String.Format("//ul[@class='menu-list']//span[contains(text(), '{0}')]", elementName);
            if (Driver.FindElements(By.XPath(xpath)).Count == 0)
            {
                Driver.FindElement(By.XPath(xpathElementsMenuHeader)).Click();
            }
            IWebElement element = Driver.FindElement(By.XPath(xpath));
            Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();

            switch (elementName)
            {
                case "Radio Button":
                    WaitForRadioButtonPageOpened();
                    break ;
            }
        }

        public void FillUpTextBoxDemoForm(string fullNmae, string email, string currentAddress, string permanantAddress)
        {
            Driver.FindElement(By.Id("userName")).SendKeys(fullNmae);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanantAddress);
            IWebElement element = Driver.FindElement(By.Id("submit"));
            Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public bool CheckTextBoxDemoFormDisplayedCorrectly(string fullNmae, string email, string currentAddress, string permanantAddress)
        {
            string fullNameXPath = "//p[@id='name']";
            List<IWebElement> webElements = Driver.FindElements(By.XPath(fullNameXPath)).ToList();
            string fullNameDisplayed = "";
            foreach (IWebElement webElement in webElements)
                fullNameDisplayed = fullNameDisplayed + webElement.Text;
            return fullNameDisplayed.Equals("Name:" + fullNmae);
        }

        public void SelectRadioButtonAs(string RBValue)
        {
            IWebElement? element = null;
            switch (RBValue)
            {
                case "Yes":
                    element = Driver.FindElement(By.XPath("//label[@for='yesRadio']"));
                    break;
                case "Impressive":
                    element = Driver.FindElement(By.XPath("//label[@for='impressiveRadio']"));
                    break;
                case "No":
                    element = Driver.FindElement(By.XPath("//label[@for='noRadio']"));
                    break;
            }

            Driver.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Build().Perform();
        }

        public bool CheckRadioButtonValuesAreSavedCorrectly(string RBValue)
        {
            string radioButtonResultXPath = "//p[contains(text(), 'You have selected ')]/span";
            string selectedValue = Driver.FindElement(By.XPath(radioButtonResultXPath)).Text;
            return selectedValue.Equals(RBValue);
        }
    }
}