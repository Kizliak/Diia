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
    class PopularServicePage
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait _wait;
        private Actions _action;

        public PopularServicePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 15));
            _action = new Actions(_webDriver);
        }
        
        //PopularServiceLinks
        private readonly By _popularServiceLinks = By.XPath("(//ul[@class=\"nav nav - tabs tabs_services\"]/../div/div[1]//div[@class=\"swiper - wrapper swiper_services - wrapper\"]/div/div/div/a[@class=\"swiper_services - slide - title\"])[position() = 1]");

        //div[@class="swiper_services-top"]/../div[2]/div/div/div/a[@class="swiper_services-slide-title"]
        //ul[@class="nav nav-tabs tabs_services"]/../div/div/div/div/div[@class="swiper-wrapper swiper_services-wrapper"]
        private readonly By _popularServiceHeader = By.XPath("/html/body/div[1]/main/section[1]/div[1]/div/div[3]/div[1]");

        public PopularServicePage GoMainPage()
        {
            _webDriver.Navigate().GoToUrl("https://diia.gov.ua/");
            return this;
        }
        public bool CheckTextOfFirstPopularLink(string textOfPopularService)
        {
            if (_webDriver.FindElement(_popularServiceHeader).Text.Contains(textOfPopularService))
            {
                return true;
            }
            return false;
        }
        public string ClickPopulalServiceLink()
        {
            var popularServiceLinkAhref = _webDriver.FindElement(_popularServiceLinks);
            _action.MoveToElement(popularServiceLinkAhref).Perform();
            popularServiceLinkAhref.Click();
            return popularServiceLinkAhref.Text;
        }
    }
}
