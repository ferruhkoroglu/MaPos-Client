using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.Utils;
using DevExpress.Utils.Html;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;


namespace MaSoft.MaPos.Core
{
    public static class MessageHelper
    {
        private static HtmlTemplateCollection? htmlContainer;
        private static SvgImageCollection? svgImageCollection1;

        public static List<HtmlTemplateInfo> TemplateInfos = new List<HtmlTemplateInfo>
        {
            new HtmlTemplateInfo()
            {
                TemplateName = "TemplateErrorMsg",
                HtmlContent = "<div class=\"frame\" id=\"frame\">\r\n\t<div class=\"header\">\r\n\t\t<div class=\"header-element caption\">${Caption}</div>\r\n\t\t<div class=\"header-element close-button\" id=\"closebutton\">\r\n\t\t\t<img src=\"close\" class=\"close-button-img\">\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"message-text\" id=\"content\">${MessageText}</div>\r\n\t<div class=\"buttons\">\r\n\t\t<div class=\"button\" tabindex=\"1\" id=\"dialogresult-ok\">TAMAM</div>\r\n\t</div>\r\n</div>",
                CssContent =  "body{\r\n\tpadding: 15px;\r\n\tfont-size: 14px;\r\n\tfont-family: 'Segoe UI';\r\n}\r\n.frame {\r\n\tmin-width: 470px;\r\n\tbackground-color: @Window;\r\n\tborder-radius: 10px;\r\n\tbox-shadow: 0px 8px 10px 0px rgba(0, 0, 0, 0.2);\r\n}\r\n.header {\r\n\tbackground-color: @Critical;\r\n\tpadding: 5px;\r\n\tdisplay: flex;\r\n\talign-items: center;\r\n\tjustify-content: space-between;\r\n\tborder-radius: 10px 10px 0px 0px;\r\n}\r\n.header-element {\r\n\tmargin: 5px 5px 5px 25px;\r\n}\r\n.caption {\r\n\tcolor: @White;\r\n\tfont-weight: bold;\r\n}\r\n.close-button-img {\r\n\tfill: @White;\r\n\twidth: 18px;\r\n\theight: 18px;\r\n\topacity: 0.8;\r\n}\r\n.close-button {\r\n\tpadding: 5px;\r\n\tborder-radius: 4px;\r\n}\r\n.close-button:hover {\r\n\tbackground-color: @WindowText/0.1;\r\n}\r\n.close-button:active {\r\n\tbackground-color: @ControlText/0.05;\r\n}\r\n.message-text {\r\n\tmargin: 15px 30px;\r\n\tfont-size: 14px;font-weight: bold; \r\n\twhite-space: pre;\r\n\tcolor: @WindowText/0.8;\r\n}\r\n.buttons {\r\n\tmargin: 10px;\r\n\tdisplay: flex;\r\n\tjustify-content: flex-end;\r\n}\r\n.button {\r\n\tcolor: @Critical;\r\n\tborder-radius: 5px;\r\n\tpadding: 8px 24px;\r\n\tmargin: 0px 5px;\r\n\tborder: solid 1px @Transparent;\r\n}\r\n.button:hover {\r\n\tcolor: @White;\r\n\tbackground-color: @Critical;\r\n\tbox-shadow: 0px 0px 10px @Critical/0.5;\r\n}\r\n.button:focus {\r\n\tborder-color: @Critical;\r\n}"
            },
            new HtmlTemplateInfo()
            {
                TemplateName = "TemplateSuccessMsg",
                HtmlContent = "<div class=\"frame\" id=\"frame\">\r\n    <div class=\"header\">\r\n        <div class=\"caption\">${Caption}</div>\r\n    \t<div class=\"close-button\" id=\"closebutton\">\r\n\t\t\t<img src=\"close\" class=\"close-button-img\" id=\"close\">\r\n\t\t</div>\r\n    </div>\r\n    <div class=\"content\" id=\"content\">\r\n    \t<img src=\"${MessageIcon}\" class=\"message icon\">\r\n    \t<div class=\"message text\">${MessageText}</div>\r\n    \t<div class=\"message button\" tabindex=\"1\" id=\"dialogresult-ok\">OK</div>\r\n    </div>\r\n</div>",
                //CssContent =  "body{\t\r\n\tpadding: 20px;\r\n\tfont-size: 14px;\r\n\tfont-family: 'Segoe UI';\r\n}\r\n.frame {\r\n\twidth: 450px;\r\n\tcolor: @ControlText;\r\n\tbackground-color: @Window;\r\n\tborder: 1px solid @Success;\r\n\tborder-radius: 16px;\r\n\tdisplay: flex;\r\n\tflex-direction: column;\r\n\tjustify-content: center;\r\n\tbox-shadow: 0px 8px 16px @Success/0.6;\r\n}\r\n.header {\r\n\tpadding: 8px;\r\n\tcolor: @White;\r\n\tbackground-color: @Success;\r\n\tborder-radius: 15px 15px 0px 0px;\r\n\tdisplay: flex;\r\n\tjustify-content: space-between;\r\n\talign-items: center;\r\n}\r\n.caption {\r\n\tmargin: 0px 10px;\r\n\tfont-weight: bold;\r\n}\r\n.close-button {\r\n\tpadding: 8px;\r\n\tborder-radius: 5px;\r\n}\r\n.close-button:hover {\r\n\tbackground-color: @WindowText/0.1;\r\n}\r\n.close-button:active {\r\n\tbackground-color: @ControlText/0.05;\r\n}\r\n.close-button-img {\r\n\tfill: White;\r\n\twidth: 18px;\r\n\theight: 18px;\r\n\topacity: 0.8;\r\n}\r\n.content {\r\n\tdisplay: flex;\r\n\talign-items: center;\r\n\tflex-direction: column;\r\n\tpadding: 10px;\r\n}\r\n.message {\r\n\tmargin: 7px;\r\n}\r\n.icon {\r\n\twidth: 48px;\r\n\theight: 48px;\r\n\topacity: 0.8;\r\n}\r\n.text {\r\n\tcolor: @ControlText;\r\n\ttext-align: center;\r\n}\r\n.button {\r\n\tcolor: @Success;\r\n\tpadding: 8px 24px;\r\n\tborder: 1px solid @Success;\r\n\tborder-radius: 5px;\r\n}\r\n.button:hover {\r\n\tcolor: @White;\r\n\tbackground-color: @Success;\r\n\tbox-shadow: 0px 0px 10px @Success/0.5;\r\n}"
                CssContent  = "body{\t\r\n\tpadding: 20px;\r\n\tfont-size: 14px;\r\n\tfont-family: 'Segoe UI';\r\n}\r\n.frame {\r\n\twidth: 450px;\r\n\tcolor: @ControlText;\r\n\tbackground-color: White;\r\n\tborder: 1px solid #ffc21a;\r\n\tborder-radius: 16px;\r\n\tdisplay: flex;\r\n\tflex-direction: column;\r\n\tjustify-content: center;\r\n\tbox-shadow: 0px 8px 16px #ffc21a;\r\n}\r\n.header {\r\n\tpadding: 8px;\r\n\tcolor: @White;\r\n\tbackground-color: #ffc21a;\r\n\tborder-radius: 15px 15px 0px 0px;\r\n\tdisplay: flex;\r\n\tjustify-content: space-between;\r\n\talign-items: center;\r\n}\r\n.caption {\r\n\tmargin: 0px 10px;\r\n\tfont-weight: bold;\r\n\tcolor: black;\r\n}\r\n.close-button {\r\n\tpadding: 8px;\r\n\tborder-radius: 5px;\r\n}\r\n.close-button:hover {\r\n\tbackground-color: @WindowText/0.1;\r\n}\r\n.close-button:active {\r\n\tbackground-color: @ControlText/0.05;\r\n}\r\n.close-button-img {\r\n\tfill: White;\r\n\twidth: 18px;\r\n\theight: 18px;\r\n\topacity: 0.8;\r\n}\r\n.content {\r\n\tdisplay: flex;\r\n\talign-items: center;\r\n\tflex-direction: column;\r\n\tpadding: 10px;\r\n}\r\n.message {\r\n\tmargin: 7px;\r\n}\r\n.icon {\r\n\twidth: 48px;\r\n\theight: 48px;\r\n\topacity: 0.8;\r\n}\r\n.text {\r\n\tcolor: black;\r\n\tfont-weight: bold;\r\n\ttext-align: center;\r\n}\r\n.button {\r\n\tcolor: #ffc21a;\r\n\tfont-weight: bold;\r\n\tpadding: 8px 24px;\r\n\tborder: 1px solid #ffc21a;\r\n\tborder-radius: 5px;\r\n}\r\n.button:hover {\r\n\tcolor: @White;\r\n\tbackground-color: @Success;\r\n\tbox-shadow: 0px 0px 10px @Success/0.5;\r\n}"
            },
            new HtmlTemplateInfo()
            {
                TemplateName = "TemplateQuestionMsg",
                HtmlContent = "<div class=\"frame\" id=\"frame\">\r\n\t<div class=\"content\">\r\n\t    <div class=\"text caption\">${Caption}</div>\r\n\t\t<div id=\"content\">\r\n\t\t   \t<div class=\"text message\">${MessageText}</div>\r\n\t\t</div>\r\n\t</div>\r\n\t<div class=\"buttons\">\r\n\t\t<div class=\"button\" tabindex=\"1\" id=\"dialogresult-yes\">Evet</div>\r\n    \t<div class=\"button\" tabindex=\"2\" id=\"dialogresult-no\">Hayır</div>\r\n    </div>\r\n</div>",
                CssContent =  "body{\r\n\tpadding: 15px;\r\n\tfont-size: 10pt;\r\n\tfont-family: \"Segoe UI\";\r\n\ttext-align: center;\r\n}\r\n.frame{\r\n\tcolor: @ControlText;\r\n\tbackground-color: @White;\r\n\tborder: 1px solid @Black/0.2;\r\n\tborder-radius: 10px;\r\n\tbox-shadow: 0px 5px 10px 0px rgba(0, 0, 0, 0.2);\r\n}\r\n.content {\r\n\tpadding: 15px;\r\n}\r\n.text {\r\n\tpadding: 10px;\r\n\ttext-align: left;\r\n}\r\n.caption {\r\n\tfont-size: 15pt;\r\n\tfont-family: 'Segoe UI Semibold';\r\n}\r\n.message {\r\n\twhite-space: pre;\r\n}\r\n.buttons {\r\n\tbackground-color: @Control;\r\n\tpadding: 20px;\r\n\tdisplay: flex;\r\n\tflex-direction: row;\r\n\tjustify-content: center;\r\n\tborder-top: 1px solid @Black/0.1;\r\n\tborder-radius: 0px 0px 10px 10px;\r\n}\r\n.button {\r\n\tcolor: @WindowText;\r\n\tbackground-color: @White;\r\n\tmin-width: 80px;\r\n\tmargin: 0px 5px;\r\n\tpadding: 5px;\r\n    border: 1px solid @Black/0.15;\r\n    border-radius: 5px;\r\n}\r\n.button:hover {\r\n\tbackground-color: @Black/0.1;\r\n}\r\n.button:focus {\r\n\tbackground-color: @HighlightAlternate;\r\n\tborder: 1px solid @HighlightAlternate;\r\n\tcolor: @White;\r\n}"
            }
        };

        public static void Initialize()
        {
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection();
            svgImageCollection1.BeginInit();

            // svgImageCollection1
            svgImageCollection1.Add("actions_check", "image://svgimages/icon builder/actions_check.svg");
            svgImageCollection1.Add("actions_checkcircled", "image://svgimages/icon builder/actions_checkcircled.svg");
            svgImageCollection1.Add("warning", "image://svgimages/status/warning.svg");
            svgImageCollection1.Add("security_warningcircled1", "image://svgimages/icon builder/security_warningcircled1.svg");
            svgImageCollection1.Add("actions_deletecircled", "image://svgimages/icon builder/actions_deletecircled.svg");
            svgImageCollection1.Add("actions_info", "image://svgimages/icon builder/actions_info.svg");
            svgImageCollection1.Add("close", "image://svgimages/diagramicons/del.svg");
            svgImageCollection1.Add("actions_comment", "image://svgimages/icon builder/actions_comment.svg");
            svgImageCollection1.Add("newcomment", "image://svgimages/richedit/newcomment.svg");

            svgImageCollection1.EndInit();

            htmlContainer = new HtmlTemplateCollection();
            htmlContainer.Items.Add(
                    new HtmlTemplate()
                    {
                        Name = TemplateInfos[0].TemplateName,
                        Template = TemplateInfos[0].HtmlContent,
                        Styles = TemplateInfos[0].CssContent
                    }
                );
            htmlContainer.Items.Add(
                    new HtmlTemplate()
                    {
                        Name = TemplateInfos[1].TemplateName,
                        Template = TemplateInfos[1].HtmlContent,
                        Styles = TemplateInfos[1].CssContent
                    }
                );
            htmlContainer.Items.Add(
                    new HtmlTemplate()
                    {
                        Name = TemplateInfos[2].TemplateName,
                        Template = TemplateInfos[2].HtmlContent,
                        Styles = TemplateInfos[2].CssContent
                    }
                );
        }

        public static void WarningMsg(string Msg)
        {
            //
        }

        public static void ErrorMsg(string HeaderCaption, string MsgInfo)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();

            args.HtmlTemplate.Assign(htmlContainer[0]);
            args.HtmlImages = svgImageCollection1;

            args.Caption = HeaderCaption;
            args.Text = MsgInfo;

            args.DefaultButtonIndex = 0;
            var result = XtraMessageBox.Show(args);
        }

        public static void SuccessMsg(string HeaderCaption, string MsgInfo)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();

            args.HtmlTemplate.Assign(htmlContainer[1]);
            args.HtmlImages = svgImageCollection1;

            args.Caption = HeaderCaption;
            args.Text = MsgInfo;

            args.ImageOptions.SvgImage = svgImageCollection1[8];
            args.DefaultButtonIndex = 0;

            var result = XtraMessageBox.Show(args);
        }

        /* 
         * Örnek Kullanım...
         * DialogResult QuestionResult =  MessageHelper.QuestionMsg("Veritabanı bilgileri", "Girilen bilgiler doğru mu ?");
           if (QuestionResult == DialogResult.No)
            return;
         */
        public static DialogResult QuestionMsg(string HeaderCaption, string MsgInfo)
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.HtmlTemplate.Assign(htmlContainer[2]);
            args.HtmlImages = svgImageCollection1;

            args.Caption = HeaderCaption;
            args.Text = MsgInfo;

            args.DefaultButtonIndex = 0;
            
            var result = XtraMessageBox.Show(args);
            return result;
        }
    }

    public class HtmlTemplateInfo
    {
        public string? TemplateName;
        public string? HtmlContent;
        public string? CssContent;
    }
}
