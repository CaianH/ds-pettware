
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
using PETTWARE.Models;

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


        private void bntSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.CNPJ = txtCNPJ.Text;
                fornecedor.NomeForn = txtNome.Text;
                fornecedor.Telefone = txtTelefone.Text;
                fornecedor.Email = txtEmail.Text;
                fornecedor.RepresentanteForn = txtRepresentante.Text;

                FornecedorDAO fornecerdorDAO = new FornecedorDAO();
                fornecerdorDAO.Insert(fornecedor);

                MessageBox.Show("Cadastro Salvo com Sucesso!", "Cadastrar Fornecedores", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearInputs();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }   

        private void ClearInputs()
        {
           txtCNPJ.Text = "" ;
           txtNome.Text = "" ;
           txtTelefone.Text = "" ;
           txtEmail.Text = "" ;
           txtRepresentante.Text = "";
        }

        private void bntExcluir_Click(object sender, RoutedEventArgs e)
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
