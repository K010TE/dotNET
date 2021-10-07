using System;
using System.Collections.Generic;
namespace CS_Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado e volte sempre!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o númeroda conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta a ser sacada: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = int.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i=0; i<listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"#{i} - ");
                Console.WriteLine(conta.Info());

            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para pessoa física ou 2 para jurídica: ");
            int inputTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string inputNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double inputSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double inputCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)inputTipoConta,
                                        saldo: inputSaldo,
                                        credito: inputCredito,
                                        nome: inputNome);
            
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vinde ao CS Bank");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
