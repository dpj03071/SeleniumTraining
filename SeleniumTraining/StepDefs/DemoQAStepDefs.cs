using NUnit.Framework;
using SeleniumTraining.Application;
using SeleniumTraining.Utilities;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumTraining.StepDefs
{
    [Binding]
    public class DemoQAStepDefs
    {
        DemoQA demoQA;

        [Given(@"Open Demo QA")]
        public void GivenOpenDemoQA()
        {
            demoQA = new DemoQA(BrowserUtils.Driver);
            demoQA.NavigateToDemoQA();
        }

        [Given(@"Navigate to '([^']*)'")]
        public void GivenNavigateTo(string cardName)
        {
            demoQA.NavigateToCard(cardName);
        }

        [Given(@"Open Demo Web Element '([^']*)'")]
        public void GivenOpenDemoWebElement(string webElementName)
        {
            demoQA.OpenElementsMenu(webElementName);
        }


        [When(@"Fill up Textbox Form as '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void WhenFillUpTextboxFormAs(string fullName, string email, string currentAddress, string permanantAddress)
        {
            demoQA.FillUpTextBoxDemoForm(fullName, email, currentAddress, permanantAddress);
            Thread.Sleep(100);
        }

        [Then(@"Verify Textbox Form values are '([^']*)', '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenVerifyTextboxFormValuesAre(string fullName, string email, string currentAddress, string permanantAddress)
        {
            Assert.True(demoQA.CheckTextBoxDemoFormDisplayedCorrectly(fullName, email, currentAddress, permanantAddress),
                        "Text Box Details Are Saved Correctly");
        }

        [When(@"Select Radio Button Value as '([^']*)'")]
        public void WhenSelectRadioButtonValueAs(string RBValue)
        {
            demoQA.SelectRadioButtonAs(RBValue);
        }

        [Then(@"Verify Radio Button Value Displayed As '([^']*)'")]
        public void ThenVerifyRadioButtonValueDisplayedAs(string RBValue)
        {
            Assert.True(demoQA.CheckRadioButtonValuesAreSavedCorrectly(RBValue),
                        "Radio Button Values Are Saved Correctly");
        }
    }
}