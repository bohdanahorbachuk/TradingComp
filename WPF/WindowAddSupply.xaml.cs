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

namespace WPF
{
    /// <summary>
    /// Interaction logic for WindowAddSupply.xaml
    /// </summary>
    public partial class WindowAddSupply : Window
    {
        public WindowAddSupply(AddSupplyViewModel aswm)
        {
            DataContext = aswm;
            InitializeComponent();
            Loaded += AddSupply_Loaded;
        }

       

        private void AddSupply_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is AddSupplyViewModel pvm)
            {
                pvm.Save += () =>
                {
                    DialogResult = true;
                    Close();
                };
                pvm.Exit += () =>
                {
                    Application.Current.Shutdown();
                };
            }
        }
    }
}
