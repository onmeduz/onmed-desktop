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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnMed.Desktop.Component
{
    /// <summary>
    /// Interaction logic for AppointmentComponent.xaml
    /// </summary>
    public partial class AppointmentComponent : UserControl
    {
        public AppointmentComponent()
        {
            InitializeComponent();
        }

        private void BorderLine_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderLine.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC0000"));
            
        }

        private void BorderLine_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderLine.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#898989"));
        }
    }
}
