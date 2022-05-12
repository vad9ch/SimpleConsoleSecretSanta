using DL;
using Entities;
using Helpers;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SecretSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ServiceProviderFactory.GetServiceProvider();

            var db = services.GetRequiredService<GiftContext>();

            while (true)
            {
                Console.WriteLine("Enter command name");
                var command = Console.ReadLine();

                if (command == "1")
                {
                    Console.WriteLine("Enter FirstName");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Enter LastName");
                    var lastName = Console.ReadLine();

                    var user = new User()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };



                    db.Add(user);
                    db.SaveChanges();

                }
                if (command == "2")
                {
                    Console.WriteLine("Showing who is presenting to who");
                    var calculator = services.GetRequiredService<IGiftCalculator>();

                    calculator.CalculateGifts();
                    ShowWhoGiftingToWho(db);
                }
                if (command == "3")
                {
                    break;
                }
            }

        }


        public static void ShowWhoGiftingToWho(GiftContext db)
        {
            var gifts = db.Gifts.Include(x => x.Users).ToList();
            foreach (var gift in gifts)
            {
                Console.WriteLine($"{gift.Users.First().FirstName} {gift.Users.First().LastName} giving present to {gift.Users.Skip(1).First().FirstName} {gift.Users.Skip(1).First().LastName}");
            }
        }
    }
}
