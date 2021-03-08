using System;
using CadastroSerie.Repositorio;
using CadastroSerie.Enumeradores;
using CadastroSerie.Classes;

namespace CadastroSerie
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            
            var opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() !="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries(bool esperar = true)
        {
            Console.Clear();

            Console.WriteLine("Listar series cadastradas");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma série foi encontrada.");
            }

            foreach(var serie in lista)
            {
                Console.WriteLine();
                Console.WriteLine("#ID {0}: {1} {2}",serie.retornaId(),serie.retornaTitulo(),(serie.retornaAtivo() ? "Ativo":"Inativo") );
            }

            if (esperar == true)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
                Console.ReadLine(); 
            }

        }
        private static void InserirSerie()
        {
            Console.Clear();

            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine();
            Console.Write("Digite o genêro entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite o ano de inicio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            int proximoId = repositorio.ProximoId();

            var novaSerie = new Serie(id:proximoId,
                                      genero:(Genero)entradaGenero,
                                      titulo:entradaTitulo,
                                      descricao:entradaDescricao,
                                      ano:entradaAno);

            repositorio.Insere(novaSerie);

            Console.WriteLine();
            Console.WriteLine("A série foi inserida com sucesso.");

            Console.WriteLine();
            Console.WriteLine(novaSerie);

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine(); 

        }
        private static void AtualizarSerie()
        {
            ListarSeries(false);

            Console.WriteLine();
            Console.WriteLine("Atualizar série");

            Console.WriteLine();
            Console.Write("Informe o #ID da Série a ser atualizada:");            
            var entradaID = int.Parse(Console.ReadLine());

            if ((entradaID < 0) | (entradaID >= repositorio.ProximoId()))
            {
                Console.WriteLine();
                Console.WriteLine("Informe um #ID de Série válido");

                Console.WriteLine();
                Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
                Console.ReadLine(); 
                return;                
            }                

            Serie serie = repositorio.RetornaPorId(entradaID);

            Console.WriteLine();
            Console.WriteLine(serie);

            Console.WriteLine();
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine();
            Console.Write("Digite o genêro entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Digite o ano de inicio da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            serie = new Serie(entradaID,
                              genero:(Genero)entradaGenero,
                              titulo:entradaTitulo,
                              descricao:entradaDescricao,
                              ano:entradaAno);

            repositorio.Atualiza(entradaID,serie);

            Console.WriteLine();
            Console.WriteLine(serie);

            Console.WriteLine();
            Console.WriteLine("A série foi atualizada com sucesso.");

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine(); 
        }
        private static void ExcluirSerie()
        {
            ListarSeries(false);

            Console.WriteLine();
            Console.WriteLine("Excluir série");

            Console.WriteLine();
            Console.Write("Informe o #ID da Série a ser inativada:");

            var entradaID = int.Parse(Console.ReadLine());
            if ((entradaID < 0) | (entradaID >= repositorio.ProximoId()))
            {
                Console.WriteLine();
                Console.WriteLine("Informe um #ID de Série válido");

                Console.WriteLine();
                Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
                Console.ReadLine(); 
                return;                
            }                

            Console.WriteLine();
            Serie serie = repositorio.RetornaPorId(entradaID);
            Console.WriteLine(serie);

            if (serie.retornaAtivo() == false)
            {
                Console.WriteLine();
                Console.WriteLine("A série escolhida está inativada.");
            }
            else{
                repositorio.Exclui(entradaID);
                Console.WriteLine("A série foi inativada com sucesso.");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine(); 

        }
        private static void VisualizarSerie()
        {
            ListarSeries(false);

            Console.WriteLine();
            Console.WriteLine("Visualizar série");

            Console.WriteLine();
            Console.Write("Informe o #ID da Série a ser visualizada:");

            var entradaID = int.Parse(Console.ReadLine());
            if ((entradaID < 0) | (entradaID >= repositorio.ProximoId()))
            {
                Console.WriteLine();
                Console.WriteLine("Informe um #ID de Série válido");

                Console.WriteLine();
                Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
                Console.ReadLine(); 
                return;                
            }                

            Console.WriteLine();
            Serie serie = repositorio.RetornaPorId(entradaID);
            Console.WriteLine(serie);

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para voltar ao menu.");
            Console.ReadLine(); 
        }

        private static string ObterOpcaoUsuario()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Video Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1-Listar séries");
            Console.WriteLine("2-Inserir nova série");
            Console.WriteLine("3-Atualizar série");
            Console.WriteLine("4-Excluir série");
            Console.WriteLine("5-Visualizar série");
            Console.WriteLine("C-Limpar Tela");
            Console.WriteLine("X-Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine(); 
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
