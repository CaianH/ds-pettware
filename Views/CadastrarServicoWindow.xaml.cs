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
        private int _id;
        private Servico _servico;
        public CadastrarServicoWindow()
        {
            InitializeComponent();
            Loaded += CadastrarServicoWindow_Loaded;
        }

        public CadastrarServicoWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += CadastrarServicoWindow_Loaded;
        }

        private void CadastrarServicoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _servico = new Servico();

            if (_id > 0)
                FillForm();
            
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {

            _servico.Nome = TBServico.Text;

            if (double.TryParse(TBPrecoNormal.Text, out double PrecoNormal))
                _servico.PrecoNormal = Convert.ToDouble(TBPrecoNormal.Text);

            if (double.TryParse(TBPrecoComDesconto.Text, out double PrecoComDesconto))
                _servico.PrecoComDesconto = Convert.ToDouble(TBPrecoComDesconto.Text);

            SaveData();

        }

        private bool Validate()
        {
            var validator = new ServicoValidator();
            var result = validator.Validate(_servico);

            if (!result.IsValid)
            {
                string errors = null;
                int count = 1;

                foreach (var failure in result.Errors)
                {
                    errors += $"{count++} - {failure.ErrorMessage}\n";

                }
                MessageBox.Show(errors, "Validação de dados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result.IsValid;
        }
        private void SaveData()
        {
            try
            {

                if (Validate())
                {
                    var dao = new ServicoDAO();
                    var text = "Atualizado";

                    if (_servico.Id == 0)
                    {
                        dao.Insert(_servico);
                        text = "Adicionado";
                    }
                    else
                        dao.Update(_servico);

                    MessageBox.Show($"Serviço {text} com sucesso!!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                    TBServico.IsEnabled = false;
                    TBPrecoNormal.IsEnabled = false;
                    TBPrecoComDesconto.IsEnabled = false;
                    btnSalvar.IsEnabled = false;


                    ClearInputs();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void FillForm()
        {
            try
            {
                var dao = new ServicoDAO();
                _servico = dao.GetById(_id);

                TBcod.Text = _servico.Id.ToString();
                TBServico.Text = _servico.Nome;
                TBPrecoNormal.Text = _servico.PrecoNormal.ToString();
                TBPrecoComDesconto.Text = _servico.PrecoComDesconto.ToString();

                TBServico.IsEnabled = true;
                TBPrecoNormal.IsEnabled = true;
                TBPrecoComDesconto.IsEnabled = true;
                btnSalvar.IsEnabled = true;
                btnCancelar.IsEnabled = true;
                Adiconarbtn.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {

            TBServico.Text = "";
            TBPrecoNormal.Text = "";
            TBPrecoComDesconto.Text = "";
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Deseja Cancelar?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (Result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            TBServico.IsEnabled = IsEnabled;
            TBPrecoNormal.IsEnabled = IsEnabled;
            TBPrecoComDesconto.IsEnabled = IsEnabled;
            btnSalvar.IsEnabled = IsEnabled;
            btnCancelar.IsEnabled = IsEnabled;

        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ServicoListWindow ListaServico = new ServicoListWindow();
            ListaServico.ShowDialog();
        }
    }
}
