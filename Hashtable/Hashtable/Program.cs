using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema conjuntProd = new Sistema();

            conjuntProd.inserirNovoArtigo(new Artigo("Ananás", 3.43, 2, 2, 100));
            conjuntProd.inserirNovoArtigo(new Artigo("Peras", 2.43, 6, 0, 122));
            conjuntProd.inserirNovoArtigo(new Artigo("Tangerinas", 5.93, 3, 6, 213));
            conjuntProd.inserirNovoArtigo(new Artigo("Laranjas", 3.43, 2,2, 125));

            string opcao = "";
            int cod = -1;
            double num = -1;
            int stock = -1;
            bool estado = true;

            string menu = "Mini-Mercado:\n\n1-> Adicionar um novo Artigo\n2-> Alterar preço de um Artigo\n3-> Alterar stock de um Artigo" +
                "\n4-> Alterar estado de um Artigo\n5-> Listar Artigos disponiveis\n6-> Listar Artigos\n7-> Sair\n\nUser: ";
            do
            {
                Console.Write(menu);
                switch (opcao = Console.ReadLine())
                {
                    case "1":
                    Console.Clear();
                        try
                        {
                            Console.WriteLine("Novo Artigo\n\n");
                            conjuntProd.inserirNovoArtigo(novoArtigo());
                            Console.Clear();
                            Console.WriteLine("Novo artigo registado com sucesso..");
                            Console.ReadLine();
                        }
                        catch(Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Alterar preço\n\n");
                            Console.Write("Código do Artigo: ");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nNovo preço: ");
                            num = Convert.ToDouble(Console.ReadLine());
                            conjuntProd.MudarPreco(cod,num);
                            Console.Clear();
                            Console.WriteLine("Preço alterado com sucesso...");
                            Console.ReadLine();
                        }
                        catch(Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Alterar Stock \n");
                            Console.Write("\nCódigo do Artigo: ");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nQual o novo stock: ");
                            stock = Convert.ToInt32(Console.ReadLine());
                            conjuntProd.MudarStock(cod,stock);
                            Console.Clear();
                            Console.WriteLine("Stock alterado com sucesso...");
                            Console.ReadLine();
                                
                        }catch(Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Qual estado de artigo que deseja alterar \n\n");
                            Console.Write("Código do Artigo: ");
                            cod = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nEstado do artigo(true ou false):");
                            estado = Convert.ToBoolean(Console.ReadLine());
                            conjuntProd.MudarEstadoArtigo(cod,estado);
                            Console.WriteLine("Estado De artigo alterado com sucesso");
                        }catch(Exception erro)
                        {
                            Console.Clear();
                            Console.WriteLine(erro.Message);
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Códigos de Artigos Disponiveis\n\n");
                            foreach (int listCodigos in conjuntProd.DevolverArtigosDisponiveis())
                            {
                                if (listCodigos != 0)
                                {
                                    Console.WriteLine("Código -> " + listCodigos);
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
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Lista de Artigos\n\n");
                        Console.WriteLine(conjuntProd.ToString());
                        Console.ReadLine();
                        break;
            }
                Console.Clear();
            } while (opcao != "7");
        }

        public static Artigo novoArtigo()
        {
            Artigo novoArtigo = new Artigo();
            Console.Write("Designação: ");
            novoArtigo.Designacao = Console.ReadLine();

            Console.Write("\nPreço: ");
            novoArtigo.Preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nPeso: ");
            novoArtigo.Peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("\nStock: ");
            novoArtigo.Stock = Convert.ToInt32(Console.ReadLine());

            if (novoArtigo.Stock>0)
            {
                novoArtigo.Disponivel = true;
            }

            Console.Write("\nCódigo: ");
            novoArtigo.Codigo = Convert.ToInt32(Console.ReadLine());

            return novoArtigo;
        }
    }
}
