using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    // This class represents a data model for storing information about a cashier in the SaleFlex system.
    public class CashierDataModel
    {
        // Unique identifier for the cashier.
        public int iId { get; set; }

        // The cashier number, which could be used to identify the cashier within the system.
        public int iNo { get; set; }

        // First name of the cashier.
        public string strName { get; set; }

        // Last name of the cashier.
        public string strLastName { get; set; }

        // Password for the cashier, used for authentication.
        public string strPassword { get; set; }

        // Identity number of the cashier, possibly used for official identification or other validation purposes.
        public string strIdentityNumber { get; set; }

        // A description field that can store additional information about the cashier.
        public string strDescription { get; set; }

        // Indicates whether the cashier has administrative privileges (true) or not (false).
        public bool bIsAdministrator { get; set; }
    }
}
