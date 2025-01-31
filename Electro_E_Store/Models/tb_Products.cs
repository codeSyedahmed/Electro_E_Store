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
	using System.ComponentModel.DataAnnotations;

	public partial class tb_Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Products()
        {
            this.tb_Orders_Summary = new HashSet<tb_Orders_Summary>();
            this.tb_Review = new HashSet<tb_Review>();
            this.tb_Wishlist = new HashSet<tb_Wishlist>();
        }

        public int product_id { get; set; }
        [Required(ErrorMessage = "Please select category name.")]
        public Nullable<int> category_id { get; set; }
        [Required(ErrorMessage = "Please enter product name.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Product name cannot be longer than 100 characters")]
        public string product_name { get; set; }
        //[Required(ErrorMessage = "Choose product image.")]
        public string product_img { get; set; }
        [Required(ErrorMessage = "Please enter price.")]
        public Nullable<decimal> price { get; set; }
        [Required(ErrorMessage = "Please enter stock.")]
        public Nullable<int> stock { get; set; }
        [Required(ErrorMessage = "Please enter model.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model cannot be longer than 50 characters")]
        public string model { get; set; }
        [Required(ErrorMessage = "Please enter manufacturer name.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Manufacturer name cannot be longer than 50 characters")]
        public string manufacturer { get; set; }
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Description cannot be longer than 250 characters")]
        public string description { get; set; }
        public Nullable<System.DateTime> inserted_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<int> updated_by { get; set; }
    
        public virtual tb_Admin tb_Admin { get; set; }
        public virtual tb_Categories tb_Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Orders_Summary> tb_Orders_Summary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Review> tb_Review { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Wishlist> tb_Wishlist { get; set; }
    }
}
