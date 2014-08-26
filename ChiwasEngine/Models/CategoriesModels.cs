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

    public class EditCategoryModel
    {
        public EditCategoryModel() { }

        public EditCategoryModel(Categories category)
        {

            this.category_id = category.category_id;
            this.category_name = category.category_name;
            this.category_description = category.category_description;
        }

        public int category_id { get; set; }
        public string category_name { get; set; }
        public string category_description { get; set; }

        public Categories getCategory()
        {
            return new Categories()
            {
                category_id = this.category_id,
                category_name = this.category_name,
                category_description = this.category_description
            };
        }
    }
}