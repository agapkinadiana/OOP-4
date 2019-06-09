using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_15.Composite
{
    class Box : Component
    {
        private List<Component> components = new List<Component>();

        public Box(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        public override string GetName()
        {
            return name;
        }

        public override string Search(string itemName)
        {
            string result = "";

            try
            {
                for (int i = 0; i < components.Count; i++)
                {
                    foreach (Item item in (components[i] as Box).components)
                    {
                        if (item.GetName() == itemName)
                        {
                            result = "item found";
                        }
                    }
                    if (components[i].GetName() == itemName)
                    {
                        result = "item found";
                    }
                }
            }
            catch
            {

            }
            if (result == "")
            {
                result = "item not found";
            }

            return result;
        }

        public override string Print()
        {
            string message = "";
            message += name.ToUpper() + "\n";
            for (int i = 0; i < components.Count; i++)
            {
                message += "- " + components[i].Print() + "\n";
            }
            return message;
        }
    }
}
