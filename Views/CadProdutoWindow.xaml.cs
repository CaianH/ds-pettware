using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PETTWARE
{
    /// <summary>
    /// Lógica interna para CadProdutoWindow.xaml
    /// </summary>
    public partial class CadProdutoWindow : Window
    {
        public CadProdutoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Produto Cadastrado com Sucesso!");
        }

        private void bntSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bntExcluir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
