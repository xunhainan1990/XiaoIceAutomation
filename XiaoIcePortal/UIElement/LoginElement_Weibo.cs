﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoIcePortal.UIElement.Weibo
{
     public class LoginElement_Weibo
    {
        public static string register = "/html/body/div/div[1]/div/div[2]/span/a[1]";
        public static string AuthButton = "//*[@id='registerTabPanel']/div[3]/a";

        public static string Weiboauth = "//*[@id='registerTabPanel']/div[2]/button[2]";
        public static string WeiboAccount = "//*[@id='userId']";
        public static string WeiboPassword = "//*[@id='passwd']";
        public static string WeiboSubmit = "//*[@id='outer']/div/div[2]/form/div/div[2]/div/p/a[1]";
        public static string AuthSubmitButton = "//*[@id='outer']/div/div[2]/form/div/div[2]/div/p/a[1]";
        public static string warp_phoneNumber_tips = "//*[@id='warp_phoneNumber_tips']";
        public static string warp_verification_tips = "//*[@id='warp_verification_tips']";
        public static string I_Agree = "//*[@id='registerTabPanel']/div[3]/div[3]/label/input";
    }
}
