using System;
using System.Collections.Generic;

namespace BruteForceBestTableFit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Table
    {
        public List<Category> Columns { get; set; }
        public List<Category> Rows { get; set; }

        public int CalculatedSize { get; set; }

        public void PrintTable()
        {

        }
    }

    public class Category
    {
        public char Symbol { get; set; }
        public string Name { get; set; }
        public List<Entity> Entities { get; set; }
        public CategoryType CategoryType { get; set; }

    }

    public class Entity
    {
        public char Symbol { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
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
