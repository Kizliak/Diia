using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowDiia.POM;

namespace SpecFlowDiia.Steps
{
    [Binding]


    public class PopularServicesSteps
    {
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly MainPage _mainPage;
        private readonly PopularServicePage _popularServicePage;
        //private string popularLinkText = "";

        public PopularServicesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _popularServicePage = new PopularServicePage(_webDriver);
            _mainPage = new MainPage(_webDriver);
        }

        [When(@"I click on the first service")]
        public void WhenIClickOnTheFirstService()
        {
            //popularLinkText = _mainPage.ClickPopulalServiceLink();
            _scenarioContext["popularLinkText"] = _popularServicePage.ClickPopulalServiceLink();
        }

        [When(@"I click on the swiper rigt button")]
        public void WhenIClickOnTheSwiperRigtButton()
        {
            _popularServicePage.SwipeRightClick();
        }

        [When(@"I click on the swiper left button")]
        public void WhenIClickOnTheSwiperLeftButton()
        {
            _popularServicePage.SwipeLeftClick();
        }

        [When(@"I click on the right side of the pagination bullet bar")]
        public void WhenIClickOnTheRightSideOfThePaginationBulletBar()
        {
            _popularServicePage.ClickRight();
        }

        [When(@"I click on the left side of the pagination bullet bar")]
        public void WhenIClickOnTheLeftSideOfThePaginationBulletBar()
        {
            _popularServicePage.ClickLeft();
        }

        [Then(@"I navigate to the service page")]
        public void ThenINavigateToTheServicePage()
        {
            Assert.IsTrue(_popularServicePage.CheckTextOfFirstPopularLink(_scenarioContext["popularLinkText"].ToString()));
        }

        [Then(@"Popular servises moved right on one position")]
        public void ThenPopularServisesMovedRightOnOnePosition()
        {
            _popularServicePage.TurnRight();
        }

        [Then(@"Popular servises moved left on one position")]
        public void ThenPopularServisesMovedLeftOnOnePosition()
        {
            _popularServicePage.TurnLeft();
        }

        [Then(@"Popular services moved right on one position\.")]
        public void ThenPopularServicesMovedRightOnOnePosition_()
        {
            _popularServicePage.TurnRight();
        }

        [Then(@"Popular services moved left on one position\.")]
        public void ThenPopularServicesMovedLeftOnOnePosition_()
        {
            _popularServicePage.TurnLeft();
        }
    }
}
