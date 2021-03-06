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

        private async void GoToDefaultWebViewButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DefaultWebViewDemoPage());
        }

        private async void GoToHybridWebViewButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HybridWebViewDemoPage());
        }

        private async void GoToHybridWebViewChatButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HybridWebViewChatDemoPage());
        }
    }
}
