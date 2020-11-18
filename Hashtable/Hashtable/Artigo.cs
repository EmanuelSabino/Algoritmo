using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Artigo
    {
        private string designacao;

        public string Designacao
        {
            get { return designacao; }
            set
            {
                string nomeDesignacao = "";
                if (value.Trim() != "")
                {
                    for (int posicao = 0; posicao < value.Trim().Length; posicao++)
                    {
                        if (char.IsNumber(value.Trim()[posicao]))
                        {
                            throw new Exception("Invalido designação não contem numeros");
                        }

                        if (posicao == 0 || value.Trim()[posicao - 1] == ' ')
                        {
                            nomeDesignacao += value.Trim()[posicao].ToString().ToUpper();
                        }

                        else
                        {
                            nomeDesignacao += value.Trim()[posicao].ToString().ToLower();
                        }
                    }
                    designacao = nomeDesignacao;
                }

                else
                {
                    throw new Exception("A designação não pode estar em branco");
                }
            }
        }

        private double preco;

        public double Preco
        {
            get { return preco; }
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Preco do artigo inválido");
                }
                else
                {
                    preco = value;
                }
            }
        }

        private double peso;

        public double Peso
        {
            get { return peso; }
            set
            {
                if(value <= 0)
                {
                    throw new Exception("Preço do artigo inválido");
                }
                peso = value;
            }
        }

        public bool disponivel;

        public bool Disponivel
        {
            get { return disponivel; }
            set
            {
                disponivel = value;
            }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set
            {
                if(value < 0)
                {
                    throw new Exception("Stock do artigo inválido");
                }
                else
                {
                    stock = value;
                }
            }
        }

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set
            {
                if (value <= 0) throw new Exception("Código do produto inválido ");
                else codigo = value;
            }
        }

        public Artigo()
        {

        }

        public Artigo(string designacaoValue, double precoValue, double pesoValue, int stockValue, int codigoValue)
        {
            if (stockValue > 0) Disponivel = true;
            else Disponivel = false;
            Designacao = designacaoValue;
            Preco = precoValue;
            Peso = pesoValue;
            Stock = stockValue;
            Codigo = codigoValue;
        }

        public override string ToString()
        {
            return "Designação: " + Designacao + ", Disponivel: " + Disponivel + ", Peso: "+ Peso .ToString().Replace(",",".")+ "Kg, Preço: "
                + Preco.ToString().Replace(",", ".") + ", Stock: " + Stock + ", Código: " + Codigo;
        }
    }
}
