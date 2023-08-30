namespace ContaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {
            int option;

            while(true) 
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                Console.WriteLine("                  9 - Sair\n");
                Console.WriteLine("*******************************************************************************");
                Console.WriteLine("Entre com a opção desejada:\n");

                option = Convert.ToInt32(Console.ReadLine());   

                if (option == 9) 
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
                        
                        KeyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas\n\n");
                    
                        KeyPress();
                        break;
                    case 3:
                        Console.WriteLine("Consultar dados da Conta - Por número\n\n");
                    
                        KeyPress();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                    
                        KeyPress();
                        break;
                    case 5:
                        Console.WriteLine("Apagar Conta\n\n");
                    
                        KeyPress();
                        break;
                    case 6:
                        Console.WriteLine("Saque\n\n");

                        KeyPress();
                        break;
                    case 7:
                        Console.WriteLine("Déposito\n\n");

                        KeyPress();
                        break;
                    case 8:
                        Console.WriteLine("Tranferência entre Contas\n\n");
                    
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