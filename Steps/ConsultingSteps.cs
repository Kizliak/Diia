using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using SpecFlowDiia.POM;

namespace SpecFlowDiia.Steps
{
    [Binding]
    public class AccordionSteps
    {
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly ConsultingPage _consultingPage;

        public AccordionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = _scenarioContext.Get<IWebDriver>("WebDriver");
            _consultingPage = new ConsultingPage(_webDriver);
        }

        [Given(@"Consulting page is open")]
        public void GivenConsultingPageIsOpen()
        {
            _consultingPage.GoToUrl();
        }
        
        [When(@"I click on question from accordion list")]
        public void WhenIClickOnFirstQuestionInAccordionList()
        {
            _consultingPage.MoveToAccordionBlock();
        }
        
        [Then(@"Text block with answer to question open")]
        public void ThenTextBlockWithAnswerToQuestionOpen()
        {
            Assert.IsTrue(_consultingPage.CheckIfAccordionElementsOpen());
        }

        [When(@"I click on tag (.*)")]
        public void WhenIClickOnTag(string tagTitle)
        {
            _scenarioContext["TagTitle"] = tagTitle;
            _consultingPage.ClickTagByText(tagTitle);
        }

        [Then(@"I get to page (.*) corresponding to this tag")]
        public void ThenIGetToPageCorrespondingToThisTag(string url)
        {
            _consultingPage.WaitUntilTagPageLoad(_scenarioContext["TagTitle"].ToString());
            Assert.AreEqual("https://business.diia.gov.ua/" + url, _webDriver.Url);
        }
    }
}
