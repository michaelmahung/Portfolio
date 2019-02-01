using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CheckMeFinal
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CurrentName { get; set; }

        public string BirthName { get; set; }

        public string Email { get; set; }

        public string BirthPlace { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthDate { get; set; }

        [Ignore]
        public string HouseHoldInfo
        {
            get { return HouseholdInformation.ToString(); }
            set { HouseHoldInfo = value; }
        }

        [Ignore]
        public houseHoldInformation HouseholdInformation { get; set; }





        public enum houseHoldInformation
        {
            Alone = 0,
            Spouse_Partner = 1,
            Kids = 2,
            Parents = 3,
            Other = 4
        }
    }
}
