using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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
    class MainPage
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait _wait;
        private Actions _action;

        public MainPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 15));
            _action = new Actions(_webDriver);
        }
        
        //Search in the main page
        private readonly By _serchField = By.CssSelector("[class='input form-search_input']");
        private readonly By _serchButton = By.CssSelector("[type='submit']");
        private readonly By _serchTitleText = By.CssSelector("[class='search_request-text']");
        private readonly By _cookieClose = By.CssSelector("[class='cookies-1_close']");

        //PopularServiceLinks
        private readonly By _popularServiceLinks = By.XPath("(//ul[@class=\"nav nav - tabs tabs_services\"]/../div/div[1]//div[@class=\"swiper - wrapper swiper_services - wrapper\"]/div/div/div/a[@class=\"swiper_services - slide - title\"])[position() = 1]");

        //div[@class="swiper_services-top"]/../div[2]/div/div/div/a[@class="swiper_services-slide-title"]
        //ul[@class="nav nav-tabs tabs_services"]/../div/div/div/div/div[@class="swiper-wrapper swiper_services-wrapper"]

        public MainPage GoToMainPage()
        {
            _webDriver.Navigate().GoToUrl("https://diia.gov.ua/");
            return this;
        }

        public MainPage EnterDataForSearch(string input)
        {
            _webDriver
                .FindElement(_serchField)
                .SendKeys(input);
            _webDriver
               .FindElement(_cookieClose)
               .Click();
            return this;
        }

        public MainPage SearchButtonClick()
        {
            _webDriver
                .FindElement(_serchButton)
                .Click();
            return this;
        }
        public string SearchTextResponse(string text) =>
           _webDriver.FindElement(_serchTitleText).Text;

        public string ClickPopulalServiceLink()
        {
            var popularServiceLinkAhref = _webDriver.FindElement(_popularServiceLinks);
            _action.MoveToElement(popularServiceLinkAhref).Perform();
            popularServiceLinkAhref.Click();
            return popularServiceLinkAhref.Text;
        }
    }
}
