using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ChiwasEngine.Models
{
    [Bind(Exclude = "page_id")]
    public partial class Pages
    {
        public Pages()
        {
            this.Categories = new HashSet<Categories>();
        }

        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int page_id { get; set; }

        [Required]
        public System.DateTime page_date { get; set; }

        [AllowHtml]
        [Required]
        public string page_content { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long and a maximum of {1} characters.", MinimumLength = 6)] 
        public string page_description { get; set; }

        [Required]
        public string page_title { get; set; }

        public System.DateTime page_modified { get; set; }

        public bool page_visible { get; set; }

        public string page_image { get; set; }

        public virtual UserProfiles UserProfile { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
    }

}