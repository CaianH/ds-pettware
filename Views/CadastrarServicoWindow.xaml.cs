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
    /// Lógica interna para CadastrarServicoWindow.xaml
    /// </summary>
    public partial class CadastrarServicoWindow : Window
    {
        public CadastrarServicoWindow()
        {
            InitializeComponent();
            Loaded += CadastrarServicoWindow_Loaded;
        }

        private void CadastrarServicoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
           
           
                try
                {
                    Servico servico = new Servico();
                    servico.Nome = TBServico.Text;
                    servico.PrecoNormal = Convert.ToDouble(TBPrecoNormal.Text);
                    servico.PrecoComDesconto = Convert.ToDouble(TBPrecoComDesconto.Text);

                    ServicoDAO servicoDAO = new ServicoDAO();
                    servicoDAO.Insert(servico);

                    MessageBox.Show("Serviço Cadastrado com sucesso!!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                TBServico.IsEnabled = false;
                TBPrecoNormal.IsEnabled = false;
                TBPrecoComDesconto.IsEnabled = false;
                btnSalvar.IsEnabled = false;
                btnExcluir.IsEnabled = false;

                ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            

            
        }

        private void ClearInputs()
        {

            TBServico.Text = "";
            TBPrecoNormal.Text = "";
            TBPrecoComDesconto.Text = "";
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

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            TBServico.IsEnabled = true;
            TBPrecoNormal.IsEnabled = IsEnabled;
            TBPrecoComDesconto.IsEnabled = IsEnabled;
            btnSalvar.IsEnabled = IsEnabled;
            btnExcluir.IsEnabled = IsEnabled;

        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ServicoListWindow ListaServico = new ServicoListWindow();
            ListaServico.ShowDialog();
        }
    }
}
