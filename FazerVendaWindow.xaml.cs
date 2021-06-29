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
    /// Lógica interna para FazerVendaWindow.xaml
    /// </summary>
    public partial class FazerVendaWindow : Window
    {
        public FazerVendaWindow()
        {
            InitializeComponent();
            Loaded += datagridVenda_Loaded;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datagridVenda_Loaded(object sender, RoutedEventArgs e)
        {
            List<Venda> listaProdutos = new List<Venda>();

            for (int i = 1; i < 10; i++)
            {
                listaProdutos.Add(new Venda()
                {
                    ID = i,
                    Produto = "produto" + i,
                    Quantidade = i,
                    ValorUnitario = "$" + 80*i,
                    ValorcomDesconto = "$" + 75*i,
                }) ;
            }
            datagridVenda.ItemsSource = listaProdutos;
        }
    }
}
