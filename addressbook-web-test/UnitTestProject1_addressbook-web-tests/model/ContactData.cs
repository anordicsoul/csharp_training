using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData :  IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string detailedInformation;

        public ContactData()
        {

        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;

        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname & Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public static List<ContactData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string Home { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string Work { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhones(Home) + CleanUpPhones(Mobile) + CleanUpPhones(Work) + CleanUpPhones(Fax)).Trim();
                }
            }
            set
            { allPhones = value; }
        }

        private string CleanUpPhones(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        private string CleanUpAddress(string address)
        {
            if (address == null || address == "")
            {
                return "";
            }
            return address.Replace(" ", "") + "\r\n";
        }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    if (Email != "")
                    {
                        Email = Email + "\r\n";
                    }
                    if (Email2 != "")
                    {
                        Email2 = Email2 + "\r\n";
                    }
                    if (Email3 != "")
                    {
                        Email3 = Email3 + "\r\n";
                    }
                    return (Email + Email2 + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string DetailedInformation
        {
            get
            {
                if(detailedInformation != null)
                {
                    return detailedInformation;
                }
                else
                {
                    if (Lastname != "")
                    {
                        Lastname = " " + Lastname;
                    }
                    return (Firstname + Lastname + "\r\n" + CleanUpAddress(Address) + DetaliedPhones(Home, Mobile, Work, Fax) + "\r\n" +  AllEmails).Trim();
                }
            }
            set
            {
                detailedInformation = value;
            }
        }

        public string DetaliedPhones(string homePhone, string mobilePhone, string workPhone, string fax)

        {
            if (homePhone == "" & mobilePhone == "" & workPhone == "" & fax == "")
            {
                return "";
            }
            if (homePhone != "")
            {
                homePhone = "H: " + homePhone + "\r\n";
            }
            if (mobilePhone != "")
            {
                mobilePhone = "M: " + mobilePhone + "\r\n";
            }
            if (workPhone != "")
            {
                workPhone = "W: " + workPhone + "\r\n";
            }
            if (fax != "")
            {
                fax = "F: " + fax + "\r\n";
            }
            return "\r\n" + homePhone + mobilePhone + workPhone + fax;
        }
    }

    }
