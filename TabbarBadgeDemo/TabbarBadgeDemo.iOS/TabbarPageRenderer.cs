using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TabbarBadgeDemo;
using TabbarBadgeDemo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyTabbarPage), typeof(TabbarPageRenderer))]
namespace TabbarBadgeDemo.iOS
{
    public class TabbarPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }


        public override void ViewWillAppear(bool animated)
        {
            if (TabBar == null) return;
            if (TabBar.Items == null) return;

            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateItem(TabBar.Items[i], tabs.Children[i].Icon);
                    tabs.Children[i].PropertyChanged += TabbarPageRenderer_PropertyChanged;
                }
            }
            base.ViewWillAppear(animated);
        }

        private void TabbarPageRenderer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var page = sender as Page;
            if (page == null)
                return;

            if (e.PropertyName == "BadgeText")
            {
                if (CheckValidTabIndex(page, out int tabIndex))
                {
                    switch(tabIndex)
                    {
                        case 0:
                            UpdateBadge(TabBar.Items[tabIndex], (page as MainPage).BadgeText);
                            break;
                        case 1:
                            UpdateBadge(TabBar.Items[tabIndex], (page as MainPage).BadgeText);
                            break;
                        default:
                            break;
                    }
                }   
                return;
            }
        }

        public bool CheckValidTabIndex(Page page, out int tabIndex)
        {
            tabIndex = Tabbed.Children.IndexOf(page);
            return tabIndex < TabBar.Items.Length;
        }

        private void UpdateItem(UITabBarItem item, string icon)
        {
            TabBar.UnselectedItemTintColor = UIColor.Red;
            item.BadgeColor = UIColor.Red;
        }

        private void UpdateBadge(UITabBarItem item, string badgeText)
        {
            item.BadgeValue = badgeText;
        }
    }
}