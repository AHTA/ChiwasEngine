using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using ChiwasEngine.Filters;

namespace ChiwasEngine.Models
{
    [Bind(Exclude = "category_id")]
    [InitializeSimpleMembershipAttribute]
    public partial class Categories
    {

        public Categories()
        {
            this.Pages = new HashSet<Pages>();
        }

        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int category_id { get; set; }
        public string category_name { get; set; }
        public string category_description { get; set; }

        public virtual ICollection<Pages> Pages { get; set; }
    }
}