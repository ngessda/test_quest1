using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_quest1
{
    public class Box
    {
        public int ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Box(int id, int width, int height, int depth, DateTime productionDate)
        {
            ID = id;
            Width = width;
            Height = height;
            Depth = depth;
            ProductionDate = productionDate;
            ExpiryDate = productionDate.AddDays(100);
            Weight = (Width * Height * Depth) / 1000000 * 0.35;
        }

        public double GetVolume()
        {
            // Объем коробки равен произведению ширины, высоты и глубины
            return Width * Height * Depth;
        }

    }
}
