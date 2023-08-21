using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_quest1
{
    public class PalletsHelper
    {
        private const int palletsCount = 3;
        static List<Pallet> pallets = new List<Pallet>();
        public static List<Pallet> GenerateData()
        {
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
            return pallets;
        }
        public static IOrderedEnumerable<Pallet> SortByDateAndWeight()
        {
            var sortedPallets = pallets.OrderBy(p => p.ExpiryDate)
                          .ThenBy(p => p.GetTotalWeight());
            return sortedPallets;
        }
        public static List<Pallet> SortPalletsByDateAndWeight(List<Pallet> pallets)
        {
            // Сортировка паллет по дате и весу
            pallets.Sort((p1, p2) =>
            {
                int dateComparison = DateTime.Compare(p1.ExpiryDate, p2.ExpiryDate);
                if (dateComparison != 0)
                    return dateComparison;

                return p1.Weight.CompareTo(p2.Weight);
            });

            return pallets;
        }

        public static List<Pallet> SortPalletsByDateAndVolume(List<Pallet> pallets)
        {
            // Сортировка паллет по дате и весу
            pallets.Sort((p1, p2) =>
            {
                int dateComparison = DateTime.Compare(p1.ExpiryDate, p2.ExpiryDate);
                if (dateComparison != 0)
                    return dateComparison;

                return p1.Volume.CompareTo(p2.Volume);
            });

            return pallets;
        }


    }
}

