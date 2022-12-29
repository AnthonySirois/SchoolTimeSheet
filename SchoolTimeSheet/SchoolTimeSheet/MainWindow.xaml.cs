// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using SchoolTimeSheet.Domain;
using SchoolTimeSheet.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SchoolTimeSheet
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly List<(string Tag, Type PageType)> pages = new List<(string Tag, Type PageType)>
        {
            ("home", typeof(HomePage)),
            ("edit", typeof(EditingPage)),
            ("statistics", typeof(StatisticsPage)),
            ("settings", typeof(SettingPage))
        };

        public MainWindow()
        {
            this.InitializeComponent();

            InitializeTitleBar();
        }

        private void InitializeTitleBar()
        {
            if(AppWindowTitleBar.IsCustomizationSupported())
            {
                ExtendsContentIntoTitleBar = true;
                SetTitleBar(AppTitleBar);
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }

        public void Mock()
        {
            
            //https://www.fluidui.com/editor/live/
            /*
                 Day Day Day Day Day Day Day Total
            Class
            Class
            Class
            Class
            Total
             */
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            Home.IsSelected = true;

            NavigationView_Navigate("home", new EntranceNavigationTransitionInfo());
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingsInvoked)
            {
                NavigationView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigationView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavigationView_Navigate(string navigationItemTag, NavigationTransitionInfo transitionInfo)
        {
            var item = pages.FirstOrDefault(p => p.Tag == navigationItemTag);
            Type page = item.PageType;

            var preNavigationPagetype = ContentFrame.CurrentSourcePageType;

            if(page != null && preNavigationPagetype != page)
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }

        
    }
}
