using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_quest1
{
    public class Pallet
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public double Weight { get; set; }
        public DateTime ExpiryDate { get; set; }
        private List<Box> boxes = new List<Box>();

        public Pallet(int id, int width, int height, int depth, int weight)
        {
            ID = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }

        public void AddBox(Box box)
        {
            boxes.Add(box);

            // Обновление срока годности и веса паллеты при добавлении новой коробки
            UpdateExpiryDate();
            UpdateWeight();
        }

        public double GetTotalWeight()
        {
            // Вес паллеты равен сумме весов всех коробок + 30кг
            return boxes.Sum(b => b.Weight) + 30;
        }

        public double GetTotalVolume()
        {
            // Объем паллеты равен сумме объемов всех коробок + произведение ширины, высоты и глубины паллеты
            return boxes.Sum(b => b.GetVolume() + (Width * Height * Depth)) / 1000000;
        }
        public DateTime GetMaxExpiryDate()
        {
            // Нахождение максимального срока годности среди всех коробок на паллете
            return boxes.Max(b => b.ExpiryDate);
        }

        private void UpdateExpiryDate()
        {
            // Обновление срока годности паллеты при добавлении новой коробки
            ExpiryDate = boxes.Min(b => b.ExpiryDate);
        }

        private void UpdateWeight()
        {
            // Обновление веса паллеты при добавлении новой коробки
            Weight = GetTotalWeight();
        }
    }
}
