using App2.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Teste_MDI_INDUSTRIAL
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            SQLiteConnection conexao = DependencyService.Get<ISQlite>().GetConnection();

            PacienteDAO dao = new PacienteDAO(conexao);

            var vm = new ViewModel.PacienteViewModel(dao);
            this.BindingContext = vm;

            InitializeComponent();
        }
    }
}
