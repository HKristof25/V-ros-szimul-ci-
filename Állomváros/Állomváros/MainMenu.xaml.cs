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

namespace Állomváros
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public int PenzInput;
        public int KezdoEInput;
        public int MinEInput;
        public int EpuletInput;
        public int HonapInput;
        public MainMenu()
        {
            InitializeComponent();
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Int32.Parse(penzInput.Text) > 0 && Int32.Parse(kezdoEInput.Text) > 0 && Int32.Parse(kezdoEInput.Text) <= 100 && Int32.Parse(minEInput.Text) > 0 && Int32.Parse(minEInput.Text) <= 100 && Int32.Parse(honapInput.Text) > 0 && Int32.Parse(epuletInput.Text) > 0 && Int32.Parse(epuletInput.Text) <= 100)
                {
                    PenzInput = Int32.Parse(penzInput.Text);
                    KezdoEInput = Int32.Parse(kezdoEInput.Text);
                    MinEInput = Int32.Parse(minEInput.Text);
                    EpuletInput = Int32.Parse(epuletInput.Text);
                    HonapInput = Int32.Parse(honapInput.Text);

                    MainWindow mainWindow = new MainWindow(PenzInput,KezdoEInput,EpuletInput, MinEInput, HonapInput);
                    mainWindow.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Hibás paraméterek");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Hibás paraméterek");
            }
        }
    }
}
