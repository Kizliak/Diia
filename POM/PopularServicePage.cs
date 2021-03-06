using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

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
        
        private readonly By _popularServiceLinks = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[2]/div[1]/div[1]/div/a");
        private readonly By _clickRightButton = By.CssSelector("[class='swiper_services-btn-next swiper-btn-next']");
        private readonly By _clikLeftButton = By.CssSelector("[class='swiper_services-btn-prev swiper-btn-prev']");
        private readonly By _turnOneRight = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[2]/div[5]/div[1]/div/a");
        private readonly By _turnOneLeft = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[2]/div[4]/div[1]/div/a");
        private readonly By _cookieClose = By.CssSelector("[class='cookies-1_close']");
        private readonly By _swipeLeft = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[3]/span[1]");
        private readonly By _swipeRight = By.XPath("//*[@id='gromadyanam']/div[1]/div/div[3]/span[2]");
        private readonly By _popularServiceHeader = By.XPath("/html/body/div[1]/main/section[1]/div[1]/div/div[3]/div[1]");
      
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
            string linkText = popularServiceLinkAhref.Text;
            _action.MoveToElement(popularServiceLinkAhref).Perform();
            popularServiceLinkAhref.Click();
            return linkText;
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

        public bool TurnRight()
        {
           return _webDriver
                .FindElement(_turnOneRight)
                .GetAttribute("class")
                .Contains("active");
        }

        public bool TurnLeft()
        {
            return _webDriver
                .FindElement(_turnOneLeft)
                .GetAttribute("id")
                .Contains("active"); 
        }
    }
}
