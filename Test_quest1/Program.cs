
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_quest1
{
    internal class Program
    {
        private const int palletsCount = 3;
        static void Main(string[] args)
        {

            // Генерация данных для примера
            List<Pallet> pallets = PalletsHelper.GenerateData();

            // Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
            var sortedPallets = PalletsHelper.SortByDateAndWeight();

            Console.WriteLine("Паллеты, отсортированные по сроку годности и весу:");
            foreach (var pallet in sortedPallets)
            {
                Console.WriteLine($"ID: {pallet.ID}, Срок годности: {pallet.ExpiryDate}, Вес: {pallet.GetTotalWeight()} кг");
            }

            // 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
            var top3Pallets = pallets.OrderByDescending(p => p.GetMaxExpiryDate())
                                     .ThenBy(p => p.GetTotalVolume())
                                     .Take(palletsCount);

            Console.WriteLine("Топ 3 паллеты с наибольшим сроком годности, отсортированные по объему:");
            foreach (var pallet in top3Pallets)
            {
                Console.WriteLine($"ID: {pallet.ID}, Срок годности: {pallet.GetMaxExpiryDate()}, Объем: {pallet.GetTotalVolume()} м3");
            }
            Console.ReadKey();
        }
    }
}