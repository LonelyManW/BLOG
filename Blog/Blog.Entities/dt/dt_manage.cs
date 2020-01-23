using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities
{
    public partial class dt_manage
    {
        private int _id;
        private string _name;
        private string _account;
        private string _password;
        private string _ip;
        private string _email;
        private string _phone;
        private string _img;
        private int _state = 1;
        private int _status = 1;
        private DateTime _login_time = DateTime.Now;
        private DateTime _reg_time = DateTime.Now;
        private DateTime _update_time = DateTime.Now;
        private string _remark = "";

        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            get => _id;
            set => _id = value;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string name
        {
            get => _name;
            set => _name = value;
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string account
        {
            get => _account;
            set => _account = value;
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string password
        {
            get => _password;
            set => _password = value;
        }
        /// <summary>
        /// ip
        /// </summary>
        public string ip
        {
            get => _ip;
            set => _ip = value;
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            get => _email;
            set => _email = value;
        }
        /// <summary>
        ///电话
        /// </summary>
        public string phone
        {
            get => _phone;
            set => _phone = value;
        }
        ///<summary>
        ///头像
        ///</summary>
        public string img
        {
            get => _img;
            set => _img = value;
        }
        /// <summary>
        /// 状态0-禁用，1-正常
        /// </summary>
        public int state
        {
            get => _state;
            set => _state = value;
        }
        /// <summary>
        /// 状态0-禁用，1-正常
        /// </summary>
        public int status
        {
            get => _status;
            set => _status = value;
        }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime login_time
        {
            get => _login_time;
            set => _login_time = value;
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime reg_time
        {
            get => _reg_time;
            set => _reg_time = value;
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime update_time
        {
            get => _update_time;
            set => _update_time = value;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string remark
        {
            get => _remark;
            set => _remark = value;
        }
    }
}
