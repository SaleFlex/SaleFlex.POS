using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleFlex.Data.Models
{
    // This class represents the VAT (Value Added Tax) data model used in the SaleFlex system.
    // It contains information about different VAT rates and their details.
    public class VatDataModel
    {
        // Unique identifier for the VAT record.
        public int iId { get; set; }

        // VAT number or code to identify the specific VAT category.
        public int iNo { get; set; }

        // Name of the VAT type/category (e.g., "Standard VAT", "Reduced VAT").
        public string strName { get; set; }

        // The rate of the VAT, represented as an integer (e.g., 18 for 18% VAT rate).
        public int iRate { get; set; }

        // Additional description or details about the VAT.
        public string strDescription { get; set; }
    }
}
