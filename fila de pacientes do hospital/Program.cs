using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fila_de_pacientes_do_hospital
{
    class Program
    {
        static string[] fila = new string[10]; // Fila de pacientes
        static int contador = 0; // Contador de pacientes na fila

        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Sistema de Controle de Fila de Pacientes!\n**Feito por Geovanna e João Vitor**");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Cadastrar paciente");
                Console.WriteLine("2. Inserir paciente na fila");
                Console.WriteLine("3. Listar fila de pacientes");
                Console.WriteLine("4. Incluir paciente prioritário");
                Console.WriteLine("5. Atender próximo paciente");
                Console.WriteLine("Para sair, digite 'q'.");

                char opcao = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (opcao)
                {
                    case '1':
                        CadastrarPaciente();
                        break;
                    case '2':
                        InserirNaFila();
                        break;
                    case '3':
                        ListarFila();
                        break;
                    case '4':
                        IncluirPrioritario();
                        break;
                    case '5':
                        AtenderPaciente();
                        break;
                    case 'q':
                    case 'Q':
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarPaciente()
        {
            if (contador < fila.Length)
            {
                Console.Write("Digite o nome do paciente: ");
                string nome = Console.ReadLine();
                fila[contador] = nome;
                contador++;
                Console.WriteLine($"Paciente '{nome}' cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("A fila está cheia! Não é possível cadastrar mais pacientes.");
            }
        }

        static void InserirNaFila()
        {
            if (contador < fila.Length)
            {
                Console.Write("Digite o nome do paciente a ser inserido na fila: ");
                string nome = Console.ReadLine();
                fila[contador] = nome;
                contador++;
                Console.WriteLine($"Paciente '{nome}' inserido na fila com sucesso!");
            }
            else
            {
                Console.WriteLine("A fila está cheia! Não é possível adicionar mais pacientes.");
            }
        }

        static void ListarFila()
        {
            if (contador == 0)
            {
                Console.WriteLine("A fila está vazia.");
            }
            else
            {
                Console.WriteLine("Fila de pacientes:");
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"{i + 1}. {fila[i]}");
                }
            }
        }

        static void IncluirPrioritario()
        {
            if (contador < fila.Length)
            {
                Console.Write("Digite o nome do paciente prioritário: ");
                string nome = Console.ReadLine();
                for (int i = contador; i > 0; i--)
                {
                    fila[i] = fila[i - 1];
                }
                fila[0] = nome;
                contador++;
                Console.WriteLine($"Paciente prioritário '{nome}' incluído na fila com sucesso!");
            }
            else
            {
                Console.WriteLine("A fila está cheia! Não é possível adicionar mais pacientes.");
            }
        }

        static void AtenderPaciente()
        {
            if (contador > 0)
            {
                string pacienteAtendido = fila[0];
                for (int i = 0; i < contador - 1; i++)
                {
                    fila[i] = fila[i + 1];
                }
                contador--;
                Console.WriteLine($"Paciente '{pacienteAtendido}' atendido e removido da fila.");
            }
            else
            {
                Console.WriteLine("Não há pacientes na fila para atender.");
            }
        }
    }
}