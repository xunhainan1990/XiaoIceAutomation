using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonElement
    {
        public static string AllSkills = "/html/body/div/div[2]/div[2]/div[2]/div/div/h3/a";
        public static string TurnOnAndOFF = "/html/body/div/div[2]/div[2]/div[2]/div/div/div[1]/div[3]";
        public static string Confirm = "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string ImageConfirm= "//*[@id='choosetbox_wrapper']/div/div[5]/a[1]";
        public static string notification= "//*[@id='notification_wrapper']/div";

        public static string Next_Page = "//*[@id='choosetbox_wrapper']/div/div[3]/a[2]";
        public static string Next_Page_Input="//*[@id='choosetbox_wrapper']/div/div[3]/input";
        public static string Next_Page_Input_Go = "//*[@id='choosetbox_wrapper']/div/div[3]/a[3]";
        public static string Previous_Page = "//*[@id='choosetbox_wrapper']/div/div[3]/a[1]";
    }
}
