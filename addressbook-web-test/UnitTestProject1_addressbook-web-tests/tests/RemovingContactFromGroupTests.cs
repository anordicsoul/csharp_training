﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()

        {

            List<GroupData> groups = GroupData.GetAll();
            bool ft = false;

            foreach (GroupData g in groups)
            {
                List<ContactData> groupContacts = g.GetContacts();
                if (groupContacts.Count > 0)
                {
                    app.Contacts.RemoveContactFromGroup(groupContacts[0], g);
                    List<ContactData> newList = g.GetContacts();
                    groupContacts.RemoveAt(0);
                    groupContacts.Sort();
                    newList.Sort();
                    Assert.AreEqual(groupContacts, newList);
                    ft = true;
                    return;
                }
            }

            if (ft == false)
            {
                List<ContactData> groupContacts = groups[0].GetContacts();
                List<ContactData> contacts = ContactData.GetAll();
                app.Contacts.AddContactToGroup(contacts[0], groups[0]);

                ContactData contactToRemove = groups[1].GetContacts().First();

                app.Contacts.RemoveContactFromGroup(contacts[0], groups[0]);
                List<ContactData> newList = groups[0].GetContacts();
                groupContacts.RemoveAt(0);
                groupContacts.Sort();
                newList.Sort();
                Assert.AreEqual(groupContacts, newList);
            }
        }

    }
}
