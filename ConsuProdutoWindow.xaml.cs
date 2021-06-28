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
    /// Lógica interna para ConsuProdutoWindow.xaml
    /// </summary>
    public partial class ConsuProdutoWindow : Window
    {
        public ConsuProdutoWindow()
        {
            InitializeComponent();
            Loaded += ConsuProdutoWindow_Loaded;
        }

        private void ConsuProdutoWindow_Loaded(object sender, RoutedEventArgs e)
        {

            List<Produtos> listaProdutos = new List<Produtos>();

            for (int i = 0; i < 50; i++)
            {
                listaProdutos.Add(new Produtos()
                {

                    Nome = "Fulano" + i,
                    Marca = "Marca1" + i,
                    Peso = 30 * i,
                    Preco = 20 * i,
                    PrecoComDesconto = 10 * i,
                    QtdEmEstoque = 3 * i,
                    Codigo = 09876 * i

                });


            }





            dataGridProdutos.ItemsSource = listaProdutos;


        }
    }
}
