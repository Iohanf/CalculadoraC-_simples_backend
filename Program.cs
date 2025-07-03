using System;

namespace Calculadora_App
{
    public class Program
    {
        public static void Main()
        {
            string continuar = "";

            do
            {
                Console.Clear(); // Limpa a tela no início de cada ciclo

                // ==== Menu de Boas-Vindas ====
                Console.WriteLine("==========================================");
                Console.WriteLine("     🧮 CALCULADORA - Iohan Barbiere      ");
                Console.WriteLine("==========================================\n");

                // ==== Entrada de Dados ====
                Console.WriteLine("Escolha uma operação:");
                Console.WriteLine(" 1 - Soma");
                Console.WriteLine(" 2 - Subtração");
                Console.WriteLine(" 3 - Multiplicação");
                Console.WriteLine(" 4 - Divisão");
                Console.Write("Opção: ");

                bool opcaoValida = int.TryParse(Console.ReadLine(), out int opcao);

                if (!opcaoValida || opcao < 1 || opcao > 4)
                {
                    Console.WriteLine("\n⚠️ Opção inválida. Tente novamente.");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    continue; // reinicia o loop para tentar novamente
                }

                Console.Write("\nDigite o 1º número: ");
                bool num1Valido = double.TryParse(Console.ReadLine(), out double number1);

                Console.Write("Digite o 2º número: ");
                bool num2Valido = double.TryParse(Console.ReadLine(), out double number2);

                if (!num1Valido || !num2Valido)
                {
                    Console.WriteLine("\n⚠️ Entrada inválida! Digite números válidos.");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    continue; // reinicia o loop
                }

                // ==== Lógica de Cálculo ====
                double resultado = 0;
                bool calculoValido = true;

                switch (opcao)
                {
                    case 1:
                        resultado = Somar(number1, number2);
                        break;
                    case 2:
                        resultado = Subtrair(number1, number2);
                        break;
                    case 3:
                        resultado = Multiplicar(number1, number2);
                        break;
                    case 4:
                        if (number2 == 0)
                        {
                            Console.WriteLine("\n⚠️ Erro: Não é possível dividir por zero!");
                            calculoValido = false;
                        }
                        else
                        {
                            resultado = Dividir(number1, number2);
                        }
                        break;
                }

                // ==== Exibição do Resultado ====
                if (calculoValido)
                {
                    string operacao = opcao switch
                    {
                        1 => "+",
                        2 => "-",
                        3 => "*",
                        4 => "/",
                        _ => "?"
                    };

                    Console.WriteLine($"\nResultado: {number1} {operacao} {number2} = {resultado:F2}");
                }

                Console.Write("\nDeseja fazer outra operação? (s/n): ");
                continuar = Console.ReadLine() ?? "n";

            } while (string.Equals(continuar, "s", StringComparison.OrdinalIgnoreCase));

            // Assinatura final
            Console.WriteLine("\nObrigado por usar a calculadora!");
            Console.WriteLine("Criado por Iohan Barbiere 🚀");
        }

        // ==== Métodos ====
        static double Somar(double a, double b) => a + b;
        static double Subtrair(double a, double b) => a - b;
        static double Multiplicar(double a, double b) => a * b;
        static double Dividir(double a, double b) => a / b;
    }
}
