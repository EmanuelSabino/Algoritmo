using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Algoritmos
{
    enum SituacaoMatrimonialEnum
    {
        Solteiro, Casado, Divorciado, Viúvo, Separado
    }

    class Funcionario
    {
        private SituacaoMatrimonialEnum situacaoMatrimonial;
        private double salarioBase;
        private int numeroTitulares;
        private int numeroDependente;
        private DateTime dataFimRegisto;
        private int numFuncionario;
        private string nome;
        private int idade;
        private DateTime diaNascimento;
        private bool defeciencias;
        private DateTime registo;

        public string SituacaoMatrimonial
        {
            get { return situacaoMatrimonial.ToString(); }
            set
            {
                if (value.ToLower() == SituacaoMatrimonialEnum.Casado.ToString().ToLower())
                {
                    situacaoMatrimonial = SituacaoMatrimonialEnum.Casado;
                }
                else if (value.ToLower() == SituacaoMatrimonialEnum.Divorciado.ToString().ToLower())
                {
                    situacaoMatrimonial = SituacaoMatrimonialEnum.Divorciado;
                }
                else if (value.ToLower() == SituacaoMatrimonialEnum.Separado.ToString().ToLower())
                {
                    situacaoMatrimonial = SituacaoMatrimonialEnum.Separado;
                }
                else if (value.ToLower() == SituacaoMatrimonialEnum.Solteiro.ToString().ToLower())
                {
                    situacaoMatrimonial = SituacaoMatrimonialEnum.Solteiro;
                }
                else if (value.ToLower() == SituacaoMatrimonialEnum.Viúvo.ToString().ToLower())
                {
                    situacaoMatrimonial = SituacaoMatrimonialEnum.Viúvo;
                }
                else
                {
                    throw new Exception("Dados inválidos, a situação matrimonial tem de estar entre os valores referidos");
                }
            }
        }
        public int NumFuncionario
        {
            get => numFuncionario;

            set
            {
                if (value > 0)
                {
                    numFuncionario = value;
                }

                else
                {
                    throw new Exception("O Funcionario não pode conter numeros negativos");
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
                    throw new Exception("O nome do Funcionario nao pode estar em branco");
                }

            }

        }
        public int Idade
        {
            get { return idade; }
            set
            {
                if (value <= 90 && value >= 18)
                {
                    idade = value;
                }
                else
                {
                    throw new Exception("Idade inválida, o Funcionario não pode ser menor de idade e a idade não pode ser superior a 90");
                }
            }
        }
        public DateTime DiaNascimento
        {
            get { return diaNascimento; }
            set
            {

                if (value < DateTime.Now)
                    diaNascimento = value;

                else
                    throw new Exception("Erro a data de nascimento não pode ser maior que o dia de hoje");

            }
        }
        public double SalarioBase
        {
            get { return salarioBase; }
            set
            {
                if (value > 0)
                    salarioBase = value;
                else
                    throw new Exception("Salário incorreto");
            }
        }
        public int NumeroTitulares
        {
            get => numeroTitulares;
            set
            {
                if (value <= 2 && value >= 0)
                    numeroTitulares = value;
                else
                    throw new Exception("Nº de titulares excedido ou esta a negativo");
            }
        }
        public int NumeroDependente
        {
            get => numeroDependente;
            set
            {
                if (value >= 0 && value <= 30)
                {
                    numeroDependente = value;
                }
                else
                {
                    throw new Exception("Só é aceita entre 0-30 o numero de dependentes");
                }
            }
        }
        public DateTime DataInicioRegisto { get => registo; set => registo = value; }
        public DateTime DataFimRegisto { get => dataFimRegisto; set => dataFimRegisto = value; }
        public bool Defeciencias
        {
            get { return defeciencias; }
            set
            {
                if(numeroDependente == 0)
                {
                    defeciencias = false;
                }
                else
                {
                    defeciencias = value;
                }
            }
        }
        //metodo
        public double CalculoSalarioLiquido()
        {
            double salarioLiquido;
            if(numeroDependente == 0)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 4.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 7.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 8.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 10.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 11.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 12.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 13.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 14.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 15.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 16.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 17.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 19.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 20.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 21.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 22.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 23.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 24.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 25.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 26.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 27.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 29.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 30.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 32.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 33.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 34.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 36.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 37.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 39.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 40.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 41.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 42.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 43.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 44.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 45.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            if (numeroDependente == 1)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 1.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 4.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 5.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 7.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 8.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 9.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 11.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 12.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 14.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 15.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 16.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 18.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 19.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 21.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 22.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 23.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 24.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 25.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 26.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 27.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 29.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 30.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 32.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 33.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 34.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 36.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 37.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 39.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 40.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 41.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 42.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 43.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 44.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 45.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            if (numeroDependente == 2)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 0.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 2.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 3.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 6.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 8.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 8.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 10.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 11.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 13.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 14.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 15.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 16.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 18.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 19.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 20.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 21.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 23.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 24.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 25.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 26.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 28.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 29.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 31.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 32.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 33.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 35.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 36.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 38.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 39.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 40.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 41.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 42.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 43.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 44.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            if (numeroDependente == 3)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 0.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 0.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 2.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 3.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 5.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 6.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 8.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 9.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 11.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 12.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 13.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 14.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 16.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 17.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 18.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 19.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 20.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 21.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 22.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 23.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 26.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 28.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 29.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 31.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 32.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 34.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 35.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 37.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 39.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 40.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 41.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 42.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 43.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 44.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            if (numeroDependente == 4)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 0.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 3.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 4.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 4.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 7.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 8.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 9.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 10.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 11.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 13.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 15.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 16.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 17.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 18.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 19.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 20.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 21.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 23.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 26.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 27.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 28.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 30.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 31.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 34.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 35.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 37.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 38.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 40.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 41.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 42.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 43.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 44.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            if(numeroDependente > 5)
            {
                if (SalarioBase > 0 && SalarioBase <= 659.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 659.00 && SalarioBase <= 686.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 686.00 && SalarioBase <= 718.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 718.00 && SalarioBase <= 739.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 739.00 && SalarioBase <= 814.00)
                {
                    salarioLiquido = (SalarioBase * 0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 814.00 && SalarioBase <= 922.00)
                {
                    salarioLiquido = (SalarioBase * 1.3) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 922.00 && SalarioBase <= 1005.00)
                {
                    salarioLiquido = (SalarioBase * 3.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1005.00 && SalarioBase <= 1065.00)
                {
                    salarioLiquido = (SalarioBase * 4.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1065.00 && SalarioBase <= 1143.00)
                {
                    salarioLiquido = (SalarioBase * 5.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1143.00 && SalarioBase <= 1225.00)
                {
                    salarioLiquido = (SalarioBase * 6.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1225.00 && SalarioBase <= 1321.00)
                {
                    salarioLiquido = (SalarioBase * 8.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1321.00 && SalarioBase <= 1424.00)
                {
                    salarioLiquido = (SalarioBase * 9.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1424.00 && SalarioBase <= 1562.00)
                {
                    salarioLiquido = (SalarioBase * 10.5) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1562.00 && SalarioBase <= 1711.00)
                {
                    salarioLiquido = (SalarioBase * 12.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1711.00 && SalarioBase <= 1870.00)
                {
                    salarioLiquido = (SalarioBase * 13.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1870.00 && SalarioBase <= 1977.00)
                {
                    salarioLiquido = (SalarioBase * 14.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 1977.00 && SalarioBase <= 2090.00)
                {
                    salarioLiquido = (SalarioBase * 16.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2090.00 && SalarioBase <= 2218.00)
                {
                    salarioLiquido = (SalarioBase * 17.9) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2218.00 && SalarioBase <= 2367.00)
                {
                    salarioLiquido = (SalarioBase * 18.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2367.00 && SalarioBase <= 2535.00)
                {
                    salarioLiquido = (SalarioBase * 20.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2535.00 && SalarioBase <= 2767.00)
                {
                    salarioLiquido = (SalarioBase * 21.0) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 2767.00 && SalarioBase <= 3104.00)
                {
                    salarioLiquido = (SalarioBase * 22.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3104.00 && SalarioBase <= 3534.00)
                {
                    salarioLiquido = (SalarioBase * 25.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 3534.00 && SalarioBase <= 4118.00)
                {
                    salarioLiquido = (SalarioBase * 26.7) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4118.00 && SalarioBase <= 4650.00)
                {
                    salarioLiquido = (SalarioBase * 28.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 4650.00 && SalarioBase <= 5194.00)
                {
                    salarioLiquido = (SalarioBase * 29.2) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5194.00 && SalarioBase <= 5880.00)
                {
                    salarioLiquido = (SalarioBase * 30.1) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 5880.00 && SalarioBase <= 6727.00)
                {
                    salarioLiquido = (SalarioBase * 34.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 6727.00 && SalarioBase <= 7939.00)
                {
                    salarioLiquido = (SalarioBase * 35.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 7939.00 && SalarioBase <= 9560.00)
                {
                    salarioLiquido = (SalarioBase * 37.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 9560.00 && SalarioBase <= 11282.00)
                {
                    salarioLiquido = (SalarioBase * 38.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 11282.00 && SalarioBase <= 18854.00)
                {
                    salarioLiquido = (SalarioBase * 39.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 18854.00 && SalarioBase <= 20221.00)
                {
                    salarioLiquido = (SalarioBase * 40.4) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 20221.00 && SalarioBase <= 22749.00)
                {
                    salarioLiquido = (SalarioBase * 41.6) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 22749.00 && SalarioBase <= 25276.00)
                {
                    salarioLiquido = (SalarioBase * 42.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
                if (SalarioBase > 25276.00)
                {
                    salarioLiquido = (SalarioBase * 43.8) / 100;
                    return Math.Round(SalarioBase - salarioLiquido, 2);
                }
            }
            return SalarioBase;
        }

        public Funcionario()
        {

        }

        public Funcionario(int numFuncionarioValue, string nomeValue,int idadeValue, string estadoValue, 
            DateTime anoNascimentoValue, double salarioValue, int numTitularesValue,int numDependentValue,
            DateTime inicioRegistoValue, DateTime datFimRegistoValue,bool defecValueValue)
        {
            Idade = idadeValue;
            Nome = nomeValue;
            NumFuncionario = numFuncionarioValue;
            SituacaoMatrimonial = estadoValue;
            DiaNascimento = anoNascimentoValue;
            SalarioBase = salarioValue;
            NumeroTitulares = numTitularesValue;
            NumeroDependente = numDependentValue;
            DataInicioRegisto = inicioRegistoValue;
            DataFimRegisto = datFimRegistoValue;
            Defeciencias = defecValueValue;
        }
      
        public override string ToString()
        {
            return Nome + "; " + Idade + " anos; número: " + NumFuncionario + "; " + SituacaoMatrimonial
                + "; Salario: " + Math.Round(SalarioBase,2) + "$(euros); Titulares: " + numeroTitulares + "; Dependentes: " 
                + NumeroDependente + "; InicioContrato: " + DataInicioRegisto.ToShortDateString() + "; FimContrato: " + DataFimRegisto.ToShortDateString();
        }
    }
}
