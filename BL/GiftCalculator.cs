using DL;
using Extension;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class GiftCalculator : IGiftCalculator
    {
        private readonly GiftContext _db;
        public GiftCalculator(GiftContext db)
        {
            _db = db;
        }

        public void CalculateGifts()
        {
            var users = _db.Users.ToList();

            Random rng = new Random();
            var result = ListExtensionMethods.Shuffle(users , rng);
            _db.Gifts.RemoveRange(_db.Gifts.ToList());
            _db.Gifts.AddRange(result);
            _db.SaveChanges();
        }
    }
}
