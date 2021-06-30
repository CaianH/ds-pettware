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
    /// Lógica interna para CadFornecedorWindow.xaml
    /// </summary>
    public partial class CadFornecedorWindow : Window
    {
        public CadFornecedorWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cadastro Salvo com Sucesso!", "Cadastrar Fornecedores", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja excluir este Fornecedor?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Fornecedor Excluído com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }









    }


}
