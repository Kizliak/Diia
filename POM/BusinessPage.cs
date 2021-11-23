using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SpecFlowDiia.POM
{
    class BusinessPage
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait _wait;
        private Actions _action;

        public BusinessPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 15));
            _action = new Actions(_webDriver);
        }

        private readonly By _categoryElement = By.XPath("//div[@class=\"categories-menu__category\"][1]/div[@class=\"categories-menu__label-wrapper\"]");
        private readonly By _firstElementInCategoryMenu = By.XPath("//div[@class=\"categories-menu__category\"][1]//div[@class=\"categories-menu__link-wrapper\"][1]//span[@class=\"link__text\"]");
        private readonly By _tagsBlock = By.CssSelector("div[class=\"cards-list__categories\"]");

        public BusinessPage GoToUrl()
        {
            _webDriver.Navigate().GoToUrl("https://business.diia.gov.ua/");
            return this;
        }

        public BusinessPage MoveToCategoryElement()
        {
            _action.MoveToElement(_webDriver.FindElement(_categoryElement)).Perform();
            return this;
        }

        public BusinessPage WaitForDropdownMenuDisplay()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_firstElementInCategoryMenu));
            return this;
        }

        public BusinessPage ClickFirstElementInDropDownMenu()
        {
            _webDriver.FindElement(_firstElementInCategoryMenu).Click();
            _wait.Until(ExpectedConditions.ElementExists(_tagsBlock));
            return this;
        }
    }
}
