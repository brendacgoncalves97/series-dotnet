using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opUser = ObterOpUser();

            while (opUser.ToUpper() != "X")
            {
                switch (opUser)
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
                        throw new ArgumentNullException();
                }
                opUser = ObterOpUser();
            }
            Console.WriteLine("Obrigada(o) por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repositorio.Lista();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var s in list)
            {
                var excluido = s.retornaExluido();
                Console.WriteLine($"#ID {s.retornId()}: {s.retornaTitulo()} - {(excluido ? "Excluido" : "")}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie newSerie = new Serie(repositorio.ProximoId(),
                                        (Genero)entradaGenero,
                                        entradaTitulo,
                                        entradaDescricao, 
                                        entradaAno);
            repositorio.Insere(newSerie);                      

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int iSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(iSerie, 
                                            (Genero)entradaGenero,
                                            entradaTitulo,
                                            entradaDescricao,
                                            entradaAno);
            
            repositorio.Atualiza(iSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int iSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(iSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indSerie);

            Console.WriteLine(serie);
        }
        private static string ObterOpUser()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string op = Console.ReadLine();
            Console.WriteLine();
            return op;
        }
    }
}
