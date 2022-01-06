using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTraining.Utilities
{
    public class BrowserUtils
    {
        public static WebDriver Driver;

        public static void LaunchChromeBrowser()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public static void CloseChromeBrowser()
        {
            Driver.Quit();
        }

        public static void NavigateTo(string url)
        {
            if(Driver != null)
                Driver.Navigate().GoToUrl(url);
        }
    }
}
