//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayerDemo.Repository.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public System.Guid Id { get; set; }
        public System.DateTime LoanDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public System.DateTime DateForReturn { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}