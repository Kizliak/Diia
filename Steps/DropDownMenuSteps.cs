using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowDiia.POM;

namespace SpecFlowDiia.Steps
{
    [Binding]
    public class DropDownMenuSteps
    {
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly BusinessPage _businessPage;

        public DropDownMenuSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _businessPage = new BusinessPage(_webDriver);
        }

        [Given(@"Business page is open")]
        public void GivenBusinessPageIsOpen()
        {
            _businessPage.GoToUrl();
        }
        
        [When(@"I move mouse to menu element")]
        public void WhenIMoveMouseToMenuElement()
        {
            _businessPage.MoveToCategoryElement();
        }
        
        [When(@"I click on link frop dropdown menu")]
        public void WhenIClickOnLinkFropDropdownMenu()
        {
            _businessPage.ClickFirstElementInDropDownMenu();
        }
        
        [Then(@"Dropdown menu display category links")]
        public void ThenDropdownMenuDisplayCategoryLinks()
        {
            _businessPage.WaitForDropdownMenuDisplay();
        }
        
        [Then(@"I get to corresponding page")]
        public void ThenIGetToCorrespondingPage()
        {
            Assert.AreEqual("https://business.diia.gov.ua/idea", _webDriver.Url);
        }
    }
}
