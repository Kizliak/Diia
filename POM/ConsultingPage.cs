using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecFlowDiia.POM
{
    class ConsultingPage
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait _wait;
        private Actions _action;

        public ConsultingPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 15));
            _action = new Actions(_webDriver);
        }

        private readonly By _accordionItems = By.XPath("//div[@class=\"common-accordion__items\"]/div");
        private readonly By _accordionBlock = By.CssSelector("h2[class=\"title faq-list-static__title h2\"]");
        private readonly By _tagsBlock = By.CssSelector("div[class=\"consulting-list__categories\"]");

        public ConsultingPage GoToUrl()
        {
            _webDriver.Navigate().GoToUrl("https://business.diia.gov.ua/consulting");
            return this;
        }

        public ConsultingPage MoveToAccordionBlock()
        {
            var accordionBlock = _webDriver.FindElement(_accordionBlock);
            _action.MoveToElement(accordionBlock).Perform();
            return this;
        }

        public bool CheckIfAccordionElementsOpen()
        {
            int i = 0;
            List<IWebElement> listOfAccordionItems = _webDriver.FindElements(_accordionItems).ToList();

            foreach (var acordionElement in listOfAccordionItems)
            {
                _action.MoveToElement(acordionElement).Perform();
                acordionElement.Click();
                _wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format($"//div[@class=\"common-accordion__item common-accordion__item-{i} faq-list-static__item-{i} common-accordion__item_is-open\"]/div"))));
                i++;
            }
            return true;
        }

        public ConsultingPage ClickTagByText(string tagNameToClick)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath(String.Format($"//span[contains(text(), '{tagNameToClick}')]"))));
            var tagsCloud = _webDriver.FindElement(_tagsBlock);
            _action.MoveToElement(tagsCloud).Perform();
            
            var tagElement = _webDriver.FindElement(By.XPath(String.Format($"//span[contains(text(), '{tagNameToClick}')]//ancestor::button")));
            _action.MoveToElement(tagElement).Perform();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(String.Format($"//span[contains(text(), '{tagNameToClick}')]//ancestor::button"))));
            tagElement.Click();
            return this;
        }

        public ConsultingPage WaitUntilTagPageLoad(string tagNameToClick)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath($"(//div[@class=\"large-content-card-category\"]//span[contains(text(), '{tagNameToClick}')])[1]")));
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"(//div[@class=\"large-content-card-category\"]//span[contains(text(), '{tagNameToClick}')])[1]")));
            return this;
        }
    }
}
