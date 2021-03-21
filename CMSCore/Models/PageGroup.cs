using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCore.Models
{
    public class PageGroup
    {
        [Key]
        public int PageGroupID { get; set; }
        [Display(Name ="گروه صفحه")]
        [Required(ErrorMessage ="لطفا مقدار {0} را وارد کنید")]
        [StringLength(maximumLength:100,ErrorMessage ="مقدار {0} باید بین {2} تا {1}  باشد",MinimumLength =8)]
        public string PageGroupTitle { get; set; }
        //Navigation Properties
        public virtual List<Page> Pages { get; set; }
    }
}
