using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalApp.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly byte Unknown = 0; //readonly so we don't change the value accidently elsewhere in the code
        public static readonly byte PayAsYouGo = 1;

    }
}