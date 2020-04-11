using FindU.MenuItems;
using FindU.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindU
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            InitializeMenuList();
           
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Encounters)));
            BindingContext = new
            {
                FirstName = "Mikita",
                LastName = "Ishchanka",
                Image = "Me.jiff",
                Footer = "@BSU, Minsk, 2020"
            };
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        private void InitializeMenuList()
        {
            MenuList = new List<MasterPageItem>();
            AddMenuItem("Encounters", "Me.jiff", typeof(Encounters));
            AddMenuItem("Messages", "Me.jiff", typeof(Messages));
            AddMenuItem("Matched", "Me.jiff", typeof(Matched));
            AddMenuItem("Liked you", "Me.jiff", typeof(Likes));
            AddMenuItem("Visitors", "Me.jiff", typeof(Guests));
            navigationDrawerList.ItemsSource = MenuList;
        }

        private void AddMenuItem(string title, string icon, Type targetType)
        {
            MenuList.Add(new MasterPageItem
            {
                Title = title,
                Icon = icon,
                TargetType = targetType
            });
        }
    }
}
