//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Electro_E_Store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Admin()
        {
            this.tb_Categories = new HashSet<tb_Categories>();
            this.tb_Comment = new HashSet<tb_Comment>();
            this.tb_Orders = new HashSet<tb_Orders>();
            this.tb_Products = new HashSet<tb_Products>();
            this.tb_User = new HashSet<tb_User>();
        }
    
        public int admin_id { get; set; }
        public string admin_name { get; set; }
        public string admin_email { get; set; }
        public string a_password { get; set; }
        public string contact_no { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Categories> tb_Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Comment> tb_Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Orders> tb_Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Products> tb_Products { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_User> tb_User { get; set; }
    }
}
