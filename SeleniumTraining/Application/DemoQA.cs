using NUnit.Framework;
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
        public WebDriverUtils webDriverUtils { get; set; }

        public DemoQA(WebDriver webDriver)
        {
            Driver = webDriver;
            webDriverUtils = new WebDriverUtils(webDriver);
        }

        public void NavigateToDemoQA()
        {
            BrowserUtils.NavigateTo("https://demoqa.com/");
        }

        public void ClickOnCardName(string cardName)
        {
            string cardXPath = String.Format("//div[@class='card-body']//h5[contains(text(), '{0}')]", cardName);
            webDriverUtils.ClickElement(By.XPath(cardXPath));
        }

        public void WaitForElementsPageOpened()
        {
            string XPath = "//*[contains(text(), 'Please select an item from left to start practice.')]";
            webDriverUtils.WaitForElementDisplayed(By.XPath(XPath));
        }

        public void WaitForRadioButtonPageOpened()
        {
            string XPath = "//div[contains(text(), 'Do you like the site?')]";
            webDriverUtils.WaitForElementDisplayed(By.XPath(XPath));
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
            if (webDriverUtils.FindElements(By.XPath(xpath)).Count == 0)
            {
                webDriverUtils.ClickElement(By.XPath(xpathElementsMenuHeader));

            }
            webDriverUtils.ClickElement(By.XPath(xpath));
            switch (elementName)
            {
                case "Radio Button":
                    WaitForRadioButtonPageOpened();
                    break ;
            }
        }

        public void FillUpTextBoxDemoForm(string fullNmae, string email, string currentAddress, string permanantAddress)
        {
            webDriverUtils.EnterTextInTextBox(By.Id("userName"), fullNmae);
            webDriverUtils.EnterTextInTextBox(By.Id("userEmail"), email);
            webDriverUtils.EnterTextInTextBox(By.Id("currentAddress"), currentAddress);
            webDriverUtils.EnterTextInTextBox(By.Id("permanentAddress"), permanantAddress);
            webDriverUtils.ClickElement(By.Id("submit"));
        }

        public void CheckTextBoxDemoFormDisplayedCorrectly(string fullName, string email, string currentAddress, string permanantAddress)
        {
            string fullNameXPath = "//p[@id='name']";
            List<IWebElement> webElements = webDriverUtils.FindElements(By.XPath(fullNameXPath));
            string fullNameDisplayed = "";
            foreach (IWebElement webElement in webElements)
                fullNameDisplayed = fullNameDisplayed + webElement.Text;
            Assert.True(fullNameDisplayed.Equals("Name:" + fullName));
        }

        public void SelectRadioButtonAs(string RBValue)
        {
            By? by = null;

            switch (RBValue)
            {
                case "Yes":
                    by = By.XPath("//label[@for='yesRadio']");
                    break;
                case "Impressive":
                    by = By.XPath("//label[@for='impressiveRadio']");
                    break;
                case "No":
                    by = By.XPath("//label[@for='noRadio']");
                    break;
            }

            webDriverUtils.ClickElement(by);
        }

        public void CheckRadioButtonValuesAreSavedCorrectly(string RBValue)
        {
            string radioButtonResultXPath = "//p[contains(text(), 'You have selected ')]/span";
            string selectedValue = webDriverUtils.FindElement(By.XPath(radioButtonResultXPath)).Text;
            Assert.True(selectedValue.Equals(RBValue));
        }
    }
}