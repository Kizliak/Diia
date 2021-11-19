//using System;
//using TechTalk.SpecFlow;
//using OpenQA.Selenium;
//using NUnit.Framework;
//using SpecFlowDiia.POM;

//namespace SpecFlowDiia.Steps
//{
//    [Binding]


//    public class PopularServicesSteps
//    {
//        private readonly IWebDriver _webDriver;
//        private readonly ScenarioContext _scenarioContext;
//        private readonly MainPage _mainPage;
//        private readonly PopularServicePage _popularServicePage;
//        //private string popularLinkText = "";

//        public PopularServicesSteps(ScenarioContext scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
//            _mainPage = new MainPage(_webDriver);
//            _popularServicePage = new PopularServicePage(_webDriver);
//        }

//        [Given(@"Main page is open")]
//        public void GivenMainPageIsOpen()
//        {
//            _mainPage.GoToUrl();
//        }

//        [When(@"I click on the first service")]
//        public void WhenIClickOnTheFirstService()
//        {
//            //popularLinkText = _mainPage.ClickPopulalServiceLink();
//            _scenarioContext["popularLinkText"] = _mainPage.ClickPopulalServiceLink();
//        }

//        [Then(@"I navigate to the service page")]
//        public void ThenINavigateToTheServicePage()
//        {
//            Assert.IsTrue(_popularServicePage.CheckTextOfFirstPopularLink(_scenarioContext["popularLinkText"].ToString()));
//        }

//    }
//}
