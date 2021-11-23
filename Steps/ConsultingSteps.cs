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

        [When(@"I click Order button in consultations list")]
        public void WhenIClickOrderButtonInConsultationsList()
        {
            _consultingPage.ScrollToConsultationsBlock()
                .ClickOrderButton();
        }

        [Then(@"Authorize notification opens in pop-up window")]
        public void ThenAuthorizeNotificationOpensInPop_UpWindow()
        {
            Assert.IsTrue(_consultingPage.CheckIfAuthorizePopupIsVisible());
        }

        [When(@"I click Show more button")]
        public void WhenIClickShowMoreButton()
        {
            _consultingPage.ScrollToMoreButton()
                .ClickMoreButton();
        }

        [Then(@"I see (.*) consultation blocks on page")]
        public void ThenISeeConsultationBlocksOnPage(int p0)
        {
            Assert.AreEqual(12,_consultingPage.CountConsultationElementsOnPage());
        }
    }
}
