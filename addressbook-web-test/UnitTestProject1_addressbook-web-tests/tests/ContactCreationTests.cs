using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
  
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Tatsiana", "Kulevich");

            contact.Lastname = "Kulevich";

            contact.Address = "Szarych 5";
            contact.Home = "445566";
            contact.Mobile = "48723703429";
            contact.Work = "375295093204";
            contact.Fax = "123456789";
            contact.Email = "kulevichtatsiana@gmail.com";
            contact.Email2 = "anordicsoul@mail.ru";
            contact.Email3 = "test@gmail.com";


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Out.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            contact.Lastname = "";

            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Email2 = "";
            contact.Email3 = "";


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Out.Logout();
        }
    }
}
