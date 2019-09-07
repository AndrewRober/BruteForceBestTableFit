using System.Collections.Generic;
using Newtonsoft.Json;

namespace BruteForceBestTableFit
{
    public class Entity
    {
        public static Entity AurelionSol = new Entity { Name = "AurelionSol" };
        public static Entity Elise = new Entity { Name = "Elise" };
        public static Entity Swain = new Entity { Name = "Swain" };
        public static Entity Morgana = new Entity { Name = "Morgana" };
        public static Entity Shyvana = new Entity { Name = "Shyvana" };
        public static Entity Evelynn = new Entity { Name = "Evelynn" };
        public static Entity Aatrox = new Entity { Name = "Aatrox" };
        public static Entity Brand = new Entity { Name = "Brand" };
        public static Entity Varus = new Entity { Name = "Varus" };
        public static Entity Pantheon = new Entity { Name = "Pantheon" };
        public static Entity Yasuo = new Entity { Name = "Yasuo" };
        public static Entity Volibear = new Entity { Name = "Volibear" };
        public static Entity Lissandra = new Entity { Name = "Lissandra" };
        public static Entity Anivia = new Entity { Name = "Anivia" };
        public static Entity Braum = new Entity { Name = "Braum" };
        public static Entity Sejuani = new Entity { Name = "Sejuani" };
        public static Entity Ashe = new Entity { Name = "Ashe" };
        public static Entity Camille = new Entity { Name = "Camille" };
        public static Entity Vi = new Entity { Name = "Vi" };
        public static Entity Jinx = new Entity { Name = "Jinx" };
        public static Entity Jayce = new Entity { Name = "Jayce" };
        public static Entity Katarina = new Entity { Name = "Katarina" };
        public static Entity Draven = new Entity { Name = "Draven" };
        public static Entity Darius = new Entity { Name = "Darius" };
        public static Entity Zed = new Entity { Name = "Zed" };
        public static Entity Akali = new Entity { Name = "Akali" };
        public static Entity Shen = new Entity { Name = "Shen" };
        public static Entity Kennen = new Entity { Name = "Kennen" };
        public static Entity Fiora = new Entity { Name = "Fiora" };
        public static Entity Leona = new Entity { Name = "Leona" };
        public static Entity Lucian = new Entity { Name = "Lucian" };
        public static Entity Garen = new Entity { Name = "Garen" };
        public static Entity Kayle = new Entity { Name = "Kayle" };
        public static Entity Vayne = new Entity { Name = "Vayne" };
        public static Entity Mordekaiser = new Entity { Name = "Mordekaiser" };
        public static Entity Kindred = new Entity { Name = "Kindred" };
        public static Entity Karthus = new Entity { Name = "Karthus" };
        public static Entity Pyke = new Entity { Name = "Pyke" };
        public static Entity Graves = new Entity { Name = "Graves" };
        public static Entity Gangplank = new Entity { Name = "Gangplank" };
        public static Entity MissFortune = new Entity { Name = "MissFortune" };
        public static Entity TwistedFate = new Entity { Name = "TwistedFate" };
        public static Entity Blitzcrank = new Entity { Name = "Blitzcrank" };
        public static Entity Khazix = new Entity { Name = "Khazix" };
        public static Entity RekSai = new Entity { Name = "RekSai" };
        public static Entity Chogath = new Entity { Name = "Chogath" };
        public static Entity Kassadin = new Entity { Name = "Kassadin" };
        public static Entity Rengar = new Entity { Name = "Rengar" };
        public static Entity Warwick = new Entity { Name = "Warwick" };
        public static Entity Nidalee = new Entity { Name = "Nidalee" };
        public static Entity Gnar = new Entity { Name = "Gnar" };
        public static Entity Ahri = new Entity { Name = "Ahri" };
        public static Entity Tristana = new Entity { Name = "Tristana" };
        public static Entity Poppy = new Entity { Name = "Poppy" };
        public static Entity Lulu = new Entity { Name = "Lulu" };
        public static Entity Veigar = new Entity { Name = "Veigar" };

        public string Name { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; } = new List<Category>();

        private Entity()
        {
            //disabled to prevent instantiation from outside
        }
    }
}