using ContaBancaria.Controller;
using ContaBancaria.model;

namespace ContaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {
            int option, agencia, tipo, aniversario, numero, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;


            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Gaspar", 1000000M, 1000M);
            contas.Cadastrar(cc1);
            
            Poupanca cp1 = new Poupanca(contas.GerarNumero(), 123, 2, "Samantha", 1000000M, 18);
            contas.Cadastrar(cp1);

            while (true) 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("\n                            BANCO DO BRAZIL COM Z                              \n");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("\n                  1 - Criar Conta");
                Console.WriteLine("                  2 - Listar todas as Contas");
                Console.WriteLine("                  3 - Buscar Conta por Número");
                Console.WriteLine("                  4 - Atualizar dados da Conta");
                Console.WriteLine("                  5 - Apagar Conta");
                Console.WriteLine("                  6 - Sacar");
                Console.WriteLine("                  7 - Depositar");
                Console.WriteLine("                  8 - Transferir valores entre Contas");
                Console.WriteLine("                  9 - Consulta por titular");
                Console.WriteLine("                  10 - Sair\n");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("Entre com a opção desejada:\n");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());   
                } catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDeve ser digitado um valor inteito entre 1 e 9\n");
                    option = 0;
                    Console.ResetColor();
                }


                if (option == 10) 
                {
                    Console.WriteLine("\nBanco do Brasil com Z - O seu futuro está aqui!");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (option) 
                {
                    case 1:
                        Console.WriteLine("Criar Conta\n\n");
                        Console.WriteLine("Digite o Número da Agência:");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        
                        // Impedir o erro de string possivelmente nula (Dois jeitos abaixo)
                        Console.WriteLine("Digite o nome do Titular:");
                        titular = Console.ReadLine()!;
                        //titular ??= string.Empty;

                        do {
                            Console.WriteLine("Digite o tipo da Conta:");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);
                        
                        Console.WriteLine("Digite o saldo da Conta:");
                        saldo = Convert.ToDecimal(Console.ReadLine());  
                        
                        switch (tipo) 
                        {
                            case 1:
                                Console.WriteLine("Digite o limiite da Conta:");
                                limite = Convert.ToInt32(Console.ReadLine());
                                contas.Cadastrar(
                                    new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite)
                                    );
                                break;
                            case 2:
                                Console.WriteLine("Digite o Aniversário da Conta:");
                                aniversario = Convert.ToInt32(Console.ReadLine());
                                contas.Cadastrar(
                                    new Poupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario)
                                    );
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas\n\n");

                        contas.ListarTodas();
                    
                        KeyPress();
                        break;
                    case 3:
                        Console.WriteLine("Consultar dados da Conta - Por número\n\n");
                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollection(numero);

                        if (conta is not null) 
                        {
                            Console.WriteLine("Digite o Número da Agência:");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            // Impedir o erro de string possivelmente nula (Dois jeitos abaixo)
                            Console.WriteLine("Digite o nome do Titular:");
                            titular = Console.ReadLine()!;
                            //titular ??= string.Empty;

                            /*do
                            {
                                Console.WriteLine("Digite o tipo da Conta:");
                                tipo = Convert.ToInt32(Console.ReadLine());
                            } while (tipo != 1 && tipo != 2);*/

                            Console.WriteLine("Digite o saldo da Conta:");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();
                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o limiite da Conta:");
                                    limite = Convert.ToInt32(Console.ReadLine());
                                    contas.Atualizar(
                                        new ContaCorrente(numero, agencia, tipo, titular, saldo, limite)
                                        );
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o Aniversário da Conta:");
                                    aniversario = Convert.ToInt32(Console.ReadLine());
                                    contas.Atualizar(
                                        new Poupanca(numero, agencia, tipo, titular, saldo, aniversario)
                                        );
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta número {numero} não foi encontrada");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("Apagar Conta");
                        Console.WriteLine("Digite o número da conta:\n");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

                        KeyPress();
                        break;
                    case 6:
                        Console.WriteLine("Saque\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());


                        Console.WriteLine("Digite o valor do Saque:");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Sacar(numero, valor);

                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("Déposito\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());


                        Console.WriteLine("Digite o valor do Depósito:");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("Tranferência entre Contas\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta de destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor da Transferência:");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Transferir(numero, numeroDestino, valor);

                        KeyPress();
                        break;
                    case 9:
                        Console.WriteLine("Consulta por titular\n");
                        
                        Console.WriteLine("Digite o nome do titular: ");
                        titular = Console.ReadLine();
                        titular ??= string.Empty;

                        Console.WriteLine(true || false);
                        contas.ListarTodasPorTitular(titular);

                        KeyPress();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            }

            static void Sobre() 
            {
                Console.WriteLine("\n********************************************"); 
                Console.WriteLine("Projeto desenvolvido por:\n João Pedro da Maia\n https://github.com/JP328");
                Console.WriteLine("********************************************");
            }

            static void KeyPress()
            {
                do 
                {
                    Console.WriteLine("\nPressione Enter para Continuar...");
                    consoleKeyInfo = Console.ReadKey();

                } while (consoleKeyInfo.Key != ConsoleKey.Enter);
                Console.ResetColor();
                Console.Clear();
            }
        }
    }
}