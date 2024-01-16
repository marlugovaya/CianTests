using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Net.NetworkInformation;


namespace PageObjectModel.Source.Pages
{


    public class CianHomePage
    {
        private IWebDriver _driver;

        public CianHomePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //кнопка смены локации
        [FindsBy(How = How.ClassName, Using = "_025a50318d--button--eBKAY")]
        private IWebElement locationButton;

        // кнопка Москвы
        [FindsBy(How = How.ClassName, Using = "_025a50318d--city-button--CDYzz")]
        private IWebElement moscowButton;

        // вкладка Снять
        [FindsBy(How = How.LinkText, Using = "Снять")]
        private IWebElement rentButton;

        //  ввод локации для поиска 
        [FindsBy(How = How.Id, Using = "geo-suggest-input")]
        private IWebElement locationInput;

        // кнопка из выпадающего списка в блоке Район
        [FindsBy(How = How.XPath, Using = "//div[@data-group='districts']//div[@class='_025a50318d--item--pYbdY']")]
        private IWebElement buttonInDropdown;

        // кнопка Найти
        [FindsBy(How = How.XPath, Using = "//a[@data-mark='FiltersSearchButton']")]
        private IWebElement searchButton;



        // смена локации на Москва
        public void ChangeToMoscow()
        {
            locationButton.Click();
            moscowButton.Click();

        }

        // оживание
        public void Wait(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        // перейти на вкладку Снять
        public void MoveToRent()
        {
            rentButton.Click();
        }

        // ввод наименования района и выбор из выпадающего списка
        public void SearchDistrictToRent(string district)
        {
            rentButton.Click();
            locationInput.SendKeys(district);
            Wait(2);

            var js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(false);", buttonInDropdown);

            buttonInDropdown.Click();

            searchButton.Click();

        }
    }
}

