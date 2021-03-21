using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMSCore.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Display(Name = "صفحه")]
        public int PageID { get; set; }
        [StringLength(maximumLength: 60, ErrorMessage = "مقدار {0} باید بین {2} تا {1}  باشد", MinimumLength = 8)]
        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string AuthorName { get; set; }
        [StringLength(maximumLength: 250, ErrorMessage = "مقدار {0} باید بین {2} تا {1}  باشد", MinimumLength = 15)]
        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="عنوان {0} صحیح نمیباشد")]
        public string AuthorEmail { get; set; }
        [Display(Name = "نام نویسنده")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public string CommentText { get; set; }
        [Display(Name = "تاریخ ثبت نظر")]
        [Required(ErrorMessage = "لطفا مقدار {0} را وارد کنید")]
        public DateTime CommentDate { get; set; }
        //Navigation Properties
        [ForeignKey("PageID")]
        [Display(Name = "صفحه")]
        public virtual Page Page { get; set; }


    }
}
