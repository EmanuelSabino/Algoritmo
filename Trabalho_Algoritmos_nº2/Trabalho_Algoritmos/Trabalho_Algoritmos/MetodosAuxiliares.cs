using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Algoritmos
{
    class MetodosAuxiliares
    {
        public static bool Less(string vetorJ, string vetorMin)
        {
            if (vetorJ.CompareTo(vetorMin) < 0)
                return true;
            else
                return false;
        }
        public static void Swap(ref Funcionario vetorMin,ref Funcionario vetorI)
        {
            Funcionario aux = vetorI;
            vetorI = vetorMin;
            vetorMin = aux;
        }
        public static void ComplexSwap(ref Funcionario vetorA, ref Funcionario vetorB) 
        {
            Funcionario aux;
            if(vetorA.NumeroDependente != vetorB.NumeroDependente)
            {
                if(vetorA.NumeroDependente > vetorB.NumeroDependente)
                {
                    aux = vetorA;
                    vetorA = vetorB;
                    vetorB = aux;
                }
            }else if(vetorA.NumeroDependente == vetorB.NumeroDependente)
            {
                if (vetorA.Nome.CompareTo(vetorB.Nome) > 0)
                {
                    aux = vetorA;
                    vetorA = vetorB;
                    vetorB = aux;
                }
            }
        }
    }
}
