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
    
    public partial class tb_Comment
    {
        public int comment_id { get; set; }
        public Nullable<int> review_id { get; set; }
        public string answer_text { get; set; }
        public Nullable<System.DateTime> comment_date { get; set; }
        public Nullable<int> comment_by { get; set; }
    
        public virtual tb_Admin tb_Admin { get; set; }
        public virtual tb_Review tb_Review { get; set; }
    }
}
