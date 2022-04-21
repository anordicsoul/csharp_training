using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
  
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts
                .InitNewContactCreation()
                .FillContactForm(new ContactData("Tatsiana", "Kulevich"))
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
            app.Out.Logout();
        }

    }
}
