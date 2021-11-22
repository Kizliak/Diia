using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowDiia.POM;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDiia.Steps
{
    [Binding]
    public class NewsFeatureSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;
        private readonly NewsPage _newsPage;

        public NewsFeatureSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _newsPage = new NewsPage(_webDriver);
        }

        [Given(@"News page is open")]
        public void GivenNewsPageIsOpen()
        {
            _newsPage.GoToNewsPage();
        }
        
        [When(@"I click on more news button on the first page")]
        public void WhenIClickOnMoreNewsButton()
        {
            _newsPage.СlickOnMoreNewsButton();
        }
        
        [When(@"I click on the title in first news block")]
        public void WhenIClickOnTheTitleInFirstNewsBlock()
        {
            _newsPage.СlickOnFirstBlockNews();
        }
        
        [When(@"I scroll to page number navigation")]
        public void WhenIScrollToPageNumberNavigation()
        {
            _newsPage.Pagination();
        }
        
        [When(@"I click on the second page number")]
        public void WhenIClickOnTheSecondPageNumber()
        {
            _newsPage.PaginationNum2();
        }
        
        [When(@"I click the next page button")]
        public void WhenIClickTheNextPageButton()
        {
            _newsPage.NextPageButtonClick();
        }
        
        [When(@"I click the previous page button")]
        public void WhenIClickThePreviousPageButton()
        {
            _newsPage.PreviousPageButtonClik();
        }
        
        [Then(@"Сount with news blocks in the page is (.*)")]
        public void ThenСountWithNewsBlocksInThePageIs()
        {
            Assert.IsTrue(_newsPage.CountNewsBlock());
        }
        
        [Then(@"I see second page number navigation")]
        public void ThenISeeSecondPageNumberNavigation()
        {
            _newsPage.SecondPageNumberNavigation();
        }
        
        [Then(@"I see text of the news first title")]
        public void ThenISeeTextOfTheNewsFirstTitle()
        {
            _newsPage.FirstNewsBlockTitle();
        }
        
        [Then(@"I see first block text on the second page")]
        public void ThenISeeFirstBlockTextOnTheSecondPage()
        {
            _newsPage.FirstBlockTextSecondPage();
        }
        
        [Then(@"I see switch second selector navigation")]
        public void ThenISeeWhitchSecondSelectorNavigation()
        {
            _newsPage.ActivePaginationElement();
        }
        
        [Then(@"I go to the next page")]
        public void ThenIGoToTheNextPage()
        {
            _newsPage.ActiveNavElementNextPage();
        }
        
        [Then(@"I go to the previous page")]
        public void ThenIGoToThePreviousPage()
        {
            _newsPage.ActiveNavElementPriviousPage();
        }
    }
}
