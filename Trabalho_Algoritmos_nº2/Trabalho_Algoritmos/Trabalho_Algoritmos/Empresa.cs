using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Algoritmos
{
    class Empresa
    {
        private Funcionario[] conjuntoDeFuncionarios = new Funcionario[100];
        private Funcionario adicionarFuncionario;
        private int apagarFunc;
        private int aumentarVagas;

        // calcular o valor maximo de conjunto de funcionarios Ex:.(quantos funcionarios exceto os null)
        private int QuantosFuncionariosP()
        {
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                if(conjuntoDeFuncionarios[i] == null)
                {
                    max = i;
                    break;
                }
            }
            return max;
        }
        public Funcionario[] Copia()
        {
            Funcionario[] copia = new Funcionario[QuantosFuncionariosP()];
            for(int i = 0; i<QuantosFuncionariosP(); i++)
            {
                copia[i] = conjuntoDeFuncionarios[i];
            }
            return copia;
        }
        public Funcionario[] SelectionSort()
        {
            Funcionario[] conjFuncCopia = Copia();
            if (conjFuncCopia[2] != null)
            {
                for (int i = 0; i < QuantosFuncionariosP(); i++)
                {
                    int min = i;
                    for (int j = i+1; j < QuantosFuncionariosP(); j++)
                    {
                        if (MetodosAuxiliares.Less(conjFuncCopia[j].Nome, conjFuncCopia[min].Nome))
                        {
                            min = j;
                        }
                    }
                    MetodosAuxiliares.Swap(ref conjFuncCopia[min],ref conjFuncCopia[i]);
                }
            }
            return conjFuncCopia;
        }

       public Funcionario[] InsertionSort()
        {
            Funcionario[] conjFuncCopia = Copia();
            if (conjFuncCopia[2] != null)
            {
                for (int i = 1; i < QuantosFuncionariosP(); i++)
                {
                    for(int j = i; j > 0; j--)
                    {
                        MetodosAuxiliares.ComplexSwap(ref conjFuncCopia[j-1], ref conjFuncCopia[j]);                  
                    }
                }
            }
            return conjFuncCopia;
        }

        public Funcionario AdiocionarFunc
        {
            get { return adicionarFuncionario; }
            set
            {
                bool continuar = false;
                int posicaoFunc = 0;
                do
                {
                    if(conjuntoDeFuncionarios[posicaoFunc] == null)
                    {
                        conjuntoDeFuncionarios[posicaoFunc] = value;
                        for(int posicao = 0; posicao < posicaoFunc; posicao++)
                        {
                            if(conjuntoDeFuncionarios[posicao].NumFuncionario == conjuntoDeFuncionarios[posicaoFunc].NumFuncionario)
                            {
                                conjuntoDeFuncionarios[posicaoFunc] = null;
                                throw new Exception("Inválido não pode haver números de funcionarios repetidos");
                            }
                        }
                        continuar = true;
                    }
                    posicaoFunc++;
                } while (continuar == false);
            }
        }
        public int ApagarFunc
        {
            get { return apagarFunc; }
            set 
            {
                if (conjuntoDeFuncionarios[value-1] != null)
                {
                    int posicaoFunc = 0, posicaoSubFunc = 0;
                    Funcionario[] conjFuncSubs = new Funcionario[conjuntoDeFuncionarios.Length];
                    conjuntoDeFuncionarios[value-1] = null;
                    do
                    {
                        if (conjuntoDeFuncionarios[posicaoFunc] != null)
                        {
                            conjFuncSubs[posicaoSubFunc] = conjuntoDeFuncionarios[posicaoFunc];
                            posicaoSubFunc++;
                        }
                        posicaoFunc++;
                    } while (posicaoFunc < conjuntoDeFuncionarios.Length);
                    conjuntoDeFuncionarios = conjFuncSubs;
                }
                else
                {
                    throw new Exception("Dados inválidos, impossivel apagar esse funcionario porque esse id não existe");
                }
            }
        }
        public int AumentarVagas
        {
            get { return aumentarVagas; }
            set
            {
                if(value > 0 && value <= 100 && conjuntoDeFuncionarios.Length <= 200 && (conjuntoDeFuncionarios.Length+value) <= 200)
                {
                    Funcionario[] conjFuncSub;
                    conjFuncSub = conjuntoDeFuncionarios;
                    conjuntoDeFuncionarios = new Funcionario[value+conjuntoDeFuncionarios.Length];
                    for(int posicao = 0; posicao < conjFuncSub.Length; posicao++)
                    {
                        if (conjFuncSub[posicao] != null)
                        {
                            conjuntoDeFuncionarios[posicao] = conjFuncSub[posicao];
                            aumentarVagas = value;
                        }
                    }
                }
                else
                {
                    throw new Exception("Valores inválidos o valor maximo de vagas são de 200");
                }
            }
        }
    
        //mostrar o tamanho do conjunto de funcionarios
        public int TamanhoDoConjuntoDeFuncionarios()
        {
            return conjuntoDeFuncionarios.Length;
        }
        //mostrar os núemros de funcionarios já usados
        public string NumerosDeFunc()
        {
            string numFunc = "";
            for(int posicao = 0; posicao < conjuntoDeFuncionarios.Length; posicao++)
            {
                if(conjuntoDeFuncionarios[posicao] != null)
                {
                    numFunc += conjuntoDeFuncionarios[posicao].NumFuncionario + " ";
                }
            }
            if(numFunc.Trim() == "")
            {
                return "Não existe números de Funcionarios";
            }
            else
            {
                return numFunc;
            }
        }
        //mudar o número de Funcionario
        public int MudarNumeroFunc(int novoNumero, int idFuncionario)
        {
            if(novoNumero > 0)
            {
                for(int posicao = 0; posicao < conjuntoDeFuncionarios.Length; posicao++)
                {
                    if(conjuntoDeFuncionarios[posicao] != null && conjuntoDeFuncionarios[posicao].NumFuncionario == novoNumero)
                    {
                        throw new Exception("Inválido número de Funcionario já usado");
                    }
                }
                return conjuntoDeFuncionarios[idFuncionario-1].NumFuncionario = novoNumero;
            }
            else
            {
                throw new Exception("O número de funcionario tem de ser positivo");
            }
        }
        public double MudarSalarioBaseFunc(double novoSalario, int idFuncionario)
        {
            if(novoSalario > 0)
            {
                return conjuntoDeFuncionarios[idFuncionario - 1].SalarioBase = Math.Round(novoSalario,2);
            }
            else
            {
                throw new Exception("O salario base do Funcionario tem de ser positivo");
            }
        }
        //mudar a situação matrimonial do Funcioanrio
        public string MudarEstadoFunc(string novaSitucaoMatrimonial,int idFuncionario)
        {
            return conjuntoDeFuncionarios[idFuncionario-1].SituacaoMatrimonial = novaSitucaoMatrimonial; 
        }
        public bool VerificarIdFunc(int idFuncionario)
        {
            if(idFuncionario > 0)
            {
                if(conjuntoDeFuncionarios[idFuncionario-1] != null)
                {
                    return true;
                }
                else
                {
                    Console.Clear();
                    throw new Exception("Esse ID do Funcionario não existe");
                }
            }
            else
            {
                throw new Exception("Inválido o ID tem de ser positivo");
            }
        }
        // verificar se pode calcular o salario liquido
        public double SalarioLiquido(int idFuncionario)
        {
            if(idFuncionario > 0 && idFuncionario < conjuntoDeFuncionarios.Length)
            {
                if(conjuntoDeFuncionarios[idFuncionario-1].SituacaoMatrimonial == "Casado" && conjuntoDeFuncionarios[idFuncionario-1].NumeroTitulares == 2)
                {
                    return conjuntoDeFuncionarios[idFuncionario - 1].CalculoSalarioLiquido();
                }
                else
                {
                    throw new Exception("Dados invalidos, o funconario tem de ser casado e ter dois titulares");
                }
            }
            else
            {
                throw new Exception("ID invalido, tem de ser positivo e valido");
            }
        }

        public Empresa()
        {
            
        }

        public override string ToString()
        {
            string baseDados = "";
            for(int posicao = 0; posicao < conjuntoDeFuncionarios.Length; posicao++)
            {
                if(conjuntoDeFuncionarios[posicao] != null)
                {
                    baseDados += "\nID "+ (posicao+1) + "-> " + conjuntoDeFuncionarios[posicao] + "\n";
                }
            }
            return baseDados;
        }
    }
}
