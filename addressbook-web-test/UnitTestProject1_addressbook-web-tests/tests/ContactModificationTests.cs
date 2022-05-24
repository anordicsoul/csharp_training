using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.AContact(2))
            {
                app.Contacts.Create(new ContactData("cont5"));
            }

            ContactData newData = new ContactData("Natalia");
            newData.Middlname = "Alexandrowna";
            newData.Lastname = "Bezmen";
            newData.Nickname = "anordicsoul";
            newData.Title = "";
            newData.Company = "apple";
            newData.Address = "Generala Maczka 8";
            newData.Home = "";
            newData.Mobile = "+48723703429";
            newData.Work = "+375295093204";
            newData.Fax = "";
            newData.Email = "kulevich@gmail.com";
            newData.Email2 = "";
            newData.Email3 = "";
            newData.Homepage = "https://software-testing.ru/login";
            newData.Bday = "21";
            newData.Bmonth = "June";
            newData.Byear = "1998";
            newData.Aday = "15";
            newData.Amonth = "March";
            newData.Ayear = "1985";
            newData.Address2 = "Mickiewicza 15";
            newData.Phone2 = "+56785898";
            newData.Notes = "123456";

            app.Contacts.Modify(newData);
        }
    }
}
