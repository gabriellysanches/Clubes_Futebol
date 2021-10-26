using System;
using System.Collections.Generic;
using System.Threading;

namespace Clubes_Futebol
{
    class Program
    {
        static List<Clube> clubesCadastrados = new List<Clube>();
        static void Main(string[] args)
        {

            List<Jogo> jogos = new List<Jogo>();
            
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar Clube:");
                Console.WriteLine("2 - Cadastrar Jogo:");
                Console.WriteLine("3 - Listar jogos cadastrados:");
                Console.WriteLine("0 - Sair do Programa:");

                try{
                    int opcao = Convert.ToInt16("0"+ Console.ReadLine());

                    switch(opcao) {
                        case 1:
                            clubesCadastrados.Add(cadastrarClube());
                            break;
                        case 2:
                            jogos.Add(cadastrarJogo());
                            break;
                        case 3:
                            listarJogos(jogos);
                            break;
                        case 0:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opçao Inválida!");
                            Thread.Sleep(5000); // 5 segundos
                            break;

                    }
                    
                }
                catch (Exception erro){ 
                    Console.Clear();
                    Console.WriteLine(erro.Message);
                    Thread.Sleep(5000); // 5 segundos 
                    continue ;}
            }

            
        }

        private static void listarJogos(List<Jogo> jogos)
        {
            Console.Clear();
            if (jogos.Count == 0)
                Console.WriteLine("Nenhum jogo cadastrado!");
            else{
                foreach(var jogo in jogos)
                {
                Console.WriteLine($"{jogo.Time1.Nome} ({jogo.ResultadoTime1}) vs ({jogo.ResultadoTime2}) {jogo.Time2.Nome}");

                }
            }

                Thread.Sleep(5000); // 5 segundos
        }

        private static Jogo cadastrarJogo()
        {
            var jogo = new Jogo();
            Console.Clear();
            Console.WriteLine("Para cadastrar o 1º time do jogo, selecione um time abaixo:");
            if(!mostrarClubes()) throw new Exception("Não existe clubes cadastrados!");
            int idClube1 = Convert.ToInt16("0"+ Console.ReadLine());
            jogo.Time1 = clubesCadastrados.Find(c => c.Id == idClube1);
            if(jogo.Time1 == null) throw new Exception ("Id do Clube digitado não existe");

            Console.Clear();
            Console.WriteLine("Para cadastrar o 2º time do jogo, selecione um time abaixo:");
            if(!mostrarClubes()) throw new Exception("Não existe clubes cadastrados!");
            int idClube2 = Convert.ToInt16("0"+ Console.ReadLine());
            jogo.Time2 = clubesCadastrados.Find(c => c.Id == idClube2);
            if(jogo.Time2 == null) throw new Exception ("Id do Clube digitado não existe");

            Console.WriteLine($"Digite o resultado do {jogo.Time1.Nome}:");
            jogo.ResultadoTime1 = Convert.ToInt16("0"+ Console.ReadLine());

            Console.WriteLine($"Digite o resultado do {jogo.Time2.Nome}:");
            jogo.ResultadoTime2 = Convert.ToInt16("0"+ Console.ReadLine());

            
            Console.Clear();
            Console.WriteLine($"Jogo foi cadastrado com sucesso !");
            Thread.Sleep(1000); // 1 segundo
            return jogo;

        }

        private static bool mostrarClubes()
        {
            
            
            if (clubesCadastrados.Count == 0) {
                Console.WriteLine("Nenhum clube cadastrado!");
                return false;
            }
            else{
                foreach(var clube in clubesCadastrados)
                {
                Console.WriteLine($"{clube.Id} = {clube.Nome}");
            

                }
            }
                return true;

        }

        private static Clube cadastrarClube()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do Clube:");
            var Clube = new Clube();
            Clube.Id = clubesCadastrados.Count + 1;
            Clube.Nome = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Clube {Clube.Nome} foi cadastrado com sucesso !");
            Thread.Sleep(1000); // 1 segundo
            return Clube;
        }
    }
}
