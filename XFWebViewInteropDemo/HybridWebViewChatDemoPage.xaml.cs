using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFWebViewInteropDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HybridWebViewChatDemoPage : ContentPage
    {
        public HybridWebViewChatDemoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            webViewElement.Source = new HtmlWebViewSource()
            {
                Html =
                    $@"<html>" +
                    "<head>" +
                        "<meta charset=\"utf-8\">" +
                        "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">" +
                        "<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css\" " +
                        "integrity=\"sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh\" crossorigin=\"anonymous\">" +

                        "<script type=\"text/javascript\">" +
                            "function updatetextonwebview(text) {" +
                            "    document.getElementById(\"textElement\").innerHTML = text;" +
                            "}" +
                            "function invokexamarinforms(){" +
                            "    try{" +
                            "        var inputvalue = document.getElementById(\"textInputElement\").value;" +
                            "        invokeCSharpAction(inputvalue);" +
                            "    }" +
                            "    catch(err){" +
                            "        alert(err);" +
                            "    }" +
                            "}" +
                        "</script>" +
                    "</head>" +
                    "<body style=\"background-color: #d4ecff;padding: 20px; border: 1px solid #2196F3;border-radius: 5px;\">" +
                        "<div>" +
                            "<p class=\"h4\">This is a HTML Web page!</p>" +
                        "</div>"+
                        "<div>" +
                            "<div class=\"form-group\">" +
                                "<input type=\"text\" class=\"form-control form-control-lg\" id=\"textInputElement\" placeholder=\"type something here...\">" +
                            "</div>" +
                            "<div class=\"form-group\">" +
                                "<button type=\"button\" class=\"btn btn-lg btn-primary btn-block\" onclick=\"invokexamarinforms()\">Send to Xamarin.Forms</button>" +
                            "</div>" +
                        "</div>" +

                        "<div>" +
                            "<h1 style=\"font-size: 2.5rem;\" class=\"display-4\" id=\"textElement\" >Waiting for data from Xamarin.Forms...</h1>" +
                        "</div>" +
                    "</body>" +

                    "</html>"
            };

            webViewElement.RegisterAction(DisplayDataFromJavascript);
        }

        private void DisplayDataFromJavascript(string data)
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                textFromWebViewLabel.Text = data;
            });
        }

        private async void sendToWebViewButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textEntryElement.Text))
            {
                string result = await webViewElement.EvaluateJavaScriptAsync($"updatetextonwebview('{textEntryElement.Text}')");
            }
        }
    }
}