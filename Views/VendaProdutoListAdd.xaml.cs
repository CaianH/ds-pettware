using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PETTWARE.Models;

namespace PETTWARE.Views
{
    /// <summary>
    /// Lógica interna para VendaProdutoListAdd.xaml
    /// </summary>
    public partial class VendaProdutoListAdd : Window
    {
        private List<Produtos> _produtosList = new List<Produtos>();

        public List<Produtos> ProdutosSelecionados { get; private set; } = new List<Produtos>();
        public VendaProdutoListAdd()
        {
            InitializeComponent();
            Loaded += VendaProdutoListAdd_Loaded;
        }

        private void VendaProdutoListAdd_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                _produtosList = new ProdutosDAO().List();
                dataGrid.ItemsSource = _produtosList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnAdicionarProdutos_Click(object sender, RoutedEventArgs e)
        {
            var itens = dataGrid.Items;

            ProdutosSelecionados.Clear();

            foreach(Produtos produto in itens)
            {
                if (produto.IsSelected)
                    ProdutosSelecionados.Add(produto);
            }

            if(ProdutosSelecionados.Count == 0)
                MessageBox.Show("Nenhum Produto foi Selecionado", "", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var text = TBBusca.Text;
            

            var filteredList = _produtosList.Where(i => i.Descricao.ToLower().Contains(text));
            dataGrid.ItemsSource = filteredList;
        }
    }
}
