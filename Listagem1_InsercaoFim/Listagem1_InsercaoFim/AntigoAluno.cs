using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listagem1_InsercaoFim
{
    enum Curso
    {
        TPSI = 0,
        RSI = 1,
        PMJD = 2
    }
    class AntigoAluno
    {
        private int numAluno;
        private string nome;
        private DateTime dataNascimento;
        private Curso cursoInscrito;

        private AntigoAluno proximo;

        public int NumAluno
        {
            get { return numAluno; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Inválido, o aluno não pode ter um número negatico");
                }
                else
                {
                    numAluno = value;
                }
            }
        }
        public string Nome
        {
            get { return nome; }
            set
            {
                string nomeValue = "";
                if (value.Trim() != "")
                {
                    for (int posicao = 0; posicao < value.Trim().Length; posicao++)
                    {
                        if (char.IsNumber(value.Trim()[posicao]))
                        {
                            throw new Exception("Invalido o nome não contem numeros");
                        }

                        if (posicao == 0 || value.Trim()[posicao - 1] == ' ')
                        {
                            nomeValue += value.Trim()[posicao].ToString().ToUpper();
                        }

                        else
                        {
                            nomeValue += value.Trim()[posicao].ToString().ToLower();
                        }
                    }
                    nome = nomeValue;
                }

                else
                {
                    throw new Exception("O nome do Aluno nao pode estar em branco");
                }
            }
        }
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set
            {
                if (value > DateTime.Now || (DateTime.Now - value).Days / 365 < 17)
                {
                    throw new Exception("Aluno inválido não pode ter menos de 18 anos");
                }
                else
                {
                    dataNascimento = value;
                }
            }
        }
        public Curso CursoInscrito { get => cursoInscrito; set => cursoInscrito = value; }


        public AntigoAluno Proximo { get => proximo; set => proximo = value; }

        public AntigoAluno()
        {

        }

        public override string ToString()
        {
            return "" + NumAluno + "    " + CursoInscrito + "    " + Nome;
        }
    }
}
