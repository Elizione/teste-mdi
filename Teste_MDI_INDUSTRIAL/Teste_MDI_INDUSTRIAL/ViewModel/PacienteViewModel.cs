using App2.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teste_MDI_INDUSTRIAL.Model;
using Xamarin.Forms;

namespace Teste_MDI_INDUSTRIAL.ViewModel
{
    public class PacienteViewModel : INotifyPropertyChanged
    {

        PacienteDAO dao;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ComAdcionar { get; set; }
        public ICommand ComEditar { get; set; }
        public ICommand ComExcluir { get; set; }


        private string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                PropertChanged();
            }
        }

        private DateTime data_de_nascimento;
        public DateTime Data_De_Nascimento
        {
            get
            {
                return data_de_nascimento;
            }
            set
            {
                data_de_nascimento = value;
                PropertChanged();
            }
        }

        //Bindable Propertys
        private ObservableCollection<Paciente> listadepacientes;
        public ObservableCollection<Paciente> ListaDePacientes
        {
            get
            {
                return listadepacientes;
            }
            set
            {
                listadepacientes = value;
                PropertChanged();
            }
        }


        //Método que atualiza mudanças nas propriedades
        void PropertChanged([CallerMemberName] string nome = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }

        //Ctor
        public PacienteViewModel(PacienteDAO dao)
        {

            this.dao = dao;

            ListaDePacientes = dao.Lista;

            ComAdcionar = new Command(()=> {
                Adciona(nome, data_de_nascimento);
            });

            ComEditar = new Command(Edita);

            ComExcluir = new Command(Deleta);
        }


        private void Adciona(string n, DateTime d)
        {
            try
            {
                Paciente pacienteEscolhido = new Paciente(n, d);
                dao.Salvar(pacienteEscolhido);
                ListaDePacientes.Add(pacienteEscolhido);
            }
            catch (InvalidCastException e)
            {
                var message = e.Message;
                var stack = e.StackTrace;
            }
        }

        private void Deleta(object sender)
        {
            try
            {
                var pacienteEscolhido = ((Paciente)sender);
                dao.Remove(pacienteEscolhido);
                ListaDePacientes.Remove(pacienteEscolhido);
            }
            catch (InvalidCastException e)
            {
                var message = e.Message;
                var stack = e.StackTrace;
            }

        }

        private void Edita(object sender)
        {
            //Todo
        }

    }
}
