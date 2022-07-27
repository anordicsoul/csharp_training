using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.AContact(2))
            {
                app.Contacts.Create(new ContactData("cont5", ""));
            }

            ContactData newData = new ContactData("Natalia", "Bezmen");

            newData.Lastname = "Bezmen";

            newData.Address = "Generala Maczka 8";
            newData.Home = "";
            newData.Mobile = "+48723703429";
            newData.Work = "+375295093204";
            newData.Fax = "";
            newData.Email = "kulevich@gmail.com";
            newData.Email2 = "";
            newData.Email3 = "";


            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];
            app.Contacts.Modify(oldData, newData);
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
