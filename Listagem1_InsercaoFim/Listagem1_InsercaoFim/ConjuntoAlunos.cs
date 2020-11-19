using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listagem1_InsercaoFim
{
    class ConjuntoAlunos
    {
        private AntigoAluno topo;
        private AntigoAluno InsercaoAluno;

        public ConjuntoAlunos() { }


        public void InsercaoFim(string nomeValue, int numValue, DateTime dataNascimento, Curso cursoValue)
        {
            AntigoAluno novoAluno = new AntigoAluno
            {
                Nome = nomeValue,
                NumAluno = numValue,
                CursoInscrito = cursoValue,
                DataNascimento = dataNascimento
            };

            if (topo == null)
            {
                topo = novoAluno;
            }
            else
            {
                InsercaoAluno = topo;
                if (InsercaoAluno.Proximo != null)
                {
                    if (InsercaoAluno.NumAluno == InsercaoAluno.Proximo.NumAluno) throw new Exception("Aluno inválido não pode ter o mesmo número");
                }
                while (InsercaoAluno.Proximo != null)
                {
                    if (InsercaoAluno.NumAluno == novoAluno.NumAluno) throw new Exception("Aluno inválido não pode ter o mesmo número");
                    InsercaoAluno = InsercaoAluno.Proximo;
                }
                InsercaoAluno.Proximo = novoAluno;
            }
        }

        public int QuantosAluno(Curso? cursoValue)
        {
            AntigoAluno aux = topo;
            int contador = 0;
            if (aux != null)
            {
                if (cursoValue != null)
                {
                    while (aux.Proximo != null)
                    {
                        if (aux.CursoInscrito == cursoValue) contador++;
                        aux = aux.Proximo;
                    }
                    if (aux.CursoInscrito == cursoValue) contador++;
                    return contador;
                }
                else
                {
                    while (aux.Proximo != null)
                    {
                        aux = aux.Proximo;
                        contador++;
                    }
                    contador++;
                    return contador;
                }
            }
            return 0;
        }

        public void RemoverAluno(int numAluno)
        {
            if (topo != null && topo.Proximo != null)
            {
                AntigoAluno aux = topo;

                if (topo.NumAluno == numAluno)
                {
                    topo = topo.Proximo;
                }
                else if (topo.Proximo.NumAluno == numAluno)
                {
                    topo.Proximo = topo.Proximo.Proximo;
                }
                InsercaoAluno = topo;
                InsercaoAluno.Proximo = topo.Proximo;
                while (aux.Proximo != null)
                {
                    if (aux.Proximo.NumAluno == numAluno && InsercaoAluno.Proximo.Proximo != null)
                    {
                        InsercaoAluno.Proximo = InsercaoAluno.Proximo.Proximo;

                    }
                    else if (aux.Proximo.NumAluno == numAluno)
                    {
                        InsercaoAluno.Proximo = null;
                        break;
                    }
                    InsercaoAluno = InsercaoAluno.Proximo;
                    aux = aux.Proximo;
                }
            }
            else if (topo != null)
            {
                if (topo.NumAluno == numAluno) topo = null;
            }
        }

        public AntigoAluno[] Consulta(Curso cursoValue)
        {
            AntigoAluno[] alunosCurso = new AntigoAluno[QuantosAluno(cursoValue)];
            int contador = 0;
            AntigoAluno aux = topo;

            if (alunosCurso.Length >= 1 && aux != null)
            {
                while (aux.Proximo != null)
                {
                    if (aux.CursoInscrito == cursoValue)
                    {
                        alunosCurso[contador] = aux;
                        contador++;
                    }
                    aux = aux.Proximo;
                }
                if (aux.CursoInscrito == cursoValue) alunosCurso[contador] = aux;
                return alunosCurso;
            }
            else
            {
                throw new Exception("Não existem alunos");
            }
        }

        public AntigoAluno[] Listagem()
        {
            AntigoAluno[] listagem = new AntigoAluno[QuantosAluno(null)];
            AntigoAluno aux = topo;
            int contador = 0;

            if (listagem.Length > 0)
            {
                while (aux.Proximo != null)
                {
                    listagem[contador] = aux;
                    contador++;
                    aux = aux.Proximo;
                }
                listagem[contador] = aux;
                return listagem;
            }
            else
            {
                throw new Exception("Não existem alunos");
            }
        }

        public override string ToString()
        {
            return "";
        }
    }

}
