using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar=1, Adicionar , Remover,Entrar, Saida, Sair };
        static void Main(string[] args)
        {
            bool escolherSair = false;
            Carregar();
            while (escolherSair==false) {

                Console.WriteLine("sistema de estoque");
                Console.WriteLine("1-listar\n2-Adicionar produto\n3-Remover produto\n4-Entrada de estoque\n5-Saida de estoque\n6-Sair");
                try
                {
                    int opcao = int.Parse(Console.ReadLine());
                    if (opcao > 0 && opcao < 7)
                    {
                        Menu escolha = (Menu)opcao;
                        switch (escolha)
                        {
                            case Menu.Listar:
                                Listar();
                                Console.ReadKey();
                                break;
                            case Menu.Adicionar:
                                Cadastro();
                                break;
                            case Menu.Remover:
                                Remover();
                                break;
                            case Menu.Entrar:
                                entrada();
                                break;
                            case Menu.Saida:
                                saida();
                                break;
                            case Menu.Sair:
                                escolherSair = true;
                                break;



                        }
                    }
                    else
                    {

                        Console.WriteLine("Opção errada");
                        Console.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("digitou errado, iniciu");
                    Console.ReadKey();
                }
                Console.Clear();
            }

        }
        static void Listar()
        {
            int id = 0;
            Console.WriteLine("Lista de Produtos");
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine($"id: {id}");
                produto.Exibir();
                id++;
            }
            
        }
        static void entrada()
        {
            Listar();
            Console.WriteLine("Digite o Id q vc quer Dar entrada de estoque");
            int i = int.Parse(Console.ReadLine());
            if (i >= 0 && i < produtos.Count)
            {
                produtos[i].AdicionarEntrada();
            }
            else
            {
                Console.WriteLine("Opção errada");
            }
            Salvar();
        }
        static void saida()
        {
            Listar();
            Console.WriteLine("Digite o Id q vc quer Dar Saida de estoque");
            int i = int.Parse(Console.ReadLine());
            if (i >= 0 && i < produtos.Count)
            {
                produtos[i].AdicionarSaida();
            }
            else
            {
                Console.WriteLine("Opção errada");
            }
            Salvar();
        }
        static void Remover()
        {
            Listar();
            Console.WriteLine("Digite o Id q vc quer remover");
            int i = int.Parse(Console.ReadLine());
            if (i >=0 && i < produtos.Count)
            {
                produtos.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("Opção errada");
            }
            Salvar();

        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produto");
            Console.WriteLine("1-Produto fisico\n2-Ebook\n3-Cursos");
            int Escolha= int.Parse(Console.ReadLine());
            if (Escolha > 0 && Escolha < 4)
            {
                switch (Escolha)
                {
                    case 1:
                        CadastroProdFisico();
                        break;
                    case 2:
                        CadastroEbook();
                        break;
                    case 3:
                        Cursos();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Opção errada");
                Console.ReadKey();
            }
        }

        static void CadastroProdFisico()
        {
            Console.WriteLine("Cadastrando produto fisico");
            Console.WriteLine("Digite o nome: ");
            string nome= Console.ReadLine();
            Console.WriteLine("Digite o Preço");
            
                float Preco = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o Frete");
                float frete = float.Parse(Console.ReadLine());
                produtoFisico Pf = new produtoFisico(nome, Preco, frete);
                produtos.Add(Pf);
                Salvar();



        }
        static void CadastroEbook()
        {
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço");
            float Preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Autor");
            string Autor = Console.ReadLine();
            Ebook Pf = new Ebook(nome, Preco, Autor);
            produtos.Add(Pf);
            Salvar();
        }
        static void Cursos()
        {
            Console.WriteLine("Cadastrando Cursos");
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço");
            float Preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Autor");
            string Autor = Console.ReadLine();
            Curso Pf = new Curso(nome, Preco, Autor);
            produtos.Add(Pf);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();
            enconder.Serialize(stream,produtos); //"produto" é o nome da interface
            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)enconder.Deserialize(stream);
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
                catch
                {
                produtos = new List<IEstoque>();
                }
            stream.Close();
        }
            
        }
    }
    


