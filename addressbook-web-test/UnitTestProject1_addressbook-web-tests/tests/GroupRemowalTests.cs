﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemowalTests : AuthTestBase
    {
        [Test]
        public void GroupRemowalTest()
        {
            if (!app.Groups.AGroup(1))
            {
                app.Groups.Create(new GroupData("gr5"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(0);


            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}