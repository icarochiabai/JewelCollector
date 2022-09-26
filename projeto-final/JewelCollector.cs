namespace projeto_final;
/// <summary>
/// Classe JewelCollector. Lida com o funcionamento do jogo.
/// </summary>
public class JewelCollector
{
    /// <summary>
    /// Método principal que lida com o funcionamento do jogo.
    /// </summary>
    public static void Main()
    {
    
        bool running = true;
        Game JewelCollector = new Game(10, 10);
        
        do
        {
            if(JewelCollector.isOver()){
                JewelCollector = new Game(10, 10);
            }
            JewelCollector.display();
            Console.WriteLine("Enter the command: ");
            char command = Console.ReadKey().KeyChar;

            if (command == 'q')
            {
                running = false;
            }
            else if (command == 'w')
            {
                JewelCollector.sendCommand("w");
            }
            else if (command == 'a')
            {
                JewelCollector.sendCommand("a");

            }
            else if (command == 's')
            {
                JewelCollector.sendCommand("s");

            }
            else if (command == 'd')
            {
                JewelCollector.sendCommand("d");

            }
            else if (command == 'g')
            {
                JewelCollector.sendCommand("g");
            }
            Console.WriteLine("\n");
        } while (running);
    }
}
