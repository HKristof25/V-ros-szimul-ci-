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
        int Honap;
        public List<int> stack = new List<int>();
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            PenzOsszeg = 10000000;
            Elegedettseg = 80;
            EpuletMinoseg = 100;
            haviBevetel = -100000;
            Honap = 1;
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
            if (stack?.Count != 0)
            {
                for (int i = 0; i < stack.Count(); i += 3)
                {
                    PenzOsszeg -= stack[i];
                    stack[i + 1]--;
                    if (stack[i + 1] == 1)
                    {
                        Elegedettseg += stack[i + 2];
                        stack.RemoveAt(i);
                        stack.RemoveAt(i);
                        stack.RemoveAt(i);
                    }
                }
            }
            
            int esemeny = r.Next(0, 20);
            if (esemeny < 100)
            {
                MessageBox.Show("Semmi nem történt ebben a hónapba.");
            }
            else if (esemeny < 50)
            {
                MessageBox.Show("Kigyuladt egylakóparj!");
                Elegedettseg -= 5;
                PenzOsszeg -= 500000;
            }
            else if (esemeny < 70)
            {
                MessageBox.Show("Hatalmas viharok súlytották a város!");
                Elegedettseg -= 6;
                PenzOsszeg -= 500000;
            }
            else if (esemeny < 90)
            {
                MessageBox.Show("Földrengés súlytotta a város!");
                Elegedettseg -= 8;
                PenzOsszeg -= 500000;
            }
            else
            {
                MessageBox.Show("Az alkhaida terror támadást mért a városra! Bomboclat");
                Elegedettseg -= 12;
                PenzOsszeg -= 1000000;
            }
            Honap += 1;
            if (Elegedettseg - 5 <= 0)
            {
                Elegedettseg = 0;
                MessageBox.Show("Vesztettél");
                NextMonth.IsEnabled = false;
            }

            else
            {
                Elegedettseg -= 5;
                EpuletMinoseg -= 10;
            }
            PenzOsszeg += haviBevetel;
            UpdateText();
        }
        public void UpdateText()
        {
            Penz.Text = $"{PenzOsszeg} Ft";
            elegedettseg.Text = $"Elégedettség: {Elegedettseg} %";
            minoseg.Text = $"Épület minőség: {EpuletMinoseg} %";
            honap.Text = $"{Honap}. Hónap";
            if(haviBevetel > 0)
                kiadástext.Text = $"Havi bevétel: {haviBevetel} Ft";
            else
                kiadástext.Text = $"Havi kiadás: {haviBevetel} Ft";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}