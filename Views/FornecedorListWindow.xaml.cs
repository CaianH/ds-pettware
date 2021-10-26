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
    /// Lógica interna para FornecedorListWindow.xaml
    /// </summary>
    public partial class FornecedorListWindow : Window
    {
        public FornecedorListWindow()
        {
            InitializeComponent();
            Loaded += FornecedorListWindow_Loaded;
        }

        private void FornecedorListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new FornecedorDAO();

                datagridFornecedor.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void datagridFornecedor_Loaded(object sender, RoutedEventArgs e)
        {

        }

       

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}