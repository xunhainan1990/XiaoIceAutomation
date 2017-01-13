using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoIcePortal.UIElement
{
    public class MenuElement
    {
        public static string add_menu_item_btn = "//*[@id='add_menu_item_btn']";

        public static string MenuInputBox="//*[@id='inputbox_wrapper']/div/div[3]/input";
        public static string MenuAddConfirm= "//*[@id='inputbox_wrapper']/div/div[4]/a[1]";
        public static string Jump_Page_Button="//*[@id='menuitem']/div[2]/div[2]/div[3]/a/div[1]";
        public static string SubMenu_Jump_Page_Button= "//*[@id='menuitem']/div[2]/div[2]/div[2]/a";
        public static string JumpLinkInput= "//*[@id='menuitem']/div[2]/div[2]/div/input";
        public static string Send_Message= "//*[@id='menuitem']/div[2]/div[2]/div[2]/a";
        public static string SubMenu_Send_Message= "//*[@id='menuitem']/div[2]/div[2]/div[1]/a/div[1]";
        public static string bottom_save="//*[@id='bottom_save']";

        //public static string  "//*[@id="menuitem"]/div[2]/div[2]/div[2]/a";
        //*[@id="menuitem"]/div[2]/div[2]/div[2]/a
        public static string Confirm = "//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string DeleteMenuButton= "//*[@id='bottom_del']";
        public static string DeleteMenuButtonConfirm="//*[@id='confirmbox_wrapper']/div/div[3]/a[1]";
        public static string FaceRankingMenu= "//*[@id='menu']/li/span[1]";
        public static string TextInput= "//*[@id='autoreply_content']/div/div[1]/div[2]/div[1]/textarea";
        public static string tabImage= "//*[@id='tabimage']/span";
        public static string tabNews= "//*[@id='tabnews']/span/span";
        public static string tabVoice= "//*[@id='tabvoice']";
        public static string tabVideo= "//*[@id='tabvideo']/span";
        public static string ImageChoose= "//*[@id='autoreply_content']/div/a/div[1]";
        public static string ImageLink= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[1]/img";
        public static string NewsLink = "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[1]/div[2]/img";

        public static string VoiceLink= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[2]/div[1]/span[2]";
        public static string VideoLink= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]";
        public static string ChooseConfirm= "//*[@id='choosetbox_wrapper']/div/div[5]/a[1]";
        public static string validator_Link = "//android.widget.Image[contains(@resource-id,'hplogo')]";

        public static string GoBack= "//*[@id='menuitem']/div[2]/div[1]/a";
        public static string Delete= "//*[@id='autoreply_content']/div/a";
        public static string DeleteMenuItem= "//*[@id='menuitem']/div[1]/a[1]";

        public static string Error= "//*[@id='inputbox_wrapper']/div/div[3]/div";
        public static string Cancle= "//*[@id='inputbox_wrapper']/div/div[4]/a[2]";
        public static string notification= "//*[@id='notification_wrapper']";
        public static string Alert_Failure= "//*[@id='alertbox_wrapper']/div/div[2]";
        public static string Alert_Failure_Confirm= "//*[@id='alertbox_wrapper']/div/div[3]/a";
        public static string addedMenu= "//*[@id='menu']/li/span[1]";
        public static string AddedLevelTwo=  "//*[@id='menu']/li[7]";
        public static string AddedMenu_Description= "//*[@id='menuitem']/div[2]/div[1]";
        public static string SubMenuFromMenu= "//*[@id='menuitem']/div[2]/div[2]/div/a/div[2]";
        public static string SecondMenu ="//*[@id='menu']/li[2]/span[1]";
        public static string ThirdMenu= "//*[@id='menu']/li[3]/span[1]";
        public static string AddedNews= "//*[@id='autoreply_content']/div/div/div/div[1]/h4/a";
        public static string AddSubMenu ="//*[@id='menu']/li/span[2]";
        public static string AddSubMenu_LevelTwo= "//*[@id='menu']/li[7]/span[2]";
        public static string SubMenu_SendMessage= "//*[@id='menuitem']/div[2]/div[2]/div[1]/a/div[1]";

        public static string Notification= "//*[@id='notification_wrapper']/div";

        //*[@id="choosetbox_wrapper"]/div/div[2]/div[1]/div[1]/div[1]/img
        //public static string Image_NextPage= "//*[@id='choosetbox_wrapper']/div/div[2]/div[1]/div[1]/div[1]/img";

        public static string ResetMenu= "//*[@id='menuitem']/div[2]/div[1]/a";

        public static string Account_Arrow_Down= "/html/body/div/div[1]/div/div[1]/div[3]";
        public static string Logout= "/html/body/div/div[1]/div/div[1]/div[4]/div[3]/a[2]";
        public static string NoMaterial_Tip= "//*[@id='choosetbox_wrapper']/div/div[2]";
    }
}
