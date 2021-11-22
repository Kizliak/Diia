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
        private readonly By _clickRightButton = By.CssSelector("[class='swiper_services-btn-next swiper-btn-next']");
        private readonly By _clikLeftButton = By.CssSelector("[class='swiper_services-btn-prev swiper-btn-prev']");
        private readonly By _turnOneRight = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[2]/div[5]/div[1]/div/a");
        private readonly By _turnOneLeft = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[2]/div[4]/div[1]/div/a");
        private readonly By _cookieClose = By.CssSelector("[class='cookies-1_close']");
        private readonly By _swipeLeft = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[3]/span[1]");
        private readonly By _swipeRight = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[3]/span[2]");
        //div[@class="swiper_services-top"]/../div[2]/div/div/div/a[@class="swiper_services-slide-title"]
        //ul[@class="nav nav-tabs tabs_services"]/../div/div/div/div/div[@class="swiper-wrapper swiper_services-wrapper"]
        private readonly By _popularServiceHeader = By.XPath("/html/body/div[1]/main/section[1]/div[1]/div/div[3]/div[1]");

        //public PopularServicePage GoMainPage()
        //{
        //    _webDriver.Navigate().GoToUrl("https://diia.gov.ua/");
        //    return this;
        //}
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

        public PopularServicePage SwipeRightClick()
        {
            _webDriver.FindElement(_swipeRight).Click();
            return this;
        }

        public PopularServicePage SwipeLeftClick()
        {
            _webDriver
                .FindElement(_swipeRight)
                .Click();
            _webDriver
                .FindElement(_swipeLeft)
                .Click();
            _webDriver
                .FindElement(_cookieClose)
                .Click();
            return this;
        }

        public PopularServicePage ClickRight()
        {
            _webDriver
                .FindElement(_clickRightButton)
                .Click();
            return this;
        }

        public PopularServicePage ClickLeft()
        {
            _webDriver
                .FindElement(_clickRightButton)
                .Click();
            _webDriver
                .FindElement(_clikLeftButton)
                .Click();
            _webDriver
                .FindElement(_cookieClose)
                .Click();
            return this;
        }

        public PopularServicePage GoToPopularServicePage()
        {
            _webDriver
                .Navigate()
                .GoToUrl("https://diia.gov.ua/services/");
            return this;
        }

        public void TurnRight()
        {
            _webDriver
                .FindElement(_turnOneRight);
        }

        public void TurnLeft()
        {
            _webDriver
                .FindElement(_turnOneLeft);
        }
    }
}
