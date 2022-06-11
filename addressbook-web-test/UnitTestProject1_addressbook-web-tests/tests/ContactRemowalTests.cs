using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemowalTests : AuthTestBase
    {

        [Test]
        public void ContactRemowalTest()
        {
            if (!app.Contacts.AContact(2))
            {
                app.Contacts.Create(new ContactData("cont5"));
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(2);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
    }
