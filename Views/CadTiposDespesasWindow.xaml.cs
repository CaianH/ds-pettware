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
    /// Lógica interna para CadTiposDespesasWindow.xaml
    /// </summary>
    public partial class CadTiposDespesasWindow : Window
    {
        public CadTiposDespesasWindow()
        {
            InitializeComponent();
        }

        private void bntSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cadastro Salvo com Sucesso!", "Cadastrar tipos de despesas.", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void bntExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja excluir este tipo de despesa?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Tipo de despesa excluída com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnConsul_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
