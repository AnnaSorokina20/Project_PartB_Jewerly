using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Sorokina_program
{
    public class Necklace
    {
        //private List<IGemstone> stones = new List<IGemstone>();

        //public List<IGemstone> gemstones;

        private List<IGemstone> stones;

        public Necklace()
        {
            stones = new List<IGemstone>();
        }

        public void AddStone(IGemstone stone)
        {
            if (stone != null)
            {
                stones.Add(stone);
            }
        }

        public bool Contains(IGemstone stone)
        {
            return stones.Contains(stone);
        }

        public void RemoveStone(IGemstone stone)
        {
            if (stone != null && stones.Contains(stone))
            {
                stones.Remove(stone);
            }
        }

        public decimal GetTotalValue()
        {
            return stones.Sum(stone => stone.GetValue());
        }

        public double GetTotalWeight()
        {
            return stones.Sum(stone => stone.GetWeight());
        }

        public void SortByValue()
        {
            stones.Sort((x, y) => x.GetValue().CompareTo(y.GetValue()));
        }

        //public static void DeleteStone(Necklace necklace, IGemstone stone)
        //{
        //    // Метод для видалення каменю з намиста
        //    throw new NotImplementedException();
        //}

        public List<IGemstone> FindStonesByColor(string color)
        {
            return stones.Where(stone => stone.GetColor().Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<IGemstone> GetStones()
        {
            return new List<IGemstone>(stones);
        }

        public override string ToString()
        {
            string necklaceDescription = "Necklace contains the following stones:\n";
            foreach (var stone in stones)
            {
                necklaceDescription += stone.ToString() + "\n";
            }
            return necklaceDescription;
        }
    }
}
