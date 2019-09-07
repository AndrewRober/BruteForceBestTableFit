using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BruteForceBestTableFit
{
    class Program
    {
        static List<Category> Categories;
        static List<Table> Tables;

        static void Main(string[] args)
        {
            //it takes couple of hours on a slow machine to run, hence why i took the route of 
            //saving the result to disk first and later continue developing using the saved serialized app result/state
            #region First run
            //Categories = new List<Category>
            //{
            //    new Category("Sorcerer", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Morgana, Entity.AurelionSol, Entity.Karthus, Entity.TwistedFate, Entity.Kassadin, Entity.Ahri, Entity.Lulu, Entity.Veigar
            //    }),
            //    new Category("ShapeShifter", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Elise, Entity.Swain, Entity.Shyvana, Entity.Jayce, Entity.Nidalee, Entity.Gnar
            //    }),
            //    new Category("Ranger", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Varus, Entity.Ashe, Entity.Vayne, Entity.Kindred
            //    }),
            //    new Category("Knight", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Sejuani, Entity.Darius, Entity.Kayle, Entity.Garen, Entity.Mordekaiser, Entity.Poppy
            //    }),
            //    new Category("Gunslinger", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Jinx, Entity.Lucian, Entity.Graves, Entity.Gangplank, Entity.MissFortune, Entity.Tristana
            //    }),
            //    new Category("Guardian", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Pantheon, Entity.Braum, Entity.Leona
            //    }),
            //    new Category("Elementalist", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Brand, Entity.Anivia, Entity.Lissandra, Entity.Kennen
            //    }),
            //    new Category("Brawler", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Volibear, Entity.Vi, Entity.Blitzcrank, Entity.Chogath, Entity.RekSai, Entity.Warwick
            //    }),
            //    new Category("Blademaster", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Aatrox, Entity.Yasuo, Entity.Camille, Entity.Draven, Entity.Shen, Entity.Fiora, Entity.Gangplank
            //    }),
            //    new Category("Assassin", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Evelynn, Entity.Katarina, Entity.Zed, Entity.Akali, Entity.Pyke, Entity.Khazix, Entity.Rengar
            //    }),


            //    new Category("Demon", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Evelynn, Entity.Aatrox, Entity.Brand, Entity.Varus, Entity.Elise, Entity.Swain, Entity.Morgana
            //    }),
            //    new Category("Dragon", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Pantheon, Entity.Shyvana, Entity.AurelionSol
            //    }),
            //    new Category("Exile", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Yasuo
            //    }),
            //    new Category("Glacial", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Volibear, Entity.Lissandra, Entity.Anivia, Entity.Braum, Entity.Sejuani, Entity.Ashe
            //    }),
            //    new Category("Hextech", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Camille, Entity.Vi, Entity.Jinx, Entity.Jayce
            //    }),
            //    new Category("Imperial", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Katarina, Entity.Draven, Entity.Darius, Entity.Swain
            //    }),
            //    new Category("Ninja", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Zed, Entity.Akali, Entity.Shen, Entity.Kennen
            //    }),
            //    new Category("Noble", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Fiora, Entity.Leona, Entity.Lucian, Entity.Garen, Entity.Kayle, Entity.Vayne
            //    }),
            //    new Category("Phantom", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Mordekaiser, Entity.Kindred, Entity.Karthus
            //    }),
            //    new Category("Pirate", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Pyke, Entity.Gangplank, Entity.Graves, Entity.MissFortune, Entity.TwistedFate
            //    }),
            //    new Category("Robot", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Blitzcrank
            //    }),
            //    new Category("Void", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Khazix, Entity.RekSai, Entity.Chogath, Entity.Kassadin
            //    }),
            //    new Category("Wild", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Rengar, Entity.Warwick, Entity.Nidalee, Entity.Gnar, Entity.Ahri
            //    }),
            //    new Category("Yordle", CategoryType.Interchangeable, new List<Entity>()
            //    {
            //        Entity.Kennen, Entity.Tristana, Entity.Poppy, Entity.Gnar, Entity.Lulu, Entity.Veigar
            //    })
            //};

            //CalculateCategoriesIntersectionCount();
            //GenerateAllPossibleTablesAndSaveValidOnes(); 
            #endregion

            //maximize console
            Maximize();
            //increase the console write buffer size
            Console.BufferWidth = 1000;

            foreach (var table in JsonConvert.DeserializeObject<List<Table>>(File.ReadAllText("result.txt")))
                table.PrintTable();
        }

        static void CalculateCategoriesIntersectionCount()
        {
            foreach (var entity in Categories.SelectMany(c => c.Entities).DistinctBy(e => e.Name))
                Table.AllCategoriesIntersectionCount += (int)(Math.Ceiling(entity.Categories.Count / 2.0));
        }

        static void GenerateAllPossibleTablesAndSaveValidOnes()
        {
            var input = Categories.Select(c => c.Name).ToArray();
            var subsets = Helpers.GetSubsets(input);
            Tables = new List<Table>();
            Parallel.ForEach(subsets, subset =>
            {
                var t = new Table(subset.Select(s => Categories.Single(c => c.Name == s)).ToList(),
                    input.Where(iEl => !subset.Contains(iEl)).Select(s => Categories.Single(c => c.Name == s)).ToList(), CellStackStrategy.Horizontal);
                if (t.IsValid)
                {
                    Tables.Add(t);
                    Tables.Add(t.Clone(CellStackStrategy.Vertical));
                }
            });
            File.WriteAllText("result.txt", JsonConvert.SerializeObject(Tables, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        static void GenerateAllPossibleTables()
        {
            var input = Categories.Select(c => c.Name).ToArray();
            var subsets = Helpers.GetSubsets(input);
            Tables = new List<Table>();
            foreach (var subset in subsets)
            {
                var t = new Table(subset.Select(s => Categories.Single(c => c.Name == s)).ToList(),
                    input.Where(iEl => !subset.Contains(iEl)).Select(s => Categories.Single(c => c.Name == s)).ToList(), CellStackStrategy.Horizontal);
                if (t.IsValid)
                {
                    Tables.Add(t);
                    Tables.Add(t.Clone(CellStackStrategy.Vertical));
                }
            }

            foreach (var table in Tables)
            {
                table.PrintTable();
                Console.WriteLine();
            }
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        static void Maximize()
        {
            Process p = Process.GetCurrentProcess();
            ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
        }
    }
}
