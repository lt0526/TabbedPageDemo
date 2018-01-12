using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TabbarBadgeDemo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MyTabbarPage tabbedPage = new MyTabbarPage();
			MainPage = tabbedPage;

            tabbedPage.Children.Add(new MainPage
            {
                Title = "FirstPage"
            });

            tabbedPage.Children.Add(new MainPage
            {
                Title = "SecondPage"
            });
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
