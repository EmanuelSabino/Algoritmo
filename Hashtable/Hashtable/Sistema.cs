using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Sistema
    {
        private Artigo[] inventario = new Artigo[20];
        
        public Artigo[] inserirNovoArtigo(Artigo novoArtigo)
        {
            int tamanhoMax = inventario.Length;
            int posicao = novoArtigo.Codigo % 20;
            if (inventario[posicao] == null) inventario[posicao] = novoArtigo;
            else if (inventario[posicao].Codigo == novoArtigo.Codigo) throw new Exception("Código já existente");
            else
            {
                while (inventario[posicao] != null && tamanhoMax > 0)
                {
                    if (inventario[posicao].Designacao == novoArtigo.Designacao) throw new Exception("Artigo designlão já existente");
                    posicao++;       
                    tamanhoMax--;
                    if (posicao > inventario.Length - 1) posicao = 0;
                }
                if (tamanhoMax == 0 && inventario[posicao] != null) throw new Exception("Inventario Cheio");
                inventario[posicao] = novoArtigo;
            }
            return inventario;
        }

        public Artigo[] MudarPreco(int codigoValue, double Novopreco)
        {
            if (Novopreco < 0) throw new Exception("Preço inválido");
            else
            {
                inventario[procurar(codigoValue)].Preco = Novopreco;
                return inventario;
            }
        }

        public Artigo[] MudarStock(int codigoValue, int Novostock)
        {
            int indice = procurar(codigoValue);
            if (Novostock < 0) throw new Exception("Stock inválido");
            else if (Novostock == 0)
            {
                inventario[indice].Disponivel = false;
                inventario[indice].Stock = Novostock;
                return inventario;
            }
            else
            {
                inventario[indice].Stock = Novostock;
                return inventario;
            }
        }

        public Artigo[] MudarEstadoArtigo(int codigoValue, bool estadoValue)
        {
            Artigo verificarArt = inventario[procurar(codigoValue)];
            if (verificarArt.Disponivel == estadoValue) throw new Exception("Estado de artigo ficou igual, nada mudou");
            else if (estadoValue == true && verificarArt.Stock == 0) throw new Exception("Este artigo não pode estar disponivel, não tem nada em stock");
            else inventario[procurar(codigoValue)].Disponivel = estadoValue;
            return inventario;
        }

        public int[] DevolverArtigosDisponiveis()
        {
            int[] artigosDisp = new int[20];
            int posicao = 0;
            int posicaoD = 0;
            while (posicao < inventario.Length)
            {
                if(inventario[posicao] != null)
                {
                    if (inventario[posicao].Disponivel == true && inventario[posicao].Stock <= 2)
                    {
                        artigosDisp[posicaoD] = inventario[posicao].Codigo;
                        posicaoD++;
                    }
                }
                posicao++;
            }
            if (artigosDisp[0] == 0) throw new Exception("Sem Artigos sisponiveis");
            return artigosDisp;
        }

        public int procurar(int codValue)
        {
            int tamanhoMaximo = inventario.Length;
            int indice = codValue % inventario.Length;
            if(inventario[indice] == null)
            {
                throw new Exception("Esse Artigo não existe");
            }
            else
            {
                if (inventario[indice].Codigo == codValue)
                {
                    return indice;
                }
                else
                {
                    while (inventario[indice] != null && tamanhoMaximo > 0)
                    {
                        tamanhoMaximo--;
                        indice++;
                        if (indice > tamanhoMaximo - 1) indice = 0;
                        if (inventario[indice].Codigo == codValue) return indice;
                    }
                    throw new Exception("Esse Artigo não existe");
                }
            }
        }

        public override string ToString()
        {
            int posicao = 0;
            StringBuilder artigos = new StringBuilder();
            while(posicao < inventario.Length)
            {
                if (inventario[posicao] != null)
                {
                    artigos.AppendLine(inventario[posicao].ToString());
                }
                posicao++;
            }
            return "" + artigos;
        }
    }
}
