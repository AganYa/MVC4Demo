//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcDemo3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EL_MasterData
    {
        public int ID { get; set; }
        public string ProcessID { get; set; }
        public string K2ProcessInstID { get; set; }
        public string StaffCode { get; set; }
        public string StaffName { get; set; }
        public string HolidayType { get; set; }
        public Nullable<System.DateTime> StratDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string StartTimeSpan { get; set; }
        public string EndTimeSpan { get; set; }
        public Nullable<decimal> CalendarDays { get; set; }
        public Nullable<decimal> WorkingDays { get; set; }
        public string ReasonForLeave { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string StaffAccount { get; set; }
        public string DelegateStaffAccount { get; set; }
    }
}
