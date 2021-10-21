using PETTWARE.Models;
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
    /// Lógica interna para CadDespesasWindow.xaml
    /// </summary>
    public partial class CadDespesasWindow : Window
    {
        public CadDespesasWindow()
        {
            InitializeComponent();

        }

        private void bntSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Despesas despesas = new Despesas();
                despesas.TipoDespesa = ComboTipoDes.Text;
                despesas.NomeDespesa = txtNome.Text;
                
                DespesasDAO despesasDAO = new DespesasDAO();
                despesasDAO.Insert(despesas);

                MessageBox.Show("Cadastro Salvo com Sucesso!", "Cadastrar Despesas", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }

          
        }

        private void bntExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja excluir essa Despesa?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Despesa Excluída com Sucesso!", "Confirmação", MessageBoxButton.OK, MessageBoxImage.Information);
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