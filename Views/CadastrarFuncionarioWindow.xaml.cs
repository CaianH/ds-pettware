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

namespace PETTWARE.Views
{
    /// <summary>
    /// Lógica interna para CadastrarFuncionarioWindow.xaml
    /// </summary>
    public partial class CadastrarFuncionarioWindow : Window
    {
        public CadastrarFuncionarioWindow()
        {
            InitializeComponent();
            Loaded += CadastrarFuncionarioWindow_Loaded;
        }

        private void CadastrarFuncionarioWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Funcionarios funcionarios = new Funcionarios();
                funcionarios.Nome = txtNome.Text;
                funcionarios.CPF = txtCPF.Text;
                funcionarios.RG = txtRG.Text;
                /*funcionarios.datanasc = (DateTime)dtPickerDataNascimento.SelectedDate;*/
                funcionarios.Email = txtemail.Text;
                funcionarios.Telefone = txtTelefone.Text;
                funcionarios.Naturalidade = txtNaturalidade.Text;
                funcionarios.Nacionalidade = txtNacionalidade.Text;

                FuncionariosDAO funcionariosDAO = new FuncionariosDAO();
                funcionariosDAO.Insert(funcionarios);
                MessageBox.Show("O funcionário foi inserido com sucesso", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                var result = MessageBox.Show("Deseja Continuar Adicionando Funcionários?", "Continuar", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    this.Close();
                else
                    ClearInputs();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "não executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearInputs()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            /*funcionarios.datanasc = (DateTime)dtPickerDataNascimento.SelectedDate;*/
            txtemail.Text = "";
            txtTelefone.Text = "";
            txtNaturalidade.Text = "";
            txtNacionalidade.Text = "";
        }
    }
    
}
