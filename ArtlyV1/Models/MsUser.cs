//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtlyV1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsUser()
        {
            this.MsProducts = new HashSet<MsProduct>();
            this.TrUserAddresses = new HashSet<TrUserAddress>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
            this.MsTransactions = new HashSet<MsTransaction>();
            this.TopUps = new HashSet<TopUp>();
        }
    
        public string IdUser { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdGender { get; set; }
        public string IdRole { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public decimal Balance { get; set; }
    
        public virtual LtGender LtGender { get; set; }
        public virtual LtRole LtRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MsProduct> MsProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrUserAddress> TrUserAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MsTransaction> MsTransactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopUp> TopUps { get; set; }
    }
}
