using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Teste_MDI_INDUSTRIAL.Model;

namespace App2.Data
{
    public class PacienteDAO
    {
        private SQLiteConnection conexao;

        private ObservableCollection<Paciente> lista;
        public ObservableCollection<Paciente> Lista
        {
            get
            {
                if (lista == null)
                {
                    lista = GetAll();
                }
                return lista;
            }
            
            private set
            {
                lista = value;
            }
        }

        public PacienteDAO(SQLiteConnection con)
        {
            conexao = con;
            conexao.CreateTable<Paciente>();
        }

        public void Salvar(Paciente paciente)
        {
            conexao.Insert(paciente);
        }

        public void Remove(Paciente paciente)
        {
            conexao.Delete<Paciente>(paciente.Id);
        }

        
        private ObservableCollection<Paciente> GetAll()
        {
            return new ObservableCollection<Paciente>(conexao.Table<Paciente>());
        } 
    }
}
