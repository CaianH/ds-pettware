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
    /// Lógica interna para ConsulFuncionarioWindow.xaml
    /// </summary>
    public partial class ConsulFuncionarioWindow : Window
    {
        public ConsulFuncionarioWindow()
        {
            InitializeComponent();
            Loaded += ConsulFuncionarioWindow_Loaded;
        }

        private void ConsulFuncionarioWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Funcionarios> listaFuncionarios = new List<Funcionarios>();

            for (int i = 0; i < 50; i++)
            {
                listaFuncionarios.Add(new Funcionarios()
                {

                    Nome = "Fulano" + i,
                    Telefone = 69984107407 + 11,
                    Codigo = 456 * i,
                    CPF = 03206474205 + 11,
                    RG = 1234567 + 11,
                    Email = "Fulano" + i + "@gmail.com"                  

                });

            }


        }
    }
}
