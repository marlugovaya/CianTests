using System;
using System.Net.NetworkInformation;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectModel.Source.Pages
{
    public class SearchResultPage
    {
        private IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // кнопка сортировки карточек объявлений
        [FindsBy(How = How.XPath, Using = "//button[@data-mark='SortDropdownButton']")]
        private IWebElement sortByButton;

        // кнопка сортировки по цене (сначала дешевле)
        [FindsBy(How = How.XPath, Using = "//option[@value='price_object_order']")]
        private IWebElement lowPriceOrderOption;

        // ссылки в карточках объявлений
        [FindsBy(How = How.XPath, Using = "//a[@class='_93444fe79c--link--VtWj6']")]
        private IList<IWebElement> cardLinks;

        // названия в карточках объявлений
        [FindsBy(How = How.XPath, Using = "//span[@data-mark='OfferTitle']")]
        private IList<IWebElement> cardTitles;

        // цены в карточках объявлений
        [FindsBy(How = How.XPath, Using = "//span[@data-mark='MainPrice']")]
        private IList<IWebElement> cardPrices;

        // текстовое описание в карточках объявлений
        [FindsBy(How = How.XPath, Using = "//span[@data-mark='OfferSubtitle']")]
        private IList<IWebElement> cardSubtitles;

        // оживание
        public void Wait(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        // применить сортировку по цене (сначала дешевле)
        public void SortByLowPrice()
        {
            sortByButton.Click();
            lowPriceOrderOption.Click();
        }

        // вывод в консоль информации из карточки объявления
        public void GetCardInfo(int i)
        {
            Console.WriteLine(cardLinks[i].GetDomProperty("href"));
            Console.WriteLine(cardTitles[i].Text);
            Console.WriteLine(cardPrices[i].Text);

            var subtitle = cardSubtitles[i].Text.Replace(" ", "").Split(",");
            Console.WriteLine(subtitle[1]);
            Console.WriteLine("\n");
        }
    }
}

