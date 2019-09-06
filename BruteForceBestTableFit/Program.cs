using System;
using System.Collections.Generic;
using System.Linq;

namespace BruteForceBestTableFit
{
    class Program
    {
        static List<Category> Categories;
        static List<Table> Tables;

        static void Main(string[] args)
        {
            Categories = new List<Category>
            {
                new Category("Sorcerer", CategoryType.Interchangeable, new List<Entity>()
                {
                    Entity.Morgana, Entity.AurelionSol
                }),
                new Category("Shapeshifter", CategoryType.Interchangeable, new List<Entity>()
                {
                    Entity.Elise, Entity.Swain, Entity.Shyvana
                }),
                new Category("Demon", CategoryType.Interchangeable, new List<Entity>()
                {
                    Entity.Elise, Entity.Swain, Entity.Morgana
                }),
                new Category("Dragon", CategoryType.Interchangeable, new List<Entity>()
                {
                    Entity.AurelionSol, Entity.Shyvana
                })
            };
            CalculateCategoriesIntersectionCount();
            GenerateAllPossibleTables();
        }

        static void CalculateCategoriesIntersectionCount()
        {
            foreach (var entity in Categories.SelectMany(c => c.Entities).DistinctBy(e => e.Name))
                Table.AllCategoriesIntersectionCount += (int)(Math.Ceiling(entity.Categories.Count / 2.0));
        }

        static void GenerateAllPossibleTables()
        {
            var input = Categories.Select(c => c.Name).ToArray();
            var subsets = Helpers.GetSubsets(input);
            Tables = new List<Table>();
            foreach (var subset in subsets)
            {
                var t = new Table(subset.Select(s => Categories.Single(c => c.Name == s)).ToList(),
                    input.Where(iEl => !subset.Contains(iEl)).Select(s => Categories.Single(c => c.Name == s)).ToList());
                if (t.IsValid)
                    Tables.Add(t);
            }

            foreach (var table in Tables)
            {
                table.PrintTable();
                Console.WriteLine();
            }
        }
    }

    public class Table
    {
        public List<Category> Columns { get; set; }
        public List<Category> Rows { get; set; }
        public bool IsValid { get; set; }
        public string[,] TableArray { get; set; }
        public int IntersectionCount { get; set; }
        public int TableVerticalScore { get; set; }
        public int TableHorizontalScore { get; set; }
        public static int AllCategoriesIntersectionCount { get; set; }

        public Table(List<Category> columns, List<Category> rows)
        {
            this.Columns = columns;
            this.Rows = rows;
            this.TableArray = this.GenerateTableArray();
            this.IsValid = this.IsValidateTable();
        }

        public void PrintTable()
        {
            Console.WriteLine($"table (Cn,Rn:In) => ({Columns.Count},{Rows.Count}:{IntersectionCount}) and Vertical score of {TableVerticalScore}, Horizontal score of {TableHorizontalScore}, entities used {AllCategoriesIntersectionCount}");
            ArrayPrinter.PrintToConsole(TableArray);
        }

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
                        arr[i, j] = string.Join(", ", intersections);
                    }
                    else
                        arr[i, j] = string.Empty;
                }
            return arr;
        }

        private bool IsValidateTable()
        {
            return Columns.Any() && Rows.Any()
                                 && Columns.All(c => c.CategoryType == CategoryType.Column || c.CategoryType == CategoryType.Interchangeable)
                                 && Rows.All(r => r.CategoryType == CategoryType.Row || r.CategoryType == CategoryType.Interchangeable)
                                 && IntersectionCount >= AllCategoriesIntersectionCount;
        }
    }

    public class Category
    {
        public string Name { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public CategoryType CategoryType { get; set; }

        public Category(string name, CategoryType type, List<Entity> entities)
        {
            this.Name = name;
            this.Entities = entities;
            this.CategoryType = type;
            foreach (var entity in entities)
                if (!entity.Categories.Contains(this))
                    entity.Categories.Add(this);
        }

    }

    public class Entity
    {
        public static Entity Elise = new Entity { Name = "Elise" };
        public static Entity Swain = new Entity { Name = "Swain" };
        public static Entity Morgana = new Entity { Name = "Morgana" };
        public static Entity Shyvana = new Entity { Name = "Shyvana" };
        public static Entity AurelionSol = new Entity { Name = "AurelionSol" };

        public string Name { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();

        private Entity()
        {

        }
    }

    public enum CategoryType
    {
        Row,
        Column,
        Interchangeable
    }

    public enum CellStackStrategy
    {
        Vertical,
        Horizontal
    }
}
