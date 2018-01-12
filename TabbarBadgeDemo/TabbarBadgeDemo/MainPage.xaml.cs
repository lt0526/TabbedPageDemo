using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabbarBadgeDemo
{
	public partial class MainPage : ContentPage
	{

        public int Myid { set; get; }
		public MainPage()
		{
			InitializeComponent();
            MyBtn.Clicked += MyBtn_Clicked;
            RemoveBtn.Clicked += RemoveBtn_Clicked;

            Myid = 0;
		}       

        private void MyBtn_Clicked(object sender, EventArgs e)
        {
            BadgeText = string.Format("{0}", ++Myid);
        }

        private void RemoveBtn_Clicked(object sender, EventArgs e)
        {
            if (Myid > 0)
            {
                --Myid;
                if (Myid == 0)
                {
                    BadgeText = null;
                }
                else
                {
                    BadgeText = string.Format("{0}", Myid);
                }
            } 
        }

        public static readonly BindableProperty BadgeTextProperty = BindableProperty.Create(nameof(BadgeText), typeof(string), typeof(MainPage), "0");
        public string BadgeText
        {
            set
            {
                SetValue(BadgeTextProperty, value);
            }
            get
            {
                return (string)GetValue(BadgeTextProperty);
            }
        }
    }
}
