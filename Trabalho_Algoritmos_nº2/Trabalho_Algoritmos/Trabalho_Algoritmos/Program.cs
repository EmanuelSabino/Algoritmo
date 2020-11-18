using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            //variaveis para opções
            int IdFunc = 0, newNumberFunc;
            string opcao;
            bool continuar = false;
            //chamar a classe empresa
            Empresa empresa = new Empresa();
            //criar já uns funcionarios 
            empresa.AdiocionarFunc = new Funcionario(13, "Esqueleto", 31, "casado", new DateTime(1989, 12, 12), 715
               , 2, 2, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            empresa.AdiocionarFunc = new Funcionario(122, "Ja Fumega", 31, "casado", new DateTime(1989, 12, 12), 1020
                , 2, 0, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            empresa.AdiocionarFunc = new Funcionario(14, "Sulfato", 32, "casado", new DateTime(1989, 12, 12), 1200
               , 2, 1, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            empresa.AdiocionarFunc = new Funcionario(100, "Agostinho", 30, "casado", new DateTime(1988, 12, 12), 2300
                , 2, 2, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), false);
            empresa.AdiocionarFunc = new Funcionario(12, "Zé Pequeno", 50, "casado", new DateTime(1970, 12, 12), 1200
                , 2, 4, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            empresa.AdiocionarFunc = new Funcionario(212, "Moelas", 50, "casado", new DateTime(1970, 12, 12), 1200
                , 2, 4, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            empresa.AdiocionarFunc = new Funcionario(142, "Colmeia", 50, "casado", new DateTime(1970, 12, 12), 3200
                , 2,1, new DateTime(2008, 12, 12), new DateTime(2040, 12, 12), true);
            //variaveis para o funcionario
            int idadeFunc = 0, numFunc = 0, numTitulares = 0, numDependentes = 0;
            double salario = 0;
            string nomeFunc = "", situacaoMatrimonial = "";
            DateTime inicioRegisto = DateTime.Now, fimRegisto = DateTime.Now, anoNascimento = DateTime.Now;
            char contemDefeciencias = ' ';

            do
            {
                continuar = false;
                Console.WriteLine("O que deseja:\n\n1-> Ver todos os Funcionarios\n2-> Atualizar ou apagar um Funcionario" +
                "\n3-> Mostrar calculo do Salario Liquido de um funcionario\n4-> Registar um Funcionario\n5-> Adicionar mais vagas na empresa\n6-> " +
                "Ordenação SelectionSort(ordenar só pelo nome)\n7-> Ordenação InsertionSort(ordenar por números de dependentes e pelo nome)\n" +
                "\nPara terminar escreva exit");
                Console.Write("\nUtilizador: ");

                switch (opcao = Console.ReadLine().Trim())
                {
                    case ("1"):
                        Console.Clear();
                        Console.Write("Todos os Funcionarios:");
                        Console.Write("\n{0}\n\ncarregue enter para terminar", empresa.ToString());
                        Console.ReadLine();
                        break;
                    case ("2"):
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Atualizar ou Apagar Funcionarios\n\n1-> Atualizar Funcionario\n2-> Apagar Funcionario\n3-> Cancelar");
                            Console.Write("\nUtilizador: ");
                            switch (opcao = Console.ReadLine())
                            {
                                case ("1"):
                                    Console.Clear();
                                    do
                                    {
                                        Console.WriteLine("Funcionarios:\n\n{0} \n\n", empresa.ToString());
                                        Console.Write("Qual funcionario vai atualizar:\nSe por acaso quiser cancelar introduza" +
                                            " -3\nID--> ");
                                        opcao = Console.ReadLine();
                                        Console.Clear();
                                        try
                                        {
                                            if (Convert.ToInt32(opcao) > 0)
                                                IdFunc = Convert.ToInt32(opcao);
                                            empresa.VerificarIdFunc(IdFunc);
                                            do
                                            {
                                                Console.Clear();
                                                Console.Write("O que atualizar:\n1-> Número do Funcionario\n" +
                                                    "2-> Salario Base do Funcionario\n3-> Situação Matrimonial\n\nutilizador: ");
                                                switch (opcao = Console.ReadLine())
                                                {
                                                    case "1":
                                                        Console.Clear();
                                                        do
                                                        {
                                                            try
                                                            {
                                                                Console.WriteLine("Números já usados: {0}", empresa.NumerosDeFunc());
                                                                Console.Write("Atualizar número de Funcionario:\nnovo número-> ");
                                                                newNumberFunc = Convert.ToInt32(Console.ReadLine());
                                                                empresa.MudarNumeroFunc(newNumberFunc, IdFunc);
                                                                continuar = true;
                                                            }
                                                            catch (Exception ErroNumber)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(ErroNumber.Message);
                                                                Console.WriteLine("---------------------------");
                                                            }
                                                        } while (continuar == false);
                                                        opcao = "-1";
                                                        break;
                                                    case "2":
                                                        Console.Clear();
                                                        do
                                                        {
                                                            try
                                                            {
                                                                Console.Write("Atualizar salario base do Funcionario\nnovo salario-> ");
                                                                salario = Convert.ToDouble(Console.ReadLine());
                                                                empresa.MudarSalarioBaseFunc(salario, IdFunc);
                                                                continuar = true;
                                                            }
                                                            catch (Exception ErroSalario)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(ErroSalario.Message);
                                                                Console.WriteLine("---------------------------");
                                                            }
                                                        } while (continuar == false);
                                                        opcao = "-1";
                                                        break;
                                                    case "3":
                                                        Console.Clear();
                                                        do
                                                        {
                                                            try
                                                            {
                                                                Console.Write("Atualizar Situação Matrimonial\nValores possiveis: Casado, Viúvo, Solteiro," +
                                                                    "Separado\nNova Stuação Matromonial-> ");
                                                                situacaoMatrimonial = Console.ReadLine();
                                                                empresa.MudarEstadoFunc(situacaoMatrimonial, IdFunc);
                                                                continuar = true;
                                                            }
                                                            catch (Exception ErroEstado)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine(ErroEstado.Message);
                                                                Console.WriteLine("----------------------");
                                                            }
                                                        } while (continuar == false);
                                                        opcao = "-1";
                                                        break;
                                                }
                                            } while (opcao != "-1");

                                        }
                                        catch (Exception erro)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("{0}\n---------------------------", erro.Message);
                                        }
                                    } while (opcao != "-1");
                                    break;
                                case ("2"):
                                    Console.Clear();
                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("Funcionarios:\n\n{0} \n\n", empresa.ToString());
                                            Console.Write("Qual funcionario apagar:\nSe por acaso quiser cancelar introduza" +
                                                " -3 \nID--> ");
                                            IdFunc = Convert.ToInt32(Console.ReadLine());
                                            if (IdFunc == -3)
                                            {
                                                continuar = true;
                                            }
                                            if (IdFunc != -3)
                                            {
                                                Console.Clear();
                                                empresa.ApagarFunc = IdFunc;
                                                continuar = true;
                                            }
                                        }
                                        catch (Exception errorValue)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("{0}\n---------------------------", errorValue.Message);
                                        }
                                    } while (continuar == false);
                                    opcao = "-1";
                                    break;
                                case ("3"):
                                    opcao = "-1";
                                    break;
                            }
                            Console.Clear();
                        } while (opcao != "-1");
                        break;
                    case ("3"):
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.Write("Todos os Funcionarios:");
                                Console.Write("\n{0}\n\nQual Funcionario quer ver o calculo do salario liquido\nSe por acaso quiser cancelar " +
                                    "introduza -3\nID-->", empresa.ToString());
                                IdFunc = Convert.ToInt32(Console.ReadLine());
                                if (IdFunc == -3)
                                {
                                    continuar = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resultado: {0}", empresa.SalarioLiquido(IdFunc));
                                    Console.Write("Para terminar carregue enter");
                                    Console.ReadLine();
                                    continuar = true;
                                }
                            }
                            catch (Exception ErroSalarioLiquido)
                            {
                                Console.Clear();
                                Console.WriteLine(ErroSalarioLiquido.Message);
                                Console.WriteLine("---------------------------------");
                            }
                            Console.Clear();
                        } while (continuar == false);
                        break;
                    case ("4"):
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Atenção, introduza os valores certos porque se não tera de prencher tudo de novo");
                            try
                            {
                                DadosFuncionario(nomeFunc, idadeFunc, numFunc, anoNascimento, inicioRegisto, fimRegisto, salario, situacaoMatrimonial,
                                                numTitulares, numDependentes, contemDefeciencias, empresa);
                                continuar = true;
                            }
                            catch (Exception erroValue)
                            {
                                Console.Clear();
                                Console.WriteLine(erroValue.Message);
                            }

                            if (continuar == false)
                            {
                                Console.Write("Quer tentar de novo(S/N): ");
                                opcao = Console.ReadLine();
                                if (opcao.ToUpper().Trim() != "S")
                                {
                                    continuar = true;
                                }
                                Console.Clear();
                            }
                        } while (continuar == false);
                        break;
                    case ("5"):
                        Console.Clear();
                        do
                        {
                            try
                            {
                                if (empresa.TamanhoDoConjuntoDeFuncionarios() < 200)
                                {
                                    Console.WriteLine("Tamanho disponivel de vagas de Funcionarios na Empresa(preenchidos/não preenchidos): {0}", empresa.TamanhoDoConjuntoDeFuncionarios());
                                    Console.Write("\nQuantas vagas adicionar(no maximo só pode adicionar 100): ");
                                    newNumberFunc = Convert.ToInt32(Console.ReadLine());
                                    empresa.AumentarVagas = newNumberFunc;
                                    continuar = true;
                                }
                                else
                                {
                                    Console.WriteLine("A empresa já tem o número de vagas ao maximo(200)");
                                    Console.ReadLine();
                                    continuar = true;
                                }
                            }
                            catch (Exception ErroVagas)
                            {
                                Console.Clear();
                                Console.WriteLine(ErroVagas.Message);
                                Console.WriteLine("---------------------------------");
                            }
                        } while (continuar == false);
                        break;
                    case "6":
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1-> Ver Funcionarios ordenados com todos os detalhes\n2-> Ver Funcionarios ordenados apenas " +
                            "alguns detalhes (nºFuncionario, nome, idade, nºDependentes)\n");
                            Console.Write("Utilizador: ");
                            switch (opcao = Console.ReadLine().Trim())
                            {
                                case "1":
                                    Console.Clear();
                                    foreach (Funcionario list in empresa.SelectionSort())
                                    {
                                        Console.WriteLine("\n{0}", list);
                                    }
                                    Console.Write("\n\n carregue enter para terminar ");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.Clear();
                                    foreach (Funcionario list in empresa.SelectionSort())
                                    {
                                        Console.WriteLine("\n NºFuncionario: {0}, Nome: {1}, Idade: {2}, nºDependente: {3}, Sálario: {4}", list.NumFuncionario,
                                            list.Nome, list.Idade, list.NumeroDependente, list.SalarioBase);
                                    }
                                    Console.Write("\n\n carregue enter para terminar ");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (opcao != "1" && opcao != "2");
                        break;
                    case "7":
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1-> Ver Funcionarios ordenados com todos os detalhes\n2-> Ver Funcionarios ordenados apenas " +
                            "alguns detalhes (nºFuncionario, nome, idade, nºDependentes)\n");
                            Console.Write("Utilizador: ");
                            switch (opcao = Console.ReadLine().Trim())
                            {
                                case "1":
                                    Console.Clear();
                                    foreach (Funcionario list in empresa.InsertionSort())
                                    {
                                        Console.WriteLine("\n{0}", list);
                                    }
                                    Console.Write("\n carregue enter para terminar ");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.Clear();
                                    foreach (Funcionario list in empresa.InsertionSort())
                                    {
                                        Console.WriteLine("\n NºFuncionario: {0}, Nome: {1}, Idade: {2}, nºDependentes: {3}, Sálario: {4}", list.NumFuncionario,
                                            list.Nome, list.Idade,list.NumeroDependente,list.SalarioBase);
                                    }
                                    Console.Write("\n carregue enter para terminar ");
                                    Console.ReadLine();
                                    break;
                            }
                        } while (opcao != "1" && opcao != "2");
                        break;
                }
                Console.Clear();
            } while (opcao.ToLower().Trim() != "exit");
        }

        public static void  DadosFuncionario(string nomeFuncValue, int idadeValue, int numFuncValue, DateTime diaNascimentoValue,DateTime inicioContratoValue,
            DateTime fimContratoValue, double salarioBaseValue,string situacaoMatrimonialValue, int numTitularesValue, int numDependentesValue,
            char contemDefecienciasValue, Empresa empresaValue)
        {
            Funcionario funcTeste = new Funcionario();

            Console.Write("Nome--> ");
            nomeFuncValue = Console.ReadLine();
            funcTeste.Nome = nomeFuncValue;

            Console.Write("Idade--> ");
            idadeValue = Convert.ToInt32(Console.ReadLine());
            funcTeste.Idade = idadeValue;

            Console.WriteLine("Números de funcionarios não disponiveis-->{0}", empresaValue.NumerosDeFunc());
            Console.Write("Número do Funcionario--> ");
            numFuncValue = Convert.ToInt32(Console.ReadLine());    
            funcTeste.NumFuncionario = numFuncValue;

            Console.Write("Ano de nascimento(ano,mes,dia)--> ");
            diaNascimentoValue = Convert.ToDateTime(Console.ReadLine());
            funcTeste.DiaNascimento = diaNascimentoValue;

            Console.Write("Inicio do contrato(ano,mes,dia)--> ");
            inicioContratoValue = Convert.ToDateTime(Console.ReadLine());
            funcTeste.DataInicioRegisto = inicioContratoValue;
            if (inicioContratoValue < diaNascimentoValue || ((inicioContratoValue.Year - diaNascimentoValue.Year) <= 18))
            {
                Console.Clear();
                throw new Exception("Dados Inválidos, a data de inico de contrato não pode ser menor que a data de nascimento" +
                    " e a data de inicio de registo comparado com o nascimento tem de ter mais de 17 anos");
            }

            Console.Write("Fim do contrato(ano,mes,dia)--> ");
            fimContratoValue = Convert.ToDateTime(Console.ReadLine());
            funcTeste.DataFimRegisto = fimContratoValue;
            if (inicioContratoValue >= fimContratoValue && (fimContratoValue.Year - inicioContratoValue.Year) >= 90)
            {
                Console.Clear();
                throw new Exception("Dados Inválidos, a data de fim de contrato não pode ser menor que o inicio de contrato e não pode " +
                    "exceder os 72 anos");
            }

            Console.Write("Salário(euro,centimos)--> ");
            salarioBaseValue = Convert.ToDouble(Console.ReadLine());
            funcTeste.SalarioBase = Math.Round(salarioBaseValue,2);

            Console.Write("Situação Matrimonial(Solteiro, Casado, Divorciado, Viúvo, Separado)--> ");
            situacaoMatrimonialValue = Console.ReadLine();
            funcTeste.SituacaoMatrimonial = situacaoMatrimonialValue;

            Console.Write("Número de titulares(0-2)--> ");
            numTitularesValue = Convert.ToInt32(Console.ReadLine());
            funcTeste.NumeroTitulares = numTitularesValue;

            Console.Write("Número de Dependentes--> ");
            numDependentesValue = Convert.ToInt32(Console.ReadLine());
            funcTeste.NumeroDependente = numDependentesValue;

            bool contemDefecientesBool = true;
            Console.Write("Contém Defecientes(apenas 's' ou 'n')--> ");
            contemDefecienciasValue = Convert.ToChar(Console.ReadLine());
            
            if(contemDefecienciasValue.ToString().ToUpper() != "S")
            {
                contemDefecientesBool = false;
            }
            empresaValue.AdiocionarFunc = new Funcionario(numFuncValue, nomeFuncValue, idadeValue, situacaoMatrimonialValue, diaNascimentoValue, salarioBaseValue, numTitularesValue,
            numDependentesValue, inicioContratoValue, fimContratoValue, contemDefecientesBool);
        }
    }
}
