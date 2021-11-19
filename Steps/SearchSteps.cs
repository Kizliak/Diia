using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SpecFlowDiia.Features.MainPage;
using SpecFlowDiia.POM;

namespace SpecFlowDiia.Steps
{
    [Binding]
    public class SearchSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly MainPage _mainPage;

        public SearchSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _mainPage = new MainPage(_webDriver);
        }

        [Given(@"Main page is open")]
        public void GivenMainPageIsOpen()
        {
            _mainPage.GoToUrl();
        }

        [When(@"I input '(.*)' in the search field")]
        public void WhenIInputInTheSearchField(string input)
        {
            _mainPage.EnterDataForSearch(input);
        }
        
        [When(@"I click on the search button")]
        public void WhenIClickOnTheSearchButton()
        {
            _mainPage.SearchButtonClick();
        }

        [Then(@"l see a search page with text'(.*)'")]
        public void ThenLSeeASearchPageWithText(string text)
        {
            _mainPage.SearchTextResponse(text);
        }

    }
}
