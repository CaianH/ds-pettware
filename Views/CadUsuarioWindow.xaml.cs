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
    /// Lógica interna para CadUsuarioWindow.xaml
    /// </summary>
    public partial class CadUsuarioWindow : Window
    {
        public CadUsuarioWindow()
        {
            InitializeComponent();
        }

        private void btnSalvar_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cadastro salvo com sucesso!", "Cadastrar Usuários", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExcluir_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja excluir este usuário?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Usuário excluído com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void btnaddft_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnex_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnadd_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
