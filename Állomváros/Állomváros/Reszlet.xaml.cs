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
    public partial class Reszlet : Window
    {
        public Reszlet(string actionType)
        {
            InitializeComponent();
            SetContent(actionType);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetContent(string actionType)
        {
            ContentPanel.Children.Clear();

            if(actionType == "torles")
            {
                ContentPanel.Children.Add(new TextBlock { Text = "Típus", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBox { Name = "Típus" });
                ContentPanel.Children.Add(new TextBlock { Text = "Befolyás az elégedettségen", Foreground = Brushes.White });
                
            }

            if (actionType == "epulet")
            {
                ContentPanel.Children.Add(new TextBlock { Foreground = Brushes.White, Text = "Méret"});
                ContentPanel.Children.Add(new TextBox { Name = "meret" });
                ContentPanel.Children.Add(new TextBlock { Text = "Befolyás a lakosságon", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Ár", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Idő", Foreground = Brushes.White });
            }
            if (actionType == "szolgaltatas")
            {
                ContentPanel.Children.Add(new TextBlock { Text = "Típus", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBox { Name = "Típus" });
                ContentPanel.Children.Add(new TextBlock { Text = "Befolyás az elégedettségen", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Ár", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Idő", Foreground = Brushes.White });
            }
            if(actionType =="karbantartas")
            {
                ContentPanel.Children.Add(new TextBlock { Text = "Ár", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Befolyás az elégedettségen", Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBlock { Text = "Idő", Foreground = Brushes.White });
            }
        }
    }
}
