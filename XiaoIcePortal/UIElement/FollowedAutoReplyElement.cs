using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoIcePortal.UIElement
{
    public class FollowedAutoReplyElement
    {
        public static string TextInput= "//*[@id='autoreply_content']/div/div[1]/div[2]/div[1]/textarea";
        public static string Bottom_Save= "//*[@id='bottom_save']";
        public static string tabnews= "//*[@id='tabnews']/span";
        public static string tabimage ="//*[@id='tabimage']/i";
        public static string tabvideo= "//*[@id='tabvideo']/span/span";
        public static string tabvoice = "//*[@id='tabvoice']";
        public static string autoreply_content= "//*[@id='autoreply_content']/div/a";

        public static string ImageChoose= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[2]/span";
        public static string EditImage= "//*[@id='choosetbox_wrapper']/div/div[2]/div[2]/div[1]/div[1]/img";
        public static string NewsChoose= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[1]/h4/a";
        public static string EditNews= "//*[@id='choosetbox_wrapper']/div/div[2]/div[2]/div[1]/div[1]/h4/a";
        public static string Next_Page_Image_Input= "//*[@id='choosetbox_wrapper']/div/div[3]/input";

        public static string Next_Page_Image_Input_Go= "//*[@id='choosetbox_wrapper']/div/div[3]/a[3]";
        public static string VideoChoose = "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[1]/h4";
        public static string VideoEdit = "//*[@id='choosetbox_wrapper']/div/div[2]/div[2]/div[1]/div[3]";

        public static string Confirm= "//*[@id='choosetbox_wrapper']/div/div[5]/a[1]";

        public static string Delete= "//*[@id='bottom_del']";
        public static string DeleteImage= "//*[@id='autoreply_content']/div/a";
        public static string Delete_Confirm= "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";

        public static string AddedAutoReply= "//*[@id='autoreply_content']/div/div[1]/div[1]/div[2]/div[2]/div[1]";
        public static string AddedImageAndText= "//*[@id='autoreply_content']/div/div/div/div[1]/h4/a";
        public static string AddedImage= "//*[@id='autoreply_content']/div/div/div/div[1]/div[2]/span";
        public static string AddedVideo= "//*[@id='autoreply_content']/div/div/div/div[1]/div[1]/h4";
        public static string AddedAudio = "//*[@id='autoreply_content']/div/div/div/div[1]/div[2]/div[1]/span[2]";
        public static string Alert_Failure_Confirm= "//*[@id='alertbox_wrapper']/div/div[3]/a";



        public static string H5OfficialAccount= "//android.view.View[contains(@resource-id,'com.tencent.mm:id/s4')]"; 
    }
}
