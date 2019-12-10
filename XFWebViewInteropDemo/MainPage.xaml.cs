﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFWebViewInteropDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
                             "<p class=\"h4\">Hello there! this is a HTML Webpage!</p>" +
                             "<div id=\"textElement\" class=\"shadow p-3 mb-5 bg-white rounded\">" +
                                 "<span class=\"spinner-grow spinner-grow-sm\" role=\"status\" aria-hidden=\"true\" ></span>" +
                                 "  waiting for data from Xamarin.Forms..." +
                             "</div>" +
                         "</div>" +
                     "</body>" +

                "</html>"
            };
        }

        private async void textEntryElement_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string result = await webViewElement.EvaluateJavaScriptAsync($"updatetextonwebview('{textEntryElement.Text}')");
        }
    }
}
