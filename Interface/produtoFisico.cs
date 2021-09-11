using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    [System.Serializable]
    class produtoFisico:Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public produtoFisico(string nome, float preco, float frete )
        {
            this.nome = nome;
            this.preco = preco; 
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no produto: {nome}");
            Console.WriteLine("Digite a quantidade para dar entrada");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine(); 
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar Saida no produto: {nome}");
            Console.WriteLine("Digite a quantidade para dar Saida");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"EStoque: {estoque}");
            Console.WriteLine("=====================");
        }
    }
}
