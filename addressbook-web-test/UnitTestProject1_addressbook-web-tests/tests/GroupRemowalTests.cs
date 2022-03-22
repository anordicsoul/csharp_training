using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemowalTests : TestBase
    {
        

        [Test]
        public void GroupRemowalTest()
        {
            app.Groups.Remove(1);
        }
    }
}
