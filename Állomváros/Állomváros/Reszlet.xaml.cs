using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            if (actionType == "torles")
            {
                ContentPanel.Children.Add(new Label { Content = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Azonosító", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new Label { Content = "Név", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Név",  Foreground = Brushes.White, FontSize = 20});
                ContentPanel.Children.Add(new Label { Content = "Típus", Foreground = Brushes.White, FontSize = 20 });
                TextBox tipus = new TextBox { Name = "tipus", Text = "Típus", FontSize = 20, Foreground = Brushes.White };
                ContentPanel.Children.Add(tipus);
                ContentPanel2.Children.Add(new Label { Content = "Kezdő dátum", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new TextBox { Text = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befejező dátum", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new TextBox { Text = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Költség", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new TextBox { Text = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befolyás az elégedettségen", FontSize = 20, Foreground = Brushes.White });
                if (tipus.Text.ToLower() == "lakóház")
                {
                    ContentPanel2.Children.Add(new Label { Content = "Befolyás a népességen", Foreground = Brushes.White, FontSize = 20});
                }
            }


            if (actionType == "epulet")
            {
                ContentPanel.Children.Add(new Label { Content = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new Label { Content = "Név", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Név", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new Label { Content = "Típus", Foreground = Brushes.White, FontSize = 20 });
                TextBox tipus = new TextBox { Name = "tipus", Text = "Típus", FontSize = 20, Foreground = Brushes.White };
                ContentPanel.Children.Add(tipus);
                ContentPanel.Children.Add(new Label { Content = "Méret", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Méret", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new Label { Content = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox{ Text = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befolyás az elégedettségen", FontSize = 20, Foreground = Brushes.White });
                if (tipus.Text.ToLower() == "lakóház")
                {
                    ContentPanel2.Children.Add(new Label { Content = "Befolyás a népességen", FontSize = 20, Foreground = Brushes.White });
                }

            }

            if (actionType == "szolgaltatas")
            {
                ContentPanel.Children.Add(new Label { Content = "Azonosító", Foreground = Brushes.White, FontSize = 20});
                ContentPanel.Children.Add(new TextBox { Text = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new Label { Content = "Név", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Név", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new Label { Content = "Típus", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBox { Text = "Típus", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new Label { Content = "Havi költésg", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Havi költés", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new Label { Content = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befolyás az elégedettségen", FontSize = 20, Foreground = Brushes.White });
            }

            if(actionType =="karbantartas")
            {
                ContentPanel.Children.Add(new Label { Content = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Azonosító", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new Label { Content = "Név", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Név", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new Label { Content = "Havi költésg", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new TextBox { Text = "Havi költés", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel.Children.Add(new Label { Content = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel.Children.Add(new TextBox { Text = "Költség", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Kezdő dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new TextBox { Text = "Befejező dátum", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Érintett épületek", Foreground = Brushes.White, FontSize = 20 });
                ContentPanel2.Children.Add(new TextBox { Text = "Érintett épületek", FontSize = 20, Foreground = Brushes.White });
                ContentPanel2.Children.Add(new Label { Content = "Befolyás az elégedettségen", FontSize = 20, Foreground = Brushes.White });
                
            }
        }
    }
}
