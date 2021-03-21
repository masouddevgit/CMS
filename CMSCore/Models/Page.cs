using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCore.Models
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }
        [Display(Name = "گروه صفحه")]
        public int PageGroupID { get; set; }
        [StringLength(maximumLength: 500, ErrorMessage = "مقدار {0} باید بین {2} تا {1}  باشد", MinimumLength = 8)]
        [Display(Name = "عنوان صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string PageTitle { get; set; }
        [Display(Name = "متن کوتاه صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [StringLength(maximumLength: 3000, ErrorMessage = "مقدار {0} باید بین {2} تا {1}  باشد", MinimumLength = 8)]
        public string PageShortText { get; set; }
        [Display(Name = "متن کامل صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string PageText { get; set; }
        [Display(Name = "تاریخ صفحه صفحه")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PageDate { get; set; }
        [Display(Name = "منشر شده؟")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public bool PageIsPublished { get; set; }
        //Navigation Properties
        [ForeignKey("PageGroupID")]
        [Display(Name = "گروه صفحه")]
        public virtual PageGroup PageGroup { get; set; }
        public virtual List<Comment> Comments { get; set; }

    }
}
