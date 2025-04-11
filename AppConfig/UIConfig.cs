using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConfig
{
    public class Configs
    {
        public const string URL = "https://magento.softwaretestingboard.com/#contentarea";
        public const string PostLoginURL = "https://magento.softwaretestingboard.com/";
        public const string PreSignInBtn = "//div[contains(@class,'page-wrapper')]//ul[contains(@class,'header links')]/li[contains(@class,'authorization-link')]//a[contains(text(),'        Sign In    ')]";
        public const string usernameXpath = "//input[contains(@name,'login[username]')]";
        public const string passwordXpath = "//input[contains(@name,'login[password]')]";
        public const string LgnBtnXpath = "//div[contains(@class,'primary')]//button[contains(@type,'submit')]";
        public const string LogoutBtnXpath = "//div[contains(@class,'bm-menu')]//nav//a[contains(text(),'Logout')]";
        public const string HoverFirstProdXpath = "//div[contains(@class,'products-grid grid')]//div[contains(@class,'product-item-info')]//span//img[contains(@alt,'Radiant Tee')]";
        public const string SizeXpath = "//div[contains(@class,'product-item-details')]//div[contains(@class,'swatch-opt-1556')]//div[contains(@option-id,'167')]";
        public const string ColorXpath = "//div[contains(@class,'product-item-details')]//div[contains(@class,'swatch-opt-1556')]//div[contains(@option-id,'50')]";
        public const string AddCartMsgXpath= "//div[contains(@class,'page messages')]//div[contains(@class,'message-success success message')]";

        public const string AddcartBtnXpath = "//div[contains(@class,'product-item-inner')]//div[contains(@class,'actions-primary')]//form[contains(@data-product-sku,'WS12')]//button";


    }


}
