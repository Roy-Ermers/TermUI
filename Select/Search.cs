using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TermUI
{
    public class Search
    {
        public Dictionary<int, string> Items { get; } = new Dictionary<int, string>();
        int StartRow = -1;
        int EndRow = -1;
        int Selection = -1;
        public ConsoleColor SelectedColor { get; set; } = ConsoleColor.DarkCyan;
        public char SelectChar { get; set; } = '>';
        public string Pattern = "";
        public Search(params string[] options)
        {
            for (int i = 0; i < options.Length; i++)
                Items.Add(i, options[i]);
        }

        public int Read()
        {
            Console.CursorVisible = false;
            Selection = -1;
            int CurrentSelection = 0;
            StartRow = Console.CursorTop + 1;
            EndRow = StartRow + Items.Count;
            while (Selection == -1)
            {
                Dictionary<int, string> search = Items.Where((x) => FuzzyMatch(x.Value, Pattern)).ToDictionary(i => i.Key, i => i.Value);
                Console.ResetColor();
                Console.SetCursorPosition(0, StartRow - 1);
                Console.WriteLine(": " + Pattern + "_".PadRight(Console.BufferWidth - Pattern.Length - 2));
                if (search.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(0, StartRow);
                    Console.WriteLine("  (No results)".PadRight(Console.BufferWidth));
                    for (int row = StartRow + 1; row < EndRow; row++)
                    {
                        Console.SetCursorPosition(0, row);
                        Console.WriteLine(new string(' ', Console.BufferWidth));
                    }
                    Console.ResetColor();
                    Console.WindowTop = StartRow - 2;
                }
                else
                {
                    for (int row = StartRow; row < EndRow; row++)
                    {
                        if ((row - StartRow) >= search.Count)
                        {
                            Console.ResetColor();
                            Console.WriteLine(new string(' ', Console.BufferWidth - 2));
                            continue;
                        }
                        bool isCurrentRow = (row == StartRow + CurrentSelection);
                        Console.ResetColor();
                        Console.SetCursorPosition(0, row);

                        Console.Write(isCurrentRow ? SelectChar + " " : "  ");

                        if (isCurrentRow)
                            Console.BackgroundColor = SelectedColor;

                        Console.WriteLine($"{search.ElementAt(Math.Clamp(row - StartRow, 0, search.Count - 1)).Value}".PadRight(Console.BufferWidth - 2));
                    }
                    CurrentSelection = Math.Clamp(CurrentSelection, 0, search.Count);
                    Console.SetCursorPosition(0, StartRow - 2);
                }
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow) CurrentSelection += 1;
                else if (key.Key == ConsoleKey.UpArrow) CurrentSelection -= 1;
                else if (key.Key == ConsoleKey.Enter) Selection = CurrentSelection;
                else if (key.Key == ConsoleKey.Backspace) Pattern = Pattern.Substring(0, Math.Max(0, Pattern.Length - 1));
                else Pattern += key.KeyChar;
                Console.WindowTop = StartRow - 2;
            }
            Console.CursorVisible = true;
            
            for (int row = StartRow - 1; row < EndRow; row++)
                Console.WriteLine(new string(' ', Console.BufferWidth));
            
            Console.SetCursorPosition(0, StartRow);
            Console.WindowTop = StartRow - 2;
            return Selection;
        }

        public static bool FuzzyMatch(string stringToSearch, string pattern)
        {
            var patternIdx = 0;
            var strIdx = 0;
            var patternLength = pattern.Length;
            var strLength = stringToSearch.Length;

            while (patternIdx != patternLength && strIdx != strLength)
            {
                if (char.ToLower(pattern[patternIdx]) == char.ToLower(stringToSearch[strIdx]))
                    ++patternIdx;
                ++strIdx;
            }

            return patternLength != 0 && strLength != 0 && patternIdx == patternLength;
        }
    }

}
