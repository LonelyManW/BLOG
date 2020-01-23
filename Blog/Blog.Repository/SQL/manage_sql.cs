using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repository
{
    public class manage_sql
    {
        /// <summary>
        /// 添加
        /// </summary>
        public static string insert_sql = @"INSERT INTO dt_manage (
                                                        name,
                                                        account,
                                                        password,
                                                        img,
                                                        ip,
                                                        email,
                                                        phone,
                                                        state,
                                                        status,
                                                        login_time,
                                                        reg_time,
                                                        update_time,
                                                        remark
                                                        ) VALUES(
                                                        @name,
                                                        @account,
                                                        @password,
                                                        @img,
                                                        @ip,
                                                        @email,
                                                        @phone,
                                                        @state,
                                                        @status,
                                                        @login_time,
                                                        @reg_time,
                                                        @update_time,
                                                        @remark
                                                        )";

        /// <summary>
        /// 修改
        /// </summary>
        public static string update_sql = @"UPDATE dt_manage 
                                                        SET
                                                        name=@name,
                                                        account=@account,
                                                        password=@password,
                                                        img=@img,
                                                        ip=@ip,
                                                        email=@email,
                                                        phone=@phone,
                                                        state=@state,
                                                        status=@status,
                                                        update_time=@update_time,
                                                        remark=@remark
                                                        WHERE id=@id";

        /// <summary>
        /// 修改密码
        /// </summary>
        public static string update_password_sql = @"UPDATE dt_manage SET password=@password,update_time=@update_time WHERE id=@id";
    }
}
