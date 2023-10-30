using System;

public class ActionSelection
{
    public List<string> Action = new List<string>() { };
    public List<string> SelectionArrow = new List<string>() { ">" };

    public int GetActionSelection
    {
        get
        {
            int ArrowPosition = 0;
            for (int i = 0; i < Action.Count - 1; i++)
            {
                SelectionArrow.Add(" ");
            }

            do
            {
                Console.WriteLine("===TRAVIGO===\n");
                for (int i = 0; i < Action.Count; i++)
                {
                    Console.WriteLine(SelectionArrow[i] + Action[i]);
                }
                Console.WriteLine("\n=============");

                var PressedButton = Console.ReadKey().Key;
                if (PressedButton == ConsoleKey.DownArrow & ArrowPosition < SelectionArrow.Count - 1)
                {
                    SelectionArrow[ArrowPosition] = " ";
                    SelectionArrow[ArrowPosition + 1] = ">";
                    ArrowPosition++;
                }
                else if (PressedButton == ConsoleKey.UpArrow & ArrowPosition > 0)
                {
                    SelectionArrow[ArrowPosition] = " ";
                    SelectionArrow[ArrowPosition - 1] = ">";
                    ArrowPosition--;
                }
                else if (PressedButton == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return ArrowPosition;
                }

                Console.Clear();
            } while (true);
        }
    }
}
