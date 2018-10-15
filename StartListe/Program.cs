
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace StartListe
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new RegistrationModel();

            using (var file = new StreamReader("startlist.csv"))
            {
                var line = file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    model.HandleLine(line);
                }

            }

            Console.WriteLine("Alle klubbene: ");
            for (var index = 0; index < model.Clubs.Count; index++)
            {
                var number = index + 1;
                var club = model.Clubs[index];
                Console.WriteLine(number + ": " + club.Name);
            }

            Console.WriteLine("Skriv inn klubb nummber. ");
            var clubNoStr = Console.ReadLine();
            int clubNo = Convert.ToInt32(clubNoStr);
            var clubIndex = clubNo - 1;
            var selectedClub = model.Clubs[clubIndex];

            Console.WriteLine("Viser alle påmeldinger i denne klubben:");
            foreach (var registration in selectedClub.Registrations)
            {
                Console.WriteLine(registration.ToNiceString());
            }

        }
    }
}
