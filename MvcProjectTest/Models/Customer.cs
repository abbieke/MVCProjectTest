using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjectTest.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Display(Name = "會員姓名")]
        [Required]
        [StringLength(20,MinimumLength =1,ErrorMessage ="必填欄位")]
        public string CustomerName { get; set; }

        [Display(Name = "連絡電話")]
        [Required]
        [RegularExpression(@"^\d{4}\-?\d{3}\-?\d{3}$",ErrorMessage ="需為09xx-xxx-xxx")]
        public string CustomerPhone { get; set; }

        [Display(Name = "會員生日")]
        [Required(ErrorMessage = "請選擇生日")]
        [DataType(DataType.Date)]
        public DateTime CustomerBirth { get; set; }

        [Display(Name = "地址")]
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "必填欄位")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "請輸入Email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Display(Name = "會員帳號")]
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "最少需要8個字元")]
        public string CustomerAccount { get; set; }

        [Display(Name ="會員密碼")]
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,30}$", ErrorMessage = "至少有一個數字、小寫英文字母、大寫英文字母")]
        public string CustomerPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("CustomerPassword", ErrorMessage = "密碼和確認密碼不相符")]
        public string ConfirmPassword { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string CustomerAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string CustomerPassword { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }
}