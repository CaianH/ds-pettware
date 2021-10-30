
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
    /// Lógica interna para CadFornecedorWindow.xaml
    /// </summary>
    public partial class CadFornecedorWindow : Window
    {
        private int _id;

        private Fornecedor _fornecedor;

        public CadFornecedorWindow()
        {
            InitializeComponent();
            Loaded += CadFornecededorWindow_Loaded;
        }

        public CadFornecedorWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadFornecededorWindow_Loaded;
        }

        private void CadFornecededorWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _fornecedor = new Fornecedor();

            if (_id > 0)
                FillForm();
        }

        private void bntSalvar_Click(object sender, RoutedEventArgs e)
        {

            _fornecedor.CNPJ = txtCNPJ.Text;
            _fornecedor.NomeForn = txtNome.Text;
            _fornecedor.Telefone = txtTelefone.Text;
            _fornecedor.Email = txtEmail.Text;
            _fornecedor.RepresentanteForn = txtRepresentante.Text;

            MessageBox.Show(_fornecedor.CNPJ);

            SaveData();
        }

        private bool Validate()
        {
            var validator = new FornecedorValitador();
            var result = validator.Validate(_fornecedor);

            if (!result.IsValid)
            {
                string errors = null;
                var count = 1;

                foreach(var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";
                }

                MessageBox.Show(errors, "Validação de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result.IsValid;
        }

        private void SaveData()
        {
            try
            {
                if (Validate())
                {
                    var dao = new FornecedorDAO();
                    var text = "atualizado";

                    if (_fornecedor.id == 0)
                    {
                        dao.Insert(_fornecedor);
                        text = "adicionado";
                    }
                    else
                        dao.Update(_fornecedor);

                    MessageBox.Show($"Fornecedor {text} com Sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                    txtCNPJ.IsEnabled = false;
                    txtNome.IsEnabled = false;
                    txtTelefone.IsEnabled = false;
                    txtEmail.IsEnabled = false;
                    txtRepresentante.IsEnabled = false;
                    btnSalvar.IsEnabled = false;
                    btnExcluir.IsEnabled = false;

                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void FillForm()
        {
            try
            {
                var dao = new FornecedorDAO();
                _fornecedor = dao.GetById(_id);

                txtCod.Text = _fornecedor.id.ToString();
                txtCNPJ.Text = _fornecedor.CNPJ;
                txtNome.Text = _fornecedor.NomeForn;
                txtTelefone.Text = _fornecedor.Telefone;
                txtEmail.Text = _fornecedor.Email;

                txtCNPJ.IsEnabled = true;
                txtNome.IsEnabled = true;
                txtTelefone.IsEnabled = true;
                txtEmail.IsEnabled = true;
                txtRepresentante.IsEnabled = true;
                btnSalvar.IsEnabled = true;
                btnExcluir.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void ClearInputs()
        {
            txtCNPJ.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtCNPJ.IsEnabled = true;
            txtNome.IsEnabled = IsEnabled;
            txtTelefone.IsEnabled = IsEnabled;
            txtEmail.IsEnabled = IsEnabled;
            txtRepresentante.IsEnabled = IsEnabled;
            btnSalvar.IsEnabled = IsEnabled;
            btnExcluir.IsEnabled = IsEnabled;


        }

        private void btnConsul_Click(object sender, RoutedEventArgs e)
        {
            FornecedorListWindow ListaFornecedor = new FornecedorListWindow();
            ListaFornecedor.ShowDialog();
        }
    }
}