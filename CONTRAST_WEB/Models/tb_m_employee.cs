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
    
    public partial class tb_m_employee
    {
        public string code { get; set; }
        public string name { get; set; }
        public string @class { get; set; }
        public string position { get; set; }
        public Nullable<int> unit_code_id { get; set; }
        public string unit_code_code { get; set; }
        public string unit_code_name { get; set; }
        public string bank_account { get; set; }
        public string account_holder { get; set; }
        public string name_of_bank { get; set; }
        public Nullable<short> passport_number { get; set; }
        public Nullable<System.DateTime> passport_valid_date { get; set; }
        public Nullable<bool> changetrackingmask { get; set; }
        public Nullable<System.DateTime> entry_date { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<bool> active_flag { get; set; }
    }
}
