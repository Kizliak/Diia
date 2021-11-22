using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDiia.POM
{
    class NewsPage
    {
        private readonly IWebDriver _webDriver;
        private WebDriverWait _wait;
        private Actions _action;

        public NewsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 15));
            _action = new Actions(_webDriver);
        }

        private readonly By _cookieClose = By.CssSelector("[class = 'cookies-1_close']");
        private readonly By _clickMoreNewsButton = By.CssSelector("[class='btn btn_more-news']");
        private readonly By _firstBlockNews = By.CssSelector("[class='posts_item-title'][1]");
        private readonly By _pageTitleText = By.CssSelector("[class='page_title-text']");
        private readonly By _navigation = By.CssSelector("[class='pagination']");
        private readonly By _paginationNum2 = By.CssSelector("[href='https://diia.gov.ua/news?page=2']");
        private readonly By _countNewsBlock = By.CssSelector("[class='posts_item']");
        private readonly By _firstNewsBlockTitle = By.CssSelector("[class='posts_item-title'][1]");
        private readonly By _activePaginationElement = By.CssSelector("[class='active']");
        private readonly By _clikNextPageButton = By.CssSelector("[id='post-navigation'] [rel='next']");
        private readonly By _clikPreviousPageButton = By.XPath("//*[@id='post-navigation']/ul/li[1]/a");
        private readonly By _paginationNextButton = By.XPath(".//*[@id='post-navigation']/ul/li[3]/span");
        private readonly By _paginationPreviousButton = By.XPath("//*[@id='post-navigation']/ul/li[2]/a");
        

        public NewsPage GoToNewsPage()
        {
            _webDriver
                .Navigate()
                .GoToUrl("https://diia.gov.ua/news");
            _webDriver
              .FindElement(_cookieClose)
              .Click();
            return this;
        }

        public NewsPage СlickOnMoreNewsButton()
        {
            _webDriver
                .FindElement(_clickMoreNewsButton)
                .Click();
            return this;
        }

        public NewsPage СlickOnFirstBlockNews()
        {
            _webDriver
                .FindElement(_firstBlockNews)
                .Click();
            return this;
        }

        public string Pagination()
        {
            var pagination = _webDriver.FindElement(_navigation);
            _action.MoveToElement(pagination).Perform();
            pagination.Click();
            return pagination.Text;
        }
        public NewsPage PaginationNum2()
        {
            _webDriver
                .FindElement(_paginationNum2)
                .Click();
            return this;
        }

        public int numOfSecondNewsPageBlock = 12;
        public NewsPage CountNewsBlock(int numOfSecondNewsPageBlock)
        {
            _webDriver
                .FindElements(_countNewsBlock)
                .Count();
            return this;
        }

        public string ActivePaginationElement()
        {
            var activeElement = _webDriver.FindElement(_activePaginationElement);
            _action.MoveToElement(activeElement).Perform();
            activeElement.Click();
            return activeElement.Text;
        }
        public NewsPage NextPageButtonClick()
        {
            _webDriver
                .FindElement(_clikNextPageButton)
                .Click();
            return this;
        }

        public NewsPage PreviousPageButtonClik()
        {
            _webDriver
                .FindElement(_clikNextPageButton)
                .Click();
            _webDriver
                .FindElement(_clikPreviousPageButton)
                .Click();
            return this;
        }

        public void FirstBlockTextSecondPage()
        {
            _webDriver
                .FindElement(_firstNewsBlockTitle);
        }
        public void SecondPageNumberNavigation()
        {
            _webDriver
                .FindElement(_activePaginationElement);
        }

        public void FirstNewsBlockTitle()
        {
            _webDriver
                .FindElement(_pageTitleText);
        }
        public void ActiveNavElementNextPage()
        {
            _webDriver
                .FindElement(_paginationNextButton);
        }

        public void ActiveNavElementPriviousPage()
        {
            _webDriver
                .FindElement(_paginationPreviousButton);
        }
    }
}
