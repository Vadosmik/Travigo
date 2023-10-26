public class SelectionMenu
{
    public List<string> menuOption = new List<string>() { };
    public List<string> selectionArrow = new List<string>() { "> " };

    public int Menu
    {
        get
        {
            int ArrowPosition = 0;
            for (int i = 0; i < menuOption.Count - 1; i++)
            {
                selectionArrow.Add(" ");
            }

            do
            {
                Console.WriteLine("===TRAVIGO===\n");
                for (int i = 0; i < menuOption.Count; i++)
                {
                    Console.WriteLine(selectionArrow[i] + menuOption[i]);
                }
                Console.WriteLine("\n=============");


                var button = Console.ReadKey().Key;

                if (button == ConsoleKey.DownArrow & ArrowPosition < selectionArrow.Count - 1)
                {
                    selectionArrow[ArrowPosition] = " ";
                    selectionArrow[ArrowPosition + 1] = "> ";
                    ArrowPosition++;
                }
                else if (button == ConsoleKey.UpArrow & ArrowPosition > 0)
                {
                    selectionArrow[ArrowPosition] = " ";
                    selectionArrow[ArrowPosition - 1] = "> ";
                    ArrowPosition--;
                }
                else if (button == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return ArrowPosition;
                }

                Console.Clear();

            }
            while (true);
        }
    }
}
