using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjectTest.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string CustomerAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,30}$", ErrorMessage = "至少有一個數字、小寫英文字母、大寫英文字母")]
        public string CustomerPassword { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }
}