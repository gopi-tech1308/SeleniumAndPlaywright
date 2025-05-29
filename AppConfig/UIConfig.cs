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
        public const string LogoutURL = "https://magento.softwaretestingboard.com/customer/account/logoutSuccess/";
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
        public const string CartXpath = "//div[contains(@class,'page-wrapper')]//div[contains(@class,'header content')]//div[contains(@data-block,'minicart')]/a[contains(@class,'action showcart')]";
        public const string DeleteXpath = "//div[contains(@data-action,'scroll')]//div[contains(@class,'product')]//div[contains(@class,'secondary')]/a[contains(@class,'action delete')]";
        public const string DeleteConfirmOkXpath = "//div[contains(@class,'modals-wrapper')]//div[contains(@class,'modal-inner-wrap')]//footer[contains(@class,'modal-footer')]//button[contains(@class,'action-primary action-accept')]";
        public const string CartCountXpath = "//div[contains(@class,'page-wrapper')]//div[contains(@class,'header content')]//div[contains(@class,'block-content')]/strong[contains(text(),'You have no items in your shopping cart.')]";
        public const string NavBarXpath = "//div[contains(@class,'page-wrapper')]//ul[contains(@class,'header links')]//li[contains(@class,'customer-welcome')]//button";
        public const string AccountXpath = "//div[contains(@class,'sections nav-sections')]//div/a[contains(text(),'Account')]";
        public const string SignoutXpath = "//div[contains(@class,'page-wrapper')]//ul[contains(@class,'header links')]//li[contains(@class,'customer-welcome')]//div[contains(@class,'customer-menu')]//ul/li[contains(@class,'authorization-link')]/a";


    }


}
