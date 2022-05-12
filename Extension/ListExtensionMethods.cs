using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class ListExtensionMethods
    {
        public static Gift Swap(this IList<User> list, int a, int b, IEnumerable<int> used)
        {

            Random rng = new Random();
            if (a == b)
            {
                return null;
            }
            if (used.Contains(b))
            {
                return null;
            }
            var gift = new Gift();
            gift.Users = new List<User>();
            gift.Users.Add(list[a]);
            gift.Users.Add(list[b]);
            return gift;
        }

        public static IList<Gift> Shuffle (this IList<User> list, Random random)
        {
            var gifts = new List<Gift>();
            var used = new List<int>();
            for (var i = 0; i < list.Count; i++)
            {
                var entityNumber = 0;
                Gift gift = null;
                while(gift == null)
                {
                    entityNumber = random.Next(0, list.Count);
                    gift = list.Swap(i, entityNumber, used);
                    
                    
                }
                gifts.Add(gift);
                used.Add(entityNumber);
            }
            Console.WriteLine("Secret santa list created");

            return gifts;
        }
    }
}