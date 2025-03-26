using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
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
        List<string> list;
        public Reszlet(string actionType)
        {
            InitializeComponent();
            list = ["Egészségügy", "Oktatás", "Gazdaság", "Pénzügy", "Szórakoztatás", "Kereskedelem"];
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
                ListBox items = new ListBox { ItemsSource = list, Foreground = Brushes.Black, FontSize = 15, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(items);
                Label leiras = new Label { FontSize = 15, Foreground = Brushes.White };
                items.SelectionChanged += (o, e) =>
                {
                    if(items.SelectedItem.ToString() != null)
                    {
                        switch (items.SelectedItem.ToString())
                        {
                            case "Egészségügy":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi bevétel: -100 000FT\nBefolyás az elégedettségen: -25%\nKöltségvetés: +700 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;
                            case "Oktatás":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi bevétel: -0FT\nBefolyás az elégedettségen: -20%\nKöltségvetés: +400 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;
                            case "Gazdaság":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi bevétel: -500 000FT\nBefolyás az elégedettségen: -22%\nKöltségvetés: +600 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;
                            case "Pénzügy":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi bevétel: -300 000FT\nBefolyás az elégedettségen: -15%\nKöltségvetés: +300 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;
                            case "Szórakoztatás":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi bevétel: 600 000FT\nBefolyás az elégedettségen: -25%\nKöltségvetés: +500 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;
                            case "Kereskedelem":
                                ContentPanel2.Children.Clear();
                                leiras.Content = "Havi költség: -300 000FT\nBefolyás az elégedettségen: -16%\nKöltségvetés: +300 000FT";
                                ContentPanel2.Children.Add(leiras);
                                break;

                        }
                    }
                };

                ContentPanel.Children.Add(new Button { Content = "Épület", Margin = new Thickness(0, 10, 0, 0), Style = (Style) FindResource("RoundedButtonStyle")});
                TextBox size = new TextBox { Margin = new Thickness(0, 10, 0, 0) , HorizontalAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, FontSize = 15, Width = 250 };
                ContentPanel.Children.Add(size);
                Label meret = new Label{ Foreground = Brushes.White, FontSize = 15 };
                meret.Content = "Havi költésgvetés: -100 000FT\nBefolyás az elégedettségen: -20%\nBefolyás a lakosségra: -0 fő";
                ContentPanel.Children.Add(meret);
                size.TextChanged += (s, e) =>
                {
                    if (double.TryParse(size.Text, out double sizeValue))
                    {
                        if (sizeValue > 0)
                        {
                            int lak = Convert.ToInt32(Math.Round(sizeValue / 30.0, 0));
                            meret.Content = $"\"Havi költésgvetés: -100 000FT\nBefolyás az elégedettségen: -20%\nBefolyás a lakosségra: -{lak} fő";
                        }
                        else
                        {
                            meret.Content = "Helytelen adat!";
                        }
                    }
                    else
                    {
                        meret.Content = "Helytelen adat!";
                    }
                };

            }


            if (actionType == "epulet")
            {
                ContentPanel.Children.Add(new Button { Content = "Épület", Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 10 000 000FT\nÉpítkezési idő: 10 hónap\nBefolyás az elégedettségen: + 15%\nHavi bevétel: 200 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel2.Children.Add(new Button { Content = "Lakóápület", Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel2.Children.Add(new Label { Content = "Méret", FontSize = 15, Foreground = Brushes.White });
                TextBox size = new TextBox { HorizontalAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, FontSize = 15, Width = 250 };
                ContentPanel2.Children.Add(size);
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 8 000 000FT\nÉpítkezési idő: 6 hónap\nBefolyás az elégedettségen: + 20%\nHavi bevétel: 100 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                Label meret = new Label { FontSize = 15, Foreground = Brushes.White, Content =  "Lakosságra való befolyás: + 0 fő"};
                ContentPanel2.Children.Add(meret);

                size.TextChanged += (s, e) =>
                {
                    if (double.TryParse(size.Text, out double sizeValue))
                    {
                        if (sizeValue > 0)
                        {
                            int lak = Convert.ToInt32(Math.Round(sizeValue / 30.0, 0));
                            meret.Content = $"Lakosságra való befolyás: + {lak} fő";
                        }
                        else
                        {
                            meret.Content = "Helytelen adat!";
                        }
                    }
                    else
                    {
                        meret.Content = "Helytelen adat!";
                    }
                };


            }

            if (actionType == "szolgaltatas")
            {
                ContentPanel.Children.Add(new Button { Content = "Egészségügy", Style= (Style)FindResource("RoundedButtonStyle")});
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 8 000 000FT\nÉpítkezési idő: 10 hónap\nBefolyás az elégedettségen: + 25%\nHavi bevétel: 100 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel.Children.Add(new Button { Content = "Oktatás", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 1 500 000FT\nÉpítkezési idő: 15 hónap\nBefolyás az elégedettségen: + 20%\nHavi bevétel: 0FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel.Children.Add(new Button { Content = "Gazdaság", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 5 000 000FT\nÉpítkezési idő: 5 hónap\nBefolyás az elégedettségen: + 22%\nHavi bevétel: 500 000FT", Foreground = Brushes.White, FontSize = 15 , HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel2.Children.Add(new Button { Content = "Pénzügy", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 3 000 000FT\nÉpítkezési idő: 4 hónap\nBefolyás az elégedettségen: + 15%%\nHavi bevétel: 300 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel2.Children.Add(new Button { Content = "Szórakoztatás", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 6 000 000FT\nÉpítkezési idő: 6 hónap\nBefolyás az elégedettségen: + 25%\nHavi bevétel: 600 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                ContentPanel2.Children.Add(new Button { Content = "Kereskedelem", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), Style = (Style)FindResource("RoundedButtonStyle") });
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 3 000 000FT\nÉpítkezési idő: 8 hónap\nBefolyás az elégedettségen: + 16%\nHavi bevétel: 300 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });


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
