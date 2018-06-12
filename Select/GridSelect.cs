using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TermUI
{
    public class GridSelect
    {
        public List<List<string>> Grid { get; }
        public string[] ColumnNames { get; set; }
        public int SelectedX
        {
            get
            {
                return SelectedItem % Columns;
            }
        }

        public int SelectedY
        {
            get
            {
                return SelectedItem / Columns;
            }
        }

        private int[] ColumnSizes;
        private int SelectedItem = -1;

        private int Columns = -1;


        public GridSelect(int columns, params string[] data)
        {
            Columns = columns;
            ColumnSizes = new int[Columns];
            ColumnNames = new string[Columns];
            Grid = new List<List<string>>();
            for (int column = 0; column < ColumnSizes.Length; column++)
                ColumnSizes[column] = -1;

            for (int i = 0; i < data.Length; i++)
            {
                if (i % Columns == 0)
                    Grid.Add(new List<string>());

                string cell = data[i];

                if (cell.Length > ColumnSizes[i % Columns])
                    ColumnSizes[i % Columns] = cell.Length + 1;

                Grid.Last().Add(cell);
            }
        }
        public int Read()
        {
            if (!string.IsNullOrEmpty(ColumnNames[0]))
            {
                string Header = "";
                for (int ordinal = 0; ordinal < ColumnNames.Length; ordinal++)
                {
                    if (ColumnNames[ordinal].Length > ColumnSizes[ordinal])
                        ColumnSizes[ordinal] = ColumnNames[ordinal].Length + 1;
                    Header += "│ " + ColumnNames[ordinal].PadRight(ColumnSizes[ordinal]);
                }                
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(Header += " │");
                Console.ResetColor();
            }
            for (int y = 0; y < Grid.Count; y++)
            {
                string row = "";
                for (int x = 0; x < ColumnSizes.Length; x++)
                    row += "│ " + Grid[y][x].PadRight(ColumnSizes[x]);
                Console.WriteLine(row += " │");
            }

            return -1;
        }
    }
}
