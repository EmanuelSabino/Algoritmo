using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listaguem2_InsercaoOrdenada
{
    class Program
    {
        static void Main(string[] args)
        {
            ConjuntoAlunos alunos = new ConjuntoAlunos();

            alunos.InsercaoOrdenada("Ze", 14, new DateTime(1999, 12, 12), Curso.RSI);
            alunos.InsercaoOrdenada("Francisco", 1023, new DateTime(1999, 12, 12), Curso.PMJD);
            alunos.InsercaoOrdenada("JoZe", 323, new DateTime(1999, 12, 12), Curso.RSI);
            alunos.InsercaoOrdenada("Maria", 134, new DateTime(1999, 12, 12), Curso.RSI);

            string user = "";
            int numero = 0;
            int quantidadeAlunos = 0;

            do
            {
                Console.Clear();
                Console.Write("O que deseja:\n \n1->Criar aluno novo\n2->Remover aluno\n3->Listar alunos\n4->Ver alunos a partir de um curso Inscrito\n" +
                "5->Sair\n\nUser: ");
                user = Console.ReadLine().Trim();

                switch (user)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Novo aluno\n");
                        try
                        {
                            AntigoAluno teste = InscricaoAluno();
                            if (teste != null)
                            {
                                alunos.InsercaoOrdenada(teste.Nome, teste.NumAluno, teste.DataNascimento, teste.CursoInscrito);
                                Console.Clear();
                                Console.WriteLine("Registado com sucesso...\nCarregue enter para terminar");
                                Console.ReadLine();
                            }
                        }
                        catch (Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);

                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        try
                        {
                            quantidadeAlunos = alunos.QuantosAluno(null);
                            Console.WriteLine("Alunos: \n");
                            Console.WriteLine("Nº    Curso  Nome\n");
                            foreach (AntigoAluno listAlunos in alunos.Listagem())
                            {
                                Console.WriteLine("{0}", listAlunos.ToString());
                            }
                            Console.WriteLine("\n\nRemover antigo aluno");
                            Console.Write("\n\nNúmero de aluno -> ");
                            numero = Convert.ToInt32(Console.ReadLine());
                            if (numero < 0) throw new Exception("Número inválido tem de ser positivo");
                            alunos.RemoverAluno(numero);

                            if (quantidadeAlunos != alunos.QuantosAluno(null))
                            {
                                Console.Clear();
                                Console.WriteLine("Aluno apagado com sucesso...\ncarregue enter para continuar");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Nenhum aluno removido...\n número inválido");
                                Console.ReadLine();
                            }
                        }
                        catch (Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);
                            Console.WriteLine("Carregue enter para continuar");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Alunos: \n");
                        Console.WriteLine("Nº    Curso  Nome\n");
                        foreach (AntigoAluno listAlunos in alunos.Listagem())
                        {
                            Console.WriteLine("{0}", listAlunos.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Ver antigos Alunos num determinado curso");
                            Console.Write("Qual curso escolher \n\n1: TPSI \n2: RSI \n3: PMJD \n\nCurso: ");
                            numero = Convert.ToInt32(Console.ReadLine());
                            if (numero < 1 || numero > 3) throw new Exception("Curso não existente");
                            Console.Clear();
                            Console.WriteLine("Alunos de {0}", (Curso)(numero - 1));
                            Console.WriteLine("\nNº  Nome\n");
                            foreach (AntigoAluno listAlunos in (alunos.Consulta((Curso)(numero))))
                            {
                                if (listAlunos != null)
                                {
                                    Console.WriteLine("{0}  {1}", listAlunos.NumAluno, listAlunos.Nome);
                                }
                            }

                            Console.ReadLine();
                        }
                        catch (Exception erro)
                        {
                            Console.WriteLine(erro.Message);
                            Console.ReadLine();
                        }
                        break;
                }
            } while (user.Trim() != "5");
        }
        public static AntigoAluno InscricaoAluno()
        {
            AntigoAluno alunoValue = new AntigoAluno();
            try
            {
                Console.WriteLine("Inscrição do Aluno\n");

                Console.Write("\nNome Aluno: ");
                alunoValue.Nome = Console.ReadLine();

                Console.Write("\nNúmero do Aluno: ");
                alunoValue.NumAluno = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nData Nascimento: ");
                alunoValue.DataNascimento = Convert.ToDateTime(Console.ReadLine());

                Console.Write("\nCurso Inscrito: \nTPSI = 0\nRSI = 1\nPMJD = 2\nSelecionar com um número apenas\n\nCurso: ");
                int cursoValue = 0;
                cursoValue = Convert.ToInt32(Console.ReadLine());
                if (cursoValue < 0 || cursoValue > 3) throw new Exception("Curso Inválido");
                alunoValue.CursoInscrito = (Curso)(cursoValue);

            }
            catch (Exception erroInscricao)
            {
                Console.Clear();
                Console.WriteLine(erroInscricao.Message);
                Console.WriteLine("\nCarregue enter para continuar");
                Console.ReadLine();
                Console.Clear();
                alunoValue = null;
            }
            return alunoValue;
        }
    }
}
