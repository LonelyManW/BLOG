using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class LoginRequest
    {
        ///<summary>
        ///账号
        ///</summary>
         [Required(ErrorMessage = ErrorCode.Code_100)]
        public string account{get;set;}

        ///<summary>
        ///密码
        ///</summary>
        [Required(ErrorMessage = ErrorCode.Code_100)]
        public string password{get;set;}

        ///<summary>
        ///验证码
        ///</summary>
        public string code{get;set;}

    }
}