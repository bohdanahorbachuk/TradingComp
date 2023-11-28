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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin(LoginViewModel lvm)
        {
            InitializeComponent();
            DataContext = lvm;

            Loaded += Login_Load;
        }

        private void Login_Load(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel lvm)
            {
                lvm.LoginSuccess += () =>
                {
                    WindowSupplyList sp = App.container.Resolve<WindowSupplyList>();
                    sp.Show();
                    Close();
                };
                lvm.LoginFailed += () =>
                {
                    MessageBox.Show("No access!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                };
                lvm.Exit += () =>
                {
                    Application.Current.Shutdown();
                };
            }
        }

        public void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
