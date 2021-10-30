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
using PETTWARE.Views;
using PETTWARE.Models;

namespace PETTWARE
{
    /// <summary>
    /// Lógica interna para FazerVendaWindow.xaml
    /// </summary>
    public partial class FazerVendaWindow : Window
    {



        private Venda _venda;

        private List<VendaItem> _vendaItensList = new List<VendaItem>();
        public FazerVendaWindow()
        {
            InitializeComponent();
            Loaded += datagridVenda_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _venda = new Venda();
            LoadComboBox();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void datagridVenda_Loaded(object sender, RoutedEventArgs e)
        {

            
            

            
        }

        private void Vender_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxFuncionario.SelectedItem != null)
                _venda.Funcionario = ComboBoxFuncionario.SelectedItem as Funcionarios;

            if (ComboBoxCliente.SelectedItem != null)
                _venda.Cliente = ComboBoxCliente.SelectedItem as Cliente;

            if (ComboBoxPagamento.SelectedItem != null)
                _venda.FormaPagamento = ComboBoxPagamento.Text;

            _venda.Valortotal = UpdateValorTotal();

            if (DatePickerVenda.SelectedDate != null)
                _venda.Data = (DateTime)DatePickerVenda.SelectedDate;

            _venda.Itens = _vendaItensList;

            SaveData();
        }

        
        private void SaveData()
        {
            try
            {
                if (Validate())
                {

                    var dao = new VendaDAO();
                        dao.Insert(_venda);
                        
                   
                        MessageBox.Show($"Venda Realizada com sucesso!!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private bool Validate()
        {
            var validator = new VendaValidator();
            var result = validator.Validate(_venda);

            if (!result.IsValid)
            {
                string errors = null;
                int count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";

                }
                MessageBox.Show(errors, "Validação de dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result.IsValid;
        }
        private void ExcluirBt_Click(object sender, RoutedEventArgs e)
        {
            var ItemSelecionado = datagridVenda.SelectedItem as VendaItem;
            _vendaItensList.Remove(ItemSelecionado);
            LoadDataGrid();
        }

        private void LoadComboBox()
        {
            try
            {
                ComboBoxFuncionario.ItemsSource = new FuncionariosDAO().List();
                ComboBoxCliente.ItemsSource = new ClienteDAO().List();
                
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VendaProdutoListAdd Vendaprodlist = new VendaProdutoListAdd();
            Vendaprodlist.ShowDialog();

            var produtosSelecionadosList = Vendaprodlist.ProdutosSelecionados;
            var count = 1;

            foreach(Produtos produto in produtosSelecionadosList)
            {

                if(!_vendaItensList.Exists(item => item.Produto.Codigo == produto.Codigo))
                {
                    _vendaItensList.Add(new VendaItem()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        ValorTotal = produto.PrecoComDesconto,
                        Valor = produto.PrecoComDesconto



                    });
                    count++;
                }
            }
            
            LoadDataGrid();
        }

        private double UpdateValorTotal()
        {
            double valor = 0;

            _vendaItensList.ForEach(item => valor += item.ValorTotal);

            TBvalortotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            datagridVenda.ItemsSource = null;
            datagridVenda.ItemsSource = _vendaItensList;
        }

        private void datagridVenda_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaItem;

            var value = (e.EditingElement as TextBox).Text;

            _ = int.TryParse(value, out int quantidade);

            if(quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;
            }
            LoadDataGrid();
        }
    }
}
