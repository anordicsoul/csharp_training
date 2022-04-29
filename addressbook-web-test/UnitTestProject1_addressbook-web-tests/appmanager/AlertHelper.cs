using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class AlertHelper : HelperBase
    {
        public AlertHelper(ApplicationManager manager) : base(manager) { }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }
    }
}
