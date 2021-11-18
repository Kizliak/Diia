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

        private readonly By _popularServiceHeader = By.XPath("/html/body/div[1]/main/section[1]/div[1]/div/div[3]/div[1]");

        public bool CheckTextOfFirstPopularLink(string textOfPopularService)
        {
            if (_webDriver.FindElement(_popularServiceHeader).Text.Contains(textOfPopularService))
            {
                return true;
            }
            return false;
        }
    }
}
