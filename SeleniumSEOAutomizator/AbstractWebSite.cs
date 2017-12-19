using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSEOAutomizator
{
    abstract class AbstractWebSite
    {
     
        protected ChromeDriver driver { get; set; }
        protected String url { get; set; }
        protected bool error { get; set; }
        protected List<String> res { get; set;}

        //инициализация работы скрипта
        public void init(String url) 
        {
            this.url = url;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);          
       }

        public abstract void run(); //тело скрипта

        public void AddResult(String result)
        {
            this.res.Add(result);
        }
        public List<String> results()
        {
            return res;
        }

        public bool isError()
        {
            return this.error;
        }

        //завершение работы скрипта
        public void close()
        {
            driver.Close();
            driver.Quit();
            //Environment.Exit(0);
            
            
        }
    }
}
