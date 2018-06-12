using System;
using System.Collections.Generic;

namespace TermUI
{
    public class Select
    {
        public Dictionary<int, string> Items { get; } = new Dictionary<int, string>();
        int StartRow = -1;
        int EndRow = -1;
        int Selection = -1;
        public ConsoleColor SelectedColor { get; set; } = ConsoleColor.DarkCyan;
        public char SelectChar { get; set; } = '>';
        public Select(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
                Items.Add(i, options[i]);
        }

        public int Read()
        {
            Console.CursorVisible = false;
            Selection = -1;
            int CurrentSelection = 0;
            StartRow = Console.CursorTop;
            EndRow = StartRow + Items.Count;
            while (Selection == -1)
            {
                for (int row = StartRow; row < EndRow; row++)
                {
                    bool isCurrentRow = (row == StartRow + CurrentSelection);
                    Console.ResetColor();
                    Console.SetCursorPosition(0, row);

                    Console.Write(isCurrentRow ? SelectChar + " " : "  ");

                    if (isCurrentRow)
                        Console.BackgroundColor = SelectedColor;

                    Console.WriteLine($"{Items[row - StartRow]}");
                }
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.DownArrow) CurrentSelection += 1;
                else if (key == ConsoleKey.UpArrow) CurrentSelection -= 1;
                else if (key == ConsoleKey.Enter) Selection = CurrentSelection;
                CurrentSelection = Math.Clamp(CurrentSelection, 0, Items.Count - 1);
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, EndRow);
            return Selection;
        }
    }
}
