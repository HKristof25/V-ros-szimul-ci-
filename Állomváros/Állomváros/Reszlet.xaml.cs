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
        List<string> list;
        private ListBox listbox1;
        private ListBox listbox2;
        private Label leiras1, leiras2;
        private MainWindow mainWindow;
        private CheckBox cbEpületTorles, cbEpület, cbLakóépület, cbEgészségügy, cbOktatás, cbGazdaság, cbPénzügy, cbSzórakoztatás, cbKereskedelem, cbEpületKarb;
        private TextBox sizeEp, sizeTo;

        public Reszlet(string actionType, MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw; 
            list = ["Egészségügy", "Oktatás", "Gazdaság", "Pénzügy", "Szórakoztatás", "Kereskedelem"];
            SetContent(actionType);
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int penz = mainWindow.PenzOsszeg; 
            int elegedettseg = mainWindow.Elegedettseg;
            int lakossag = mainWindow.Lakossag;
            int haviBevetel = mainWindow.haviBevetel;
            List<int> stack =  mainWindow.stack;
            if (cbEpületTorles?.IsChecked == true)
            {
                penz += 100000;
                elegedettseg -= 20;
                lakossag -= Convert.ToInt32(Math.Round(Convert.ToDouble(sizeTo.Text) / 30.0, 0));
                
                
            }
            if (cbEpület?.IsChecked == true)
            {
                stack.Add(1000000);
                stack.Add(10);
                stack.Add(15);
                haviBevetel += 200000;
            }
            if (cbLakóépület?.IsChecked == true)
            {
                haviBevetel += 100000;
                stack.Add(1300000);
                stack.Add(6);
                stack.Add(20);
                lakossag += Convert.ToInt32(Math.Round(Convert.ToDouble(sizeTo.Text) / 30.0, 0));
            }
            if (cbEgészségügy?.IsChecked == true)
            {
                haviBevetel += 100000;
                stack.Add(800000);
                stack.Add(10);
                stack.Add(25);
            }
            if (cbOktatás?.IsChecked == true)
            {
                stack.Add(100000);
                stack.Add(15);
                stack.Add(20);
            }
            if (cbGazdaság?.IsChecked == true)
            {
                haviBevetel += 500000;
                stack.Add(1000000);
                stack.Add(5);
                stack.Add(22);
            }
            if (cbPénzügy?.IsChecked == true)
            {
                haviBevetel += 300000;
                stack.Add(750000);
                stack.Add(4);
                stack.Add(15);
            }
            if (cbSzórakoztatás?.IsChecked == true)
            {
                haviBevetel += 600000;

                stack.Add(1000000);
                stack.Add(6);
                stack.Add(25);
            }
            if (cbKereskedelem?.IsChecked == true)
            {
  
                haviBevetel += 300000;

                stack.Add(375000);
                stack.Add(8);
                stack.Add(16);
            }
            if (cbEpületKarb?.IsChecked == true)
            {
                penz -= 80000; 
                elegedettseg += 2;
            }
            if (listbox1?.SelectedItem != null)
            {
                switch (listbox1.SelectedItem.ToString())
                {
                    case "Egészségügy": 
                        penz += 700000;
                        elegedettseg -= 25;
                        haviBevetel -= 100000;
                        break;
                    case "Oktatás": 
                        penz += 400000; 
                        elegedettseg -= 20;
                        break;
                    case "Gazdaság": 
                        penz += 600000; 
                        elegedettseg -= 22;
                        haviBevetel -= 500000;
                        break;
                    case "Pénzügy": 
                        penz += 300000; 
                        elegedettseg -= 15;
                        haviBevetel -= 300000;
                        break;
                    case "Szórakoztatás": 
                        penz += 500000; 
                        elegedettseg -= 25;
                        haviBevetel -= 600000;
                        break;
                    case "Kereskedelem": 
                        penz += 300000;
                        elegedettseg -= 16;
                        haviBevetel -= 300000;
                        break;
                }
            }

            if (listbox2?.SelectedItem != null)
            {
                switch (listbox2.SelectedItem.ToString())
                {
                    case "Egészségügy":
                        penz -= 200000;
                        elegedettseg += 6;
                        break;
                    case "Oktatás":
                        penz -= 100000;
                        elegedettseg += 3;
                        break;
                    case "Gazdaság":
                        penz -= 150000;
                        elegedettseg += 4;
                        break;
                    case "Pénzügy":
                        penz -= 130000;
                        elegedettseg += 3;
                        break;
                    case "Szórakoztatás":
                        penz -= 170000;
                        elegedettseg += 5;
                        break;
                    case "Kereskedelem":
                        penz -= 110000;
                        elegedettseg += 3;
                        break;
                }
            }

            if (penz < 0)
            {
                MessageBox.Show("Nincs elég pénzed!");
                return;
            }

            if (elegedettseg < 1)
            {
                MessageBox.Show("A város nagyon elégedetlen lesz a változtatások után!");
                return;
            }

            if (lakossag < 1)
            {
                MessageBox.Show("Elfogynak az emberek");
                return;
            }

            if (elegedettseg > 100)
            {
                elegedettseg = 100;
            }

            if (haviBevetel < 0)
            {
                haviBevetel = 0;
            }

            mainWindow.PenzOsszeg = penz;
            mainWindow.Elegedettseg = elegedettseg;
            mainWindow.haviBevetel = haviBevetel;
            mainWindow.stack = stack;
            mainWindow.UpdateText();
            this.Close();
        }

        private void SetContent(string actionType)
        {
            ContentPanel.Children.Clear();
            ContentPanel2.Children.Clear();

            if (actionType == "torles")
            {
                listbox1 = new ListBox { ItemsSource = list, Foreground = Brushes.Black, FontSize = 15, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(listbox1);
                leiras1 = new Label { FontSize = 15, Foreground = Brushes.White };
                listbox1.SelectionChanged += (o, e) =>
                {
                    if (listbox1?.SelectedItem != null)
                    {
                        switch (listbox1.SelectedItem.ToString())
                        {
                            case "Egészségügy":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: -100 000FT\nBefolyás az elégedettségen: -25%\nKöltségvetés: +700 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                            case "Oktatás":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: -0FT\nBefolyás az elégedettségen: -20%\nKöltségvetés: +400 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                            case "Gazdaság":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: -500 000FT\nBefolyás az elégedettségen: -22%\nKöltségvetés: +600 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                            case "Pénzügy":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: -300 000FT\nBefolyás az elégedettségen: -15%\nKöltségvetés: +300 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                            case "Szórakoztatás":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: 600 000FT\nBefolyás az elégedettségen: -25%\nKöltségvetés: +500 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                            case "Kereskedelem":
                                ContentPanel2.Children.Clear();
                                leiras1.Content = "Havi bevétel: -300 000FT\nBefolyás az elégedettségen: -16%\nKöltségvetés: +300 000FT";
                                ContentPanel2.Children.Add(leiras1);
                                break;
                        }
                    }
                };

                Button torles = new Button { Content = "Kijelölés törlése", Style = (Style)FindResource("RoundedButtonStyle"), FontSize = 15 };
                torles.Click += torles1_click;
                ContentPanel.Children.Add(torles);

                cbEpületTorles = new CheckBox { Content = "Épület", Margin = new Thickness(0,10,0,0), FontSize = 15, Foreground = Brushes.White, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(cbEpületTorles);

                sizeTo = new TextBox { Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, FontSize = 15, Width = 250 };
                ContentPanel.Children.Add(sizeTo);
                Label meret = new Label { Foreground = Brushes.White, FontSize = 15 };
                meret.Content = "Havi bevétel: -100 000FT\nBefolyás az elégedettségen: -20%\nBefolyás a lakosségra: -0 fő\nKöltségvetés: +100 000FT";
                ContentPanel.Children.Add(meret);
                sizeTo.TextChanged += (s, e) =>
                {
                    if (double.TryParse(sizeTo.Text, out double result))
                    {
                        if (result > 0 && result < 1000000)
                        {
                            int lak = Convert.ToInt32(Math.Round(result / 30.0, 0));
                            meret.Content = $"\"Havi bevétel: -100 000FT\nBefolyás az elégedettségen: -20%\nBefolyás a lakosségra: -{lak} fő";
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
                cbEpület = new CheckBox { Content = "Épület", FontSize = 15, Foreground = Brushes.White, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(cbEpület);
                ContentPanel.Children.Add(new Label { Content = "Költség: 10 000 000FT\nÉpítkezési idő: 10 hónap\nBefolyás az elégedettségen: + 15%\nHavi bevétel: 200 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbLakóépület = new CheckBox { Content = "Lakóépület", FontSize = 15, Foreground = Brushes.White, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel2.Children.Add(cbLakóépület);
                ContentPanel2.Children.Add(new Label { Content = "Méret", FontSize = 15, Foreground = Brushes.White });
                sizeEp = new TextBox { HorizontalAlignment = HorizontalAlignment.Center, Foreground = Brushes.Black, FontSize = 15, Width = 250 };
                ContentPanel2.Children.Add(sizeEp);
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 8 000 000FT\nÉpítkezési idő: 6 hónap\nBefolyás az elégedettségen: + 20%\nHavi bevétel: 100 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
                Label meret = new Label { FontSize = 15, Foreground = Brushes.White, Content = "Lakosságra való befolyás: + 0 fő" };
                ContentPanel2.Children.Add(meret);

                sizeEp.TextChanged += (s, e) =>
                {
                    if (double.TryParse(sizeEp.Text, out double result))
                    {
                        if (result > 0 && result < 1000000)
                        {
                            int lak = Convert.ToInt32(Math.Round(result / 30.0, 0));
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
                cbEgészségügy = new CheckBox { Content = "Egészségügy", FontSize = 15, Foreground = Brushes.White, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(cbEgészségügy);
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 8 000 000FT\nÉpítkezési idő: 10 hónap\nBefolyás az elégedettségen: + 25%\nHavi bevétel: 100 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbOktatás = new CheckBox { Content = "Oktatás", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), FontSize = 15, Foreground = Brushes.White };
                ContentPanel.Children.Add(cbOktatás);
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 1 500 000FT\nÉpítkezési idő: 15 hónap\nBefolyás az elégedettségen: + 20%\nHavi bevétel: 0FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbGazdaság = new CheckBox { Content = "Gazdaság", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), FontSize = 15, Foreground = Brushes.White };
                ContentPanel.Children.Add(cbGazdaság);
                ContentPanel.Children.Add(new TextBlock { Text = "Költség: 5 000 000FT\nÉpítkezési idő: 5 hónap\nBefolyás az elégedettségen: + 22%\nHavi bevétel: 500 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbPénzügy = new CheckBox { Content = "Pénzügy", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), FontSize = 15, Foreground = Brushes.White };
                ContentPanel2.Children.Add(cbPénzügy);
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 3 000 000FT\nÉpítkezési idő: 4 hónap\nBefolyás az elégedettségen: + 15%%\nHavi bevétel: 300 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbSzórakoztatás = new CheckBox { Content = "Szórakoztatás", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), FontSize = 15, Foreground = Brushes.White };
                ContentPanel2.Children.Add(cbSzórakoztatás);
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 6 000 000FT\nÉpítkezési idő: 6 hónap\nBefolyás az elégedettségen: + 25%\nHavi bevétel: 600 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });

                cbKereskedelem = new CheckBox { Content = "Kereskedelem", Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")), FontSize = 15, Foreground = Brushes.White };
                ContentPanel2.Children.Add(cbKereskedelem);
                ContentPanel2.Children.Add(new TextBlock { Text = "Költség: 3 000 000FT\nÉpítkezési idő: 8 hónap\nBefolyás az elégedettségen: + 16%\nHavi bevétel: 300 000FT", Foreground = Brushes.White, FontSize = 15, HorizontalAlignment = HorizontalAlignment.Center });
            }

            if (actionType == "karbantartas")
            {
                listbox2 = new ListBox { ItemsSource = list, Foreground = Brushes.Black, FontSize = 15, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(listbox2);
                leiras2 = new Label { FontSize = 15, Foreground = Brushes.White };
                listbox2.SelectionChanged += (o, e) =>
                {
                    if (listbox2?.SelectedItem != null)
                    {
                        switch (listbox2.SelectedItem.ToString())
                        {
                            case "Egészségügy":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +6%\nKöltség: -200 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                            case "Oktatás":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +3%\nKöltség: -100 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                            case "Gazdaság":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +4%\nKöltség: -150 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                            case "Pénzügy":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +3%\nKöltség: -130 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                            case "Szórakoztatás":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +5%\nKöltség: -170 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                            case "Kereskedelem":
                                ContentPanel2.Children.Clear();
                                leiras2.Content = "Befolyás az elégedettségen: +3%\nKöltség: -110 000FT";
                                ContentPanel2.Children.Add(leiras2);
                                break;
                        }
                    }
                };
                Button torles = new Button { Content = "Kijelölés törlése", Style = (Style)FindResource("RoundedButtonStyle"), FontSize = 15 };
                torles.Click += torles2_click;
                ContentPanel.Children.Add(torles);
                cbEpületKarb = new CheckBox { Content = "Épület", Margin = new Thickness(0,10,0,0), FontSize = 15, Foreground = Brushes.White, Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FE6584")) };
                ContentPanel.Children.Add(cbEpületKarb);

                Label meret = new Label { Foreground = Brushes.White, FontSize = 15 };
                meret.Content = "Befolyás az elégedettségen: +2%\nKöltség: 80 000FT";
                ContentPanel.Children.Add(meret);
            }
        }

        private void torles1_click(object sender, RoutedEventArgs e)
        {
            listbox1.SelectedIndex = -1;
            leiras1.Content = "";
        }
        private void torles2_click(object sender, RoutedEventArgs e)
        {
            listbox2.SelectedIndex = -1;
            leiras2.Content = "";
        }
        
        
    }
}