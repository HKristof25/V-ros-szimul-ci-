using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Állomváros
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int PenzOsszeg;
        public int haviBevetel;
        public int Elegedettseg;
        public int Lakossag = 100;
        int EpuletMinoseg;
        int HaviKiadas;
        int Honap;

        public MainWindow()
        {
            InitializeComponent();
            PenzOsszeg = 10000000;
            Elegedettseg = 80;
            EpuletMinoseg = 100;
            HaviKiadas = 100000;
            Honap = 1;
            haviBevetel = 0;
            UpdateText();
   
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void OpenWindow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string actionType = button.Tag.ToString();
                Reszlet window = new Reszlet(actionType, this);
                this.Hide();
                window.ShowDialog();
                this.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Honap += 1;
            if (Elegedettseg - 10 < 0)
                MessageBox.Show("Vesztettél");
            else
                Elegedettseg -= 10;
            PenzOsszeg -= HaviKiadas;
            PenzOsszeg += haviBevetel;
            UpdateText();
        }
        public void UpdateText()
        {
            Penz.Text = $"{PenzOsszeg} Ft";
            elegedettseg.Text = $"Elégedettség: {Elegedettseg} %";
            minoseg.Text = $"Épület minőség: {EpuletMinoseg} %";
            honap.Text = $"{Honap}. Hónap";
            kiadástext.Text = $"Havi kiadás: {HaviKiadas} Ft";
        }
        
    }
}