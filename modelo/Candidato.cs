using System.Diagnostics;

namespace Candidatos.modelo
{
    public class Candidato
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Sexo { get; private set; }
        public DateTime  DataNascimento { get; private set; }
        public bool bAtivo { get; private set; }
        public int Idade { get { return GetCandidatoIdade(); } }

        public Candidato(int iD, string nome, string cPF, string sexo, DateTime dataNascimento, bool bAtivo)
        {
            ID = iD;
            Nome = nome;
            CPF = cPF;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            this.bAtivo = bAtivo;
        }

        private int GetCandidatoIdade() {
            var idade = DateTime.Now.Year - DataNascimento.Year;
            if(DateTime.Now.DayOfYear < DataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }

        // private string GetDebuggerDisplay()
        // {
        //     return ToString();
        // }
    }
}