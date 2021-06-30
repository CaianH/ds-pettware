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
            Loaded += datagridDespesas_Loaded;
        }

        private void datagridDespesas_Loaded(object sender, RoutedEventArgs e)
        {
            List<CadDespesasWindow> listaDespesas = new List<CadDespesasWindow>();

            for (int i = 1; i < 10; i++)
            {
                listaDespesas.Add(new CadDespesasWindow()
                {
                    Cód= i,
                    Descrição = "Descrição" + i,
                    Tipo = i ,
                    
                });
            }
            datagridDespesas.ItemsSource = listaDespesas;
        }




    }
}
