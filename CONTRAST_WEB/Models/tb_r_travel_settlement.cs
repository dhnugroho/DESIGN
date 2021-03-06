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
    
    public partial class tb_r_travel_settlement
    {
        public int id_settlement { get; set; }
        public int id_request { get; set; }
        public Nullable<bool> payment_flag { get; set; }
        public Nullable<bool> extend_flag { get; set; }
        public string apprv_dh { get; set; }
        public Nullable<System.DateTime> apprv_dh_date { get; set; }
        public string apprv_dph { get; set; }
        public Nullable<System.DateTime> apprv_dph_date { get; set; }
        public Nullable<bool> verified_ga { get; set; }
        public Nullable<double> settlement_meal { get; set; }
        public Nullable<double> settlement_transit { get; set; }
        public Nullable<double> settlement_transportation { get; set; }
        public Nullable<double> settlement_laundry { get; set; }
        public Nullable<double> settlement_miscellaneous { get; set; }
        public Nullable<double> settlement_visa { get; set; }
        public Nullable<double> settlement_passport { get; set; }
        public Nullable<double> settlement_flight { get; set; }
        public Nullable<double> settlement_hotel { get; set; }
        public Nullable<double> allowance_meal { get; set; }
        public Nullable<double> total_allowance_transit { get; set; }
        public Nullable<double> allowance_transportation { get; set; }
        public Nullable<double> allowance_laundry { get; set; }
        public Nullable<double> allowance_miscellaneous { get; set; }
        public Nullable<double> allowance_visa { get; set; }
        public Nullable<double> allowance_passport { get; set; }
        public Nullable<double> actualcost_flight { get; set; }
        public Nullable<double> actualcost_hotel { get; set; }
        public string user_created { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
    }
}
