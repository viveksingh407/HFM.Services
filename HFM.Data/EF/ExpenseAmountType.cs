//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HFM.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExpenseAmountType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExpenseAmountType()
        {
            this.TransactionDetails = new HashSet<TransactionDetail>();
        }
    
        public int ExpenseAmountTypeId { get; set; }
        public string ExpenseAmountTypeName { get; set; }
        public string ExpenseAmountTypeCode { get; set; }
        public Nullable<System.DateTime> ExpenseAmountFixedFrom { get; set; }
        public Nullable<System.DateTime> ExpenseAmountFixedTo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
