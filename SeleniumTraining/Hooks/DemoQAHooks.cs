using SeleniumTraining.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumTraining.Hooks
{
    [Binding]
    public sealed class DemoQAHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("@TextboxDemo", "@RadioButtonDemo")]
        public void BeforeScenarioWithTag()
        {
            BrowserUtils.LaunchChromeBrowser();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BrowserUtils.CloseChromeBrowser();
        }
    }
}