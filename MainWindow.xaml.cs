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

namespace PETTWARE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_CadServico(object sender, RoutedEventArgs e)
        {
            CadastrarServicoWindow CadServico = new CadastrarServicoWindow();
            CadServico.ShowDialog();
        }

        private void Click_Produto(object sender, RoutedEventArgs e)
        {
            CadProdutoWindow Produto = new CadProdutoWindow();
            Produto.ShowDialog();
        }

        private void Click_CadCliente(object sender, RoutedEventArgs e)
        {
            CadClienteWindow1 Cliente = new CadClienteWindow1();
            Cliente.ShowDialog();
        }

        private void Click_CadFuncionario(object sender, RoutedEventArgs e)
        {
            CadFuncionarioWindow1 Funcionario = new CadFuncionarioWindow1();
            Funcionario.ShowDialog();
        }



        private void Click_Vender(object sender, RoutedEventArgs e)
        {
            FazerVendaWindow Vender = new FazerVendaWindow();
            Vender.ShowDialog();
        }


        private void Click_CadFornecedor(object sender, RoutedEventArgs e)
        {
            CadFornecedorWindow Fornecedor = new CadFornecedorWindow();
            Fornecedor.ShowDialog();
        }

        private void Click_CadDespesas(object sender, RoutedEventArgs e)
        {
            CadDespesasWindow Despesas = new CadDespesasWindow();
            Despesas.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TipoDespesa_Click(object sender, RoutedEventArgs e)
        {
            CadTiposDespesasWindow TipoDespesa = new CadTiposDespesasWindow();
            TipoDespesa.ShowDialog();
        }

        private void Caixa_Click(object sender, RoutedEventArgs e)
        {
            ConsulCaixaWindow Caixa = new ConsulCaixaWindow();
            Caixa.ShowDialog();
        }
    }
}
