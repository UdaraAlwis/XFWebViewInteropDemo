using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace XFWebViewInteropDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultWebViewDemoPage : ContentPage
    {
        public DefaultWebViewDemoPage()
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
                        "</script>" +
                    "</head>" +

                    "<body style=\"background-color: #d4ecff;padding: 20px; border: 1px solid #2196F3;border-radius: 5px;\">" +
                        "<div>" +
                            "<p class=\"h4\">This is a simple bootstrap based HTML Web page!</p><br />" +
                            "<div id=\"textElement\" class=\"shadow p-3 mb-5 bg-white rounded\">" +
                                "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                "  Waiting for data from Xamarin.Forms..." +
                            "</div>" +
                        "</div>" +
                    "</body>" +

                    "</html>"
            };
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