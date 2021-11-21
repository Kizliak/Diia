using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

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
    }
}
