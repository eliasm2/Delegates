using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate void MeuDelegateA();                    // Declaração - Observar o Tipo e os Parâmetros
    public delegate void MeuDelegateB(ArrayList Lista);

    public delegate int Calcula(int a, int b);

    public delegate bool ComparaValor(int a, int b);

    public delegate int CalculaDelta(int a, int b, int c);

    class Program
    {
        static void FuncTesteA()                            // Essa Função é do mesmo Tipo do Delegate, 
        {                                                   // então será possível usar um Delegate para chamá-la
            Console.WriteLine("Função: 'FuncTesteA'");
        }

        static void FuncTesteB(ArrayList Lista)          // Mesmo Tipo
        {
            Console.WriteLine("\n\nCarros: ");

            foreach (var x in Lista)
            {
                Console.WriteLine("\t{0}", x);
            }
        }

        static int Soma(int a, int b)
        {
            return a + b;
        }

        static int Subtrai(int a, int b)
        {
            return a - b;
        }

        static bool Compara(int a, int b)
        {
            if (a == b)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            MeuDelegateA MostraA = new MeuDelegateA(FuncTesteA);         // Cria a Instância (Instanciação)

            MostraA();                                                   // Chama a Instância (Invocação)
            Console.ReadKey();

            ArrayList Carros = new ArrayList();
            Carros.Add("Fiat Stilo");
            Carros.Add("Toyota Corolla");
            Carros.Add("Chevrolet Captiva");
            Carros.Add("Ford KA");
            Carros.Add("Volkswagen Gol");

            MeuDelegateB MostraB = new MeuDelegateB(FuncTesteB);

            MostraB(Carros);
            Console.ReadKey();

            Calcula Somar = new Calcula(Soma);                                  // Instancia o Delegate
            Calcula Subtrair = new Calcula(Subtrai);

            ComparaValor Comparação = new ComparaValor(Compara);

            Console.WriteLine("\n\nA Soma 2 + 3 é {0}", Somar(2, 3));             // Chama o Delegate que aponta para Soma
            Console.WriteLine("A Diferença 7 - 4 é {0}", Subtrair(7, 4));       // Idem para a função Subtrai

            if (Comparação(1234, 1234))
                Console.WriteLine("\nOs números comparados são iguais!");
            else
                Console.WriteLine("\nOs números comparados são diferentes!");

            Console.ReadKey();

            CalculaDelta Delta = new CalculaDelta((int a, int b, int c) => b * b - 4 * a * c);

            Console.WriteLine("\nCálculo do Delta via Lambda: {0} ", Delta(1, 3, -4));

            Console.ReadKey();


            // Mais exemplos de Expressões Lambda
            
            Console.Clear();
            
            int[] Números = { 25, 41, 11, 37, 9, 82, 64, 71, 12 };

            foreach (int x in Números)
                Console.Write("{0,5}", x);
            
            int QtdePares = Números.Count(n => n % 2 == 0);

            Console.WriteLine("\n\nNúmero de Pares: {0}", QtdePares);
            Console.ReadKey();

           
        }

    }
}
