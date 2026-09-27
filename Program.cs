using System;

namespace AgendaContatos
{
    internal class Program
    {
        static Contatos minhaAgenda = new Contatos();

        static void Main(string[] args)
        {
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("         AGENDA DE CONTATOS      ");
                Console.WriteLine("=================================");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            AdicionarContato();
                            break;
                        case 2:
                            PesquisarContato();
                            break;
                        case 3:
                            AlterarContato();
                            break;
                        case 4:
                            RemoverContato();
                            break;
                        case 5:
                            ListarContatos();
                            break;
                        case 0:
                            Console.WriteLine("Encerrando a aplicação...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, informe um número válido.");
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void AdicionarContato()
        {
            Console.WriteLine("--- ADICIONAR CONTATO ---");
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Dia Nasc (dd): ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Mês Nasc (mm): ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Ano Nasc (aaaa): ");
            int ano = int.Parse(Console.ReadLine());

            Contato novoContato = new Contato(email, nome, new Data(dia, mes, ano));

            // Cadastrar Telefones
            char resp;
            do
            {
                Console.Write("\nTipo do telefone (Residencial/Celular/Trabalho): ");
                string tipo = Console.ReadLine();
                Console.Write("Número: ");
                string numero = Console.ReadLine();
                Console.Write("É o telefone principal? (S/N): ");
                bool principal = Console.ReadLine().Trim().ToUpper() == "S";

                novoContato.AdicionarTelefone(new Telefone(tipo, numero, principal));

                Console.Write("Deseja adicionar outro telefone? (S/N): ");
                resp = Console.ReadLine().Trim().ToUpper()[0];
            } while (resp == 'S');

            if (minhaAgenda.Adicionar(novoContato))
            {
                Console.WriteLine("\nContato adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nErro: Já existe um contato cadastrado com este e-mail.");
            }
        }

        static void PesquisarContato()
        {
            Console.WriteLine("--- PESQUISAR CONTATO ---");
            Console.Write("Informe o E-mail do contato: ");
            string email = Console.ReadLine();

            Contato busca = new Contato { Email = email };
            Contato resultado = minhaAgenda.Pesquisar(busca);

            if (resultado != null)
            {
                Console.WriteLine("\nContato Encontrado:\n");
                Console.WriteLine(resultado.ToString());
            }
            else
            {
                Console.WriteLine("\nContato não encontrado.");
            }
        }

        static void AlterarContato()
        {
            Console.WriteLine("--- ALTERAR CONTATO ---");
            Console.Write("Informe o E-mail do contato que deseja alterar: ");
            string email = Console.ReadLine();

            Contato busca = new Contato { Email = email };
            Contato existente = minhaAgenda.Pesquisar(busca);

            if (existente != null)
            {
                Console.WriteLine("\nInforme os novos dados do contato:");
                Console.Write("Novo Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Dia Nasc (dd): ");
                int dia = int.Parse(Console.ReadLine());
                Console.Write("Mês Nasc (mm): ");
                int mes = int.Parse(Console.ReadLine());
                Console.Write("Ano Nasc (aaaa): ");
                int ano = int.Parse(Console.ReadLine());

                Contato atualizado = new Contato(email, nome, new Data(dia, mes, ano));

                char resp;
                do
                {
                    Console.Write("\nTipo do telefone: ");
                    string tipo = Console.ReadLine();
                    Console.Write("Número: ");
                    string numero = Console.ReadLine();
                    Console.Write("É o telefone principal? (S/N): ");
                    bool principal = Console.ReadLine().Trim().ToUpper() == "S";

                    atualizado.AdicionarTelefone(new Telefone(tipo, numero, principal));

                    Console.Write("Deseja adicionar outro telefone? (S/N): ");
                    resp = Console.ReadLine().Trim().ToUpper()[0];
                } while (resp == 'S');

                if (minhaAgenda.Alterar(atualizado))
                {
                    Console.WriteLine("\nContato alterado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("\nContato não encontrado.");
            }
        }

        static void RemoverContato()
        {
            Console.WriteLine("--- REMOVER CONTATO ---");
            Console.Write("Informe o E-mail do contato que deseja remover: ");
            string email = Console.ReadLine();

            Contato busca = new Contato { Email = email };

            if (minhaAgenda.Remover(busca))
            {
                Console.WriteLine("\nContato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nContato não encontrado.");
            }
        }

        static void ListarContatos()
        {
            Console.WriteLine("--- LISTA DE CONTATOS ---");

            if (minhaAgenda.Agenda.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            foreach (var c in minhaAgenda.Agenda)
            {
                Console.WriteLine(c.ToString());
                Console.WriteLine("---------------------------------");
            }
        }
    }
}