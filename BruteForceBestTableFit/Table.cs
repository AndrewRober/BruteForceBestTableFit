using System;
using System.Collections.Generic;
using System.Linq;

namespace BruteForceBestTableFit
{
    public class Table
    {
        public List<Category> Columns { get; set; }
        public List<Category> Rows { get; set; }
        public bool IsValid { get; set; }
        public string[,] TableArray { get; set; }
        public int IntersectionCount { get; set; }
        public int TableVerticalScore { get; set; }
        public int TableHorizontalScore { get; set; }
        public CellStackStrategy CellStackStrategy { get; set; }
        public static int AllCategoriesIntersectionCount { get; set; }

        public Table(List<Category> columns, List<Category> rows, CellStackStrategy css)
        {
            this.Columns = columns;
            this.Rows = rows;
            this.CellStackStrategy = css;
            this.TableArray = this.GenerateTableArray();
            this.IsValid = this.IsValidateTable();
            this.CalculateScore();
        }

        private void CalculateScore()
        {
            this.TableHorizontalScore = this.TableArray.GetLength(0);
            this.TableVerticalScore = this.TableArray.GetLength(1);
            for (var i = 1; i <= Rows.Count; i++)
            for (var j = 1; j <= Columns.Count; j++)
                if (this.CellStackStrategy == CellStackStrategy.Vertical)
                    this.TableVerticalScore += this.TableArray[i, j].Count(c => c == '<');
                else
                    this.TableHorizontalScore += this.TableArray[i, j].Count(c => c == '<');
        }

        public void PrintTable()
        {
            Console.WriteLine($"table (Cn,Rn:In) => ({Columns.Count},{Rows.Count}:{IntersectionCount}) and Vertical score of {TableVerticalScore}, Horizontal score of {TableHorizontalScore}");
            ArrayPrinter.PrintToConsole(TableArray);
        }

        public Table Clone(CellStackStrategy css) => new Table(this.Columns, this.Rows, css);

        private string[,] GenerateTableArray()
        {
            var arr = new string[Rows.Count + 1, Columns.Count + 1];
            arr[0, 0] = string.Empty;
            for (var i = 1; i <= Rows.Count; i++)
                arr[i, 0] = Rows[i - 1].Name;
            for (var j = 1; j <= Columns.Count; j++)
                arr[0, j] = Columns[j - 1].Name;

            for (var i = 1; i <= Rows.Count; i++)
            for (var j = 1; j <= Columns.Count; j++)
            {
                var intersections = Columns[j - 1].Entities.Where(c => Rows[i - 1].Entities.Contains(c))
                    .Select(e => e.Name);
                if (intersections != null && intersections.Any())
                {
                    IntersectionCount += intersections.Count();
                    arr[i, j] = string.Join(this.CellStackStrategy == CellStackStrategy.Horizontal ? " <hs> " : " <vs> ", intersections);
                }
                else
                    arr[i, j] = string.Empty;
            }
            return arr;
        }

        private bool IsValidateTable() => Columns.Any() && Rows.Any()
                                                        && Columns.All(c => c.CategoryType == CategoryType.Column || c.CategoryType == CategoryType.Interchangeable)
                                                        && Rows.All(r => r.CategoryType == CategoryType.Row || r.CategoryType == CategoryType.Interchangeable)
                                                        && IntersectionCount >= AllCategoriesIntersectionCount;
    }
}