using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_MDI_INDUSTRIAL.Model
{
    public class Paciente
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime Data_de_nascimento { get; set; }

        public Paciente()
        {

        }

        public Paciente(string nome, DateTime dataDeNascimento)
        {
            this.Nome = nome;
            this.Data_de_nascimento = dataDeNascimento;
        }

        //Método que retorna a idade do paciente
        public int IdadeDoPaciente()
        {
            DateTime anoAtual = DateTime.Now;
            int idade = anoAtual.Year - this.Data_de_nascimento.Year;
            return idade;
        }
    }
}
