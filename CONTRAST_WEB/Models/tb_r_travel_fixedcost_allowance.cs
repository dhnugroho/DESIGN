//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CONTRAST_WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_r_travel_fixedcost_allowance
    {
        public int id_payment { get; set; }
        public Nullable<int> id_request { get; set; }
        public Nullable<int> vendor_code { get; set; }
        public string payment_status { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<bool> verified_allowance_flag { get; set; }
        public Nullable<bool> apprv_allowance_dph { get; set; }
        public Nullable<System.DateTime> payment_date { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
    }
}
