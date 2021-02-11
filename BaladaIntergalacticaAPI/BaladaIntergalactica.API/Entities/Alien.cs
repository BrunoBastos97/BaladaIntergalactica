using System;

namespace BaladaIntergalactica.API.Entities
{
    public class Alien
    {
        private const int AGE_MINIMUM_ALLOWED = 250;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Boolean Banned { get; set; }

        public Alien(int id, string name, DateTime dateOfBirth, Boolean banned)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Banned = banned;

        }

        public int Age()
        {
            var ageAlien = DateTime.Now.Year - DateOfBirth.Year;
            if (DateOfBirth.DayOfYear < DateTime.Now.DayOfYear)
            {
                ageAlien--;
            }

            return ageAlien;

        }

        public bool AgeCheckMinimumAllowed()
        {
            return Age() >= AGE_MINIMUM_ALLOWED;
        }



    }
}
