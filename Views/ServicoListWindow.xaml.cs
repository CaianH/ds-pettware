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
    /// Lógica interna para ServicoListWindow.xaml
    /// </summary>
    public partial class ServicoListWindow : Window
    {
        public ServicoListWindow()
        {
            InitializeComponent();
            Loaded += ServicoListWindow_Loaded;
        }

        private void ServicoListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new ServicoDAO();

                datagridServico.ItemsSource = dao.List();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void datagridServico_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = datagridServico.SelectedItem as Servico;

            var window = new CadastrarServicoWindow(servicoSelected.Id);
            window.ShowDialog();
            LoadList();
           
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            var servicoSelected = datagridServico.SelectedItem as Servico;

            var result = MessageBox.Show($"Deseja realmente remover o Serviço {servicoSelected.Nome} ?","Confirmação de Esxclusão"
                , MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ServicoDAO();
                    dao.Delete(servicoSelected);
                    LoadList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
