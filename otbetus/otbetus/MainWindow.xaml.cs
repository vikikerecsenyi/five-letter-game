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
using System.IO;

namespace otbetus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> szavak = new List<string>();
        static string gondoltszo;
        private void kitalaltszo()
        {
            StreamReader sr = new StreamReader("otbetus.txt");
            while (!sr.EndOfStream)
            {
                szavak.Add(sr.ReadLine());
            }
            Random rnd = new Random();
            int sorszam = rnd.Next(szavak.Count + 1);
            gondoltszo = szavak[sorszam];
        }
        public MainWindow()
        {
            InitializeComponent();
            
            start.Visibility = Visibility.Visible;
            jatekrol.Visibility = Visibility.Visible;
            tippszoveg.Visibility = Visibility.Hidden;
            tipp.Visibility = Visibility.Hidden;
            tippbutton.Visibility = Visibility.Hidden;
            label.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            uj.Visibility = Visibility.Hidden;
            kilepes.Visibility = Visibility.Hidden;
            feladom.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            kitalaltszo();
        }
        private void start_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Hidden;
            jatekrol.Visibility = Visibility.Hidden;
            tippszoveg.Visibility = Visibility.Visible;
            tipp.Visibility = Visibility.Visible;
            tippbutton.Visibility = Visibility.Visible;
            label.Visibility = Visibility.Visible;
            list.Visibility = Visibility.Visible;
            feladom.Visibility = Visibility.Visible;
        }
        private void feladom_Click(object sender, RoutedEventArgs e)
        {
            tippszoveg.Visibility = Visibility.Hidden;
            tipp.Visibility = Visibility.Hidden;
            tippbutton.Visibility = Visibility.Hidden;
            label.Visibility = Visibility.Hidden;
            list.Visibility = Visibility.Hidden;
            feladom.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Visible;
            label4.Content = $"A gondolt szó a(z) {gondoltszo} volt.";
            label3.Visibility = Visibility.Visible;
            uj.Visibility = Visibility.Visible;
            kilepes.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Hidden;
        }
        private void ellenoriz(object sender, TextChangedEventArgs e)
        {
            if (tipp.Text.Length < 5)
            {
                label1.Content = "Túl rövid a szó";
                tippbutton.IsEnabled = false;
            }
            if (tipp.Text.Length > 5)
            {
                label1.Content = "Túl hosszú a szó";
                tippbutton.IsEnabled = false;
            }
            if (tipp.Text.Length == 5)
            {
                label1.Content = "";
                for (int i = 0; i < szavak.Count; i++)
                {
                    if (tipp.Text == szavak[i])
                    {
                        tippbutton.IsEnabled = true;
                        break;
                    }
                }
                if (tippbutton.IsEnabled == false)
                {
                    label1.Content = "Nem értelmes a szó";
                }
            }
        }
        private void tippbutton_Click(object sender, RoutedEventArgs e)
        {
            string tippszo = tipp.Text;
            tipp.Text = "";
            label1.Content = "";
            tipp.Focus();
            int egyezik = 0;
            for (int i = 0; i < 5; i++)
            {
                if (tippszo[i]==gondoltszo[i])
                {
                    egyezik++;
                }
            }
            list.Items.Add(tippszo + "\t" + egyezik);

            if (egyezik==5)
            {
                tippszoveg.Visibility = Visibility.Hidden;
                tipp.Visibility = Visibility.Hidden;
                tippbutton.Visibility = Visibility.Hidden;
                label.Visibility = Visibility.Hidden;
                list.Visibility = Visibility.Hidden;
                label2.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                uj.Visibility = Visibility.Visible;
                kilepes.Visibility = Visibility.Visible;
                feladom.Visibility = Visibility.Hidden;
            }
        }

        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uj_Click(object sender, RoutedEventArgs e)
        {
            kitalaltszo();
            start_Click(sender,e);
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            uj.Visibility = Visibility.Hidden;
            kilepes.Visibility = Visibility.Hidden;
            list.Items.Clear();
            label1.Content = "";
            label4.Visibility = Visibility.Hidden;
        }
    }
}
