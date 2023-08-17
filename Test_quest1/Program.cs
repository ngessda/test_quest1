
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_quest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Генерация данных для примера
            List<Pallet> pallets = GenerateData();

            // Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.
            var sortedPallets = pallets.OrderBy(p => p.ExpiryDate)
                                      .ThenBy(p => p.GetTotalWeight());

            Console.WriteLine("Паллеты, отсортированные по сроку годности и весу:");
            foreach (var pallet in sortedPallets)
            {
                Console.WriteLine($"ID: {pallet.ID}, Срок годности: {pallet.ExpiryDate}, Вес: {pallet.GetTotalWeight()} кг");
            }

            // 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.
            var top3Pallets = pallets.OrderByDescending(p => p.GetMaxExpiryDate())
                                     .ThenBy(p => p.GetTotalVolume())
                                     .Take(3);

            Console.WriteLine("Топ 3 паллеты с наибольшим сроком годности, отсортированные по объему:");
            foreach (var pallet in top3Pallets)
            {
                Console.WriteLine($"ID: {pallet.ID}, Срок годности: {pallet.GetMaxExpiryDate()}, Объем: {pallet.GetTotalVolume()} м3");
            }
            Console.ReadKey();
        }

        static List<Pallet> GenerateData()
        {
            const int palletsCount = 3;
            List<Pallet> pallets = new List<Pallet>();
            Random Generate = new Random();

            // Создание паллет
            for (int i = 0; i < palletsCount; i++)
            {
                //Генерация случайных чисел
                int gPallets = Generate.Next(50, 150);
                int gBoxes = Generate.Next(10, 50);
                int gDateMonths = Generate.Next(1, 12);
                int gDateDays = gDateMonths == 2 ? Generate.Next(1, 28) : Generate.Next(1, 30);

                Pallet pallet = new Pallet(i + 1, gPallets, gPallets, gPallets, gPallets);
                Box box1 = new Box(i < 1 ? i + 1 : i + 2, gBoxes, gBoxes, gBoxes, new DateTime(2023, gDateMonths, gDateDays));
                Box box2 = new Box(i + 2, gBoxes, gBoxes, gBoxes, new DateTime(2023, gDateMonths, gDateDays));
                pallet.AddBox(box1);
                pallet.AddBox(box2);
                pallets.Add(pallet);
            }


            //// Создание паллеты 2
            //Pallet pallet2 = new Pallet(2, 200, 200, 200, 0);
            //Box box3 = new Box(3, gBoxes, gBoxes, gBoxes, new DateTime(2023, 1, 3));
            //Box box4 = new Box(4, gBoxes, gBoxes, gBoxes, new DateTime(2023, 1, 4));
            //pallet2.AddBox(box3);
            //pallet2.AddBox(box4);
            //pallets.Add(pallet2);

            //// Создание паллеты 3
            //Pallet pallet3 = new Pallet(3, 300, 300, 300, 0);
            //Box box5 = new Box(5, 50, 50, 50, new DateTime(2023, 1, 5));
            //Box box6 = new Box(6, 60, 60, 60, new DateTime(2023, 1, 6));
            //pallet3.AddBox(box5);
            //pallet3.AddBox(box6);
            //pallets.Add(pallet3);

            return pallets;
        }
    }


}