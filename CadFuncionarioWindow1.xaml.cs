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
    /// Lógica interna para CadFuncionarioWindow1.xaml
    /// </summary>
    public partial class CadFuncionarioWindow1 : Window
    {
        public CadFuncionarioWindow1()
        {
            InitializeComponent();
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funcionário Cadastrado com Sucesso");
        }
    }
}
