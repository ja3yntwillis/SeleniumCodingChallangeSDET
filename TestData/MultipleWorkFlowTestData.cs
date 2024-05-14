using SeleniumCodingChallangeSDET.CommonReusables.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCodingChallangeSDET.TestData
{
    public class MultipleWorkFlowTestData : Config
    {
        public MultipleWorkFlowTestData() : base()
        {

        }
        public string standard_user = ParseJson(".MultipleScenarioWorkflow.username");
        public string standarduserpassword = ParseJson(".MultipleScenarioWorkflow.password");
        public string filtervalue = ParseJson(".MultipleScenarioWorkflow.filtervalue");
        public string filtertext = ParseJson(".MultipleScenarioWorkflow.filterAssert");
        public string Product1 = ParseJson(".MultipleScenarioWorkflow.Product1");
        public string Product2 = ParseJson(".MultipleScenarioWorkflow.Product2");
        public string AddToCart = ParseJson(".MultipleScenarioWorkflow.AddCartText");
        public string RemoveCart = ParseJson(".MultipleScenarioWorkflow.RemoveCartText");
        public string CardQty = ParseJson(".MultipleScenarioWorkflow.CartQty");
        public string finishPageAssertText = ParseJson(".MultipleScenarioWorkflow.FinishPageAssertText");
        public string error_user = ParseJson(".ErrorUserScenarioWorkflow.username");
        public string erroruserpassword = ParseJson(".ErrorUserScenarioWorkflow.password");
        public string errorUserProduct = ParseJson(".ErrorUserScenarioWorkflow.Product1");
        public string browserRefreshuser = ParseJson(".BrowserRefreshWorkflow.username");
        public string browserRefreshUserPass = ParseJson(".BrowserRefreshWorkflow.password");
        public string browserRefreshUserProduct = ParseJson(".BrowserRefreshWorkflow.Product1");
        public string browserRefreshAddToCart = ParseJson(".BrowserRefreshWorkflow.AddCartText");
        public string browserrefreshRemoveCart = ParseJson(".BrowserRefreshWorkflow.RemoveCartText");
        public string browserrefreshRemoveCartQty = ParseJson(".BrowserRefreshWorkflow.Qty");
        public string performence_user = ParseJson(".PerformenceUserWorkflow.username");
        public string performenceuserpassword = ParseJson(".PerformenceUserWorkflow.password");
        public string performenceUserProduct = ParseJson(".PerformenceUserWorkflow.Product1");
        public string bonususer = ParseJson(".BonusWorkflow.username");
        public string bonuspassword = ParseJson(".BonusWorkflow.password");
        public string facebooktitle = ParseJson(".BonusWorkflow.facebookTitle");
        public string twittertitle = ParseJson(".BonusWorkflow.twitterTitle");
        public string linkedintitle = ParseJson(".BonusWorkflow.linkedinTitle");
        public string swaglabstitle = ParseJson(".BonusWorkflow.SwagLabsTitle");
        public string facebook = ParseJson(".BonusWorkflow.Facebook");
        public string twitter = ParseJson(".BonusWorkflow.Twitter");
        public string linkedin = ParseJson(".BonusWorkflow.LinkedIn");





    }
}
