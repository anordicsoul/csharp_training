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
            ContactData contact = new ContactData("Tatsiana");
            contact.Middlname = "Alex";
            contact.Lastname = "Kulevich";
            contact.Nickname = "Tats";
            contact.Title = "title";
            contact.Company = "regbet";
            contact.Address = "Szarych 5";
            contact.Home = "445566";
            contact.Mobile = "48723703429";
            contact.Work = "375295093204";
            contact.Fax = "123456789";
            contact.Email = "kulevichtatsiana@gmail.com";
            contact.Email2 = "anordicsoul@mail.ru";
            contact.Email3 = "test@gmail.com";
            contact.Homepage = "https://software-testing.ru/";
            contact.Bday = "1";
            contact.Bmonth = "June";
            contact.Byear = "1995";
            contact.Aday = "2";
            contact.Amonth = "October";
            contact.Ayear = "2000";
            contact.Address2 = "Andrukiewicza";
            contact.Phone2 = "785898";
            contact.Notes = "notes";

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
            ContactData contact = new ContactData("");
            contact.Middlname = "";
            contact.Lastname = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";
            contact.Bday = "1";
            contact.Bmonth = "June";
            contact.Byear = "1995";
            contact.Aday = "5";
            contact.Amonth = "June";
            contact.Ayear = "2003";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

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
