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
    /// Lógica interna para CadastrarServicoWindow.xaml
    /// </summary>
    public partial class CadastrarServicoWindow : Window
    {
        public CadastrarServicoWindow()
        {
            InitializeComponent();
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Serviço Salvo com Sucesso!!", "Cadastrar Serviço",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja Excluir Serviço?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Serviço Excluido com Sucesso!!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }
    }
}
