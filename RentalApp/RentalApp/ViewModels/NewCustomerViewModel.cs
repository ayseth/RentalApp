﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalApp.Models;

namespace RentalApp.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }
}