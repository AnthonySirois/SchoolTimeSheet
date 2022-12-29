// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using SchoolTimeSheet.Domain;
using Microsoft.UI.Xaml.Media.Animation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SchoolTimeSheet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditingPage : Page
    {
        private readonly List<(Type ItemType, Type PageType)> pages = new List<(Type ItemType, Type PageType)>
        {
            (typeof(Domain.Program), typeof(ProgramEditPage))
        };

        private ObservableCollection<object> crumbs;

        public EditingPage()
        {
            crumbs = new ObservableCollection<object>();

            this.InitializeComponent();

            InitializeView();
        }

        private void InitializeView()
        {
            crumbs.Clear();
            crumbs.Add(Controller.Instance.Program);

            Navigate(crumbs.First().GetType(), new EntranceNavigationTransitionInfo());
        }

        private void NavigationCrumbBar_ItemClicked(BreadcrumbBar sender, BreadcrumbBarItemClickedEventArgs args)
        {
            if(args.Index < crumbs.Count - 1)
            {
                if (args.Index == 0)
                {
                    InitializeView();
                }
                else
                {
                    var crumbItem = crumbs[args.Index];                    
                    Navigate(crumbItem.GetType(), new EntranceNavigationTransitionInfo());

                    while (crumbs.Count > args.Index + 1)
                    {
                        crumbs.RemoveAt(crumbs.Count - 1);
                    }
                }
            }
        }

        private void Navigate(Type navigationItemType, NavigationTransitionInfo transitionInfo)
        {
            var item = pages.FirstOrDefault(p => p.ItemType == navigationItemType);
            Type page = item.PageType;

            var preNavigationPagetype = ContentFrame.CurrentSourcePageType;

            if (page != null && preNavigationPagetype != page)
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }
    }
}
