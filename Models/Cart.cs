using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Project proj, int qty)
        {
            //building new cartline
            CartLine line = Lines
                .Where(p => p.Project.ProjectId == proj.ProjectId)
                .FirstOrDefault();

            //adding new cartline if there's nothing in it
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            //otherwise updating quantity
            else
            {
                line.Quantity += qty;
            }
                
        }

        public void RemoveLine(Project proj) =>
            Lines.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() => Lines.Sum(e => 25 * e.Quantity); //price is hard-coded
        
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }

    }
}
