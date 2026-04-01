using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace WPFComponenteCombo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        private ObservableCollection<string> rams = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();  // Debe ser el primer metodo siempre
            cb_procesador.SelectedIndex = 0;
            cb_procesador.ItemsSource = new List<string>() {
                "Intel Celeron",
                "AMD Athlon",
                "Apple A18"
            };

            cb_ram.ItemsSource = rams;
        }

        private void bt_ram_Click(object sender, RoutedEventArgs e)
        {
            if (txb_ram.Text != null && txb_ram.Text.Length > 0)
            {
                rams.Add(txb_ram.Text);
                txb_ram.Text = "";
                cb_ram.SelectedIndex = rams.Count - 1;
            }
            else
            {
                MessageBox.Show("Debe ingresar la cantidad de RAM");
            }
        }

        private void btn_seleccion_Click(object sender, RoutedEventArgs e)
        {
            string so = "";
            string procesador = "";
            string marca = "";
            string ram = "";
            bool haySeleccion = cb_SO.SelectedIndex >= 0 && cb_procesador.SelectedIndex >= 0 && cb_marca.SelectedIndex >= 0 && cb_ram.SelectedIndex >= 0;

            if (cb_SO.SelectedIndex >= 0)
            {
                ComboBoxItem cb1 = cb_SO.SelectedValue as ComboBoxItem;
                so = cb1.Content as string;
            }

            if (cb_procesador.SelectedIndex >= 0)
            {
                procesador = cb_procesador.SelectedValue as string;
            }

            if (cb_marca.SelectedIndex >= 0)
            {
                ComboBoxItem cb1 = cb_marca.SelectedValue as ComboBoxItem;
                StackPanel stackPanel1 = cb1.Content as StackPanel;
                TextBlock textBlock = stackPanel1.Children[1] as TextBlock;
                marca = textBlock.Text;
            }

            if (cb_ram.SelectedIndex >= 0)
            {
                ram = cb_ram.SelectedValue as string;
            }

            if (haySeleccion == true) {
                string configuracion = string.Format("SO: {0}\nProcesador: {1}\nMarca: {2}\nRAM: {3}", so, procesador, marca, ram);
                MessageBox.Show(configuracion, "Opciones seleccionadas");
            }
            else {
                MessageBox.Show("Faltan opciones por llenar", "Error");
            }
        }
    }
}