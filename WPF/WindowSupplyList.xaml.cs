using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModels;
using Unity;

namespace WPF
{
    /// <summary>
    /// Interaction logic for WindowSupplyList.xaml
    /// </summary>
    public partial class WindowSupplyList : Window
    {
        LoginViewModel lvm;
        AddSupplyViewModel asvm;

        public WindowSupplyList(SupplyListViewModel slvm, LoginViewModel lvm)
        {
            DataContext = slvm;
            this.lvm = lvm;
            InitializeComponent();

            Loaded += StartPage_Loaded;
        }

        private void StartPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SupplyListViewModel slvm)
            {
                slvm.LogOut += () =>
                {
                    WindowLogin lp = new WindowLogin(lvm);
                    lp.Show();
                    Close();
                };
                slvm.ShowAddS += () =>
                {
                    WindowAddSupply was = new WindowAddSupply(asvm);
                    was.ShowDialog();
                };
            }
        }
    }

}
