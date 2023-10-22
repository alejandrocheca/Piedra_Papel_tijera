using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido al juego de Piedra, Papel, Tijeras.");
        Console.Write("Ingresa el número de rondas para ganar: ");
        int rondasParaGanar = int.Parse(Console.ReadLine());

        int userScore = 0;
        int pcScore = 0;

        while (userScore < rondasParaGanar && pcScore < rondasParaGanar)
        {
            Console.WriteLine($"\nPuntuación actual: Tú {userScore} - PC {pcScore}");
            Console.WriteLine("Elige una opción: (piedra, papel, tijeras, salir)");

            string usuarioEleccion = Console.ReadLine().ToLower();
            if (usuarioEleccion == "salir")
            {
                Console.WriteLine("¡Gracias por jugar!");
                break;
            }

            if (usuarioEleccion != "piedra" && usuarioEleccion != "papel" && usuarioEleccion != "tijeras")
            {
                Console.WriteLine("Opción no válida. Introduce 'piedra', 'papel', 'tijeras' o 'salir'.");
                continue; // Ignora la entrada no válida y solicita otra.
            }

            string pcEleccion = GetComputerChoice();
            Console.WriteLine($"Tu elección: {usuarioEleccion}");
            Console.WriteLine($"La elección del PC: {pcEleccion}");

            int result = DetermineWinner(usuarioEleccion, pcEleccion);
            if (result == 0)
            {
                Console.WriteLine("Empate en esta ronda.");
            }
            else if (result == 1)
            {
                Console.WriteLine("¡Ganaste esta ronda!");
                userScore++;
            }
            else
            {
                Console.WriteLine("El PC gana esta ronda.");
                pcScore++;
            }
        }

        Console.WriteLine("\nPuntuación final: Tú " + userScore + " - PC " + pcScore);
        if (userScore > pcScore)
        {
            Console.WriteLine("¡Felicidades, ganaste el juego!");
        }
        else if (userScore < pcScore)
        {
            Console.WriteLine("El PC ganó el juego. ¡Suerte la próxima vez!");
        }
        else
        {
            Console.WriteLine("El juego terminó en empate.");
        }
    }

    static string GetComputerChoice()
    {
        Random random = new Random();
        int choice = random.Next(1, 4);
        switch (choice)
        {
            case 1: return "piedra";
            case 2: return "papel";
            case 3: return "tijeras";
            default: return "desconocido";
        }
    }

    static int DetermineWinner(string usuarioEleccion, string pcEleccion)
    {
        if (usuarioEleccion == pcEleccion)
        {
            return 0; // Empate
        }
        else if ((usuarioEleccion == "piedra" && pcEleccion == "tijeras") ||
                 (usuarioEleccion == "papel" && pcEleccion == "piedra") ||
                 (usuarioEleccion == "tijeras" && pcEleccion == "papel"))
        {
            return 1; // Usuario gana
        }
        else
        {
            return -1; // Computadora gana
        }
    }
}
