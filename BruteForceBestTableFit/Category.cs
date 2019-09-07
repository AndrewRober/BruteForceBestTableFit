using System.Collections.Generic;

namespace BruteForceBestTableFit
{
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
}