using BaladaIntergalactica.API.Entities;
using System;
using Xunit;

namespace BaladaIntergalacticaTest.Entidades
{
    public class AlienTest
    {
        [Fact]
        public void Valid_Constructor()
        {
            int id = 1;
            string name = "Matheus";
            DateTime dataOfBirth = DateTime.Now;
            bool banned = false;

            var alien = new Alien(id, name, dataOfBirth, banned);

            Assert.Equal(alien.Id, id);
            Assert.Equal(alien.Name, name);
            Assert.Equal(alien.DateOfBirth, dataOfBirth);
            Assert.Equal(alien.Banned, banned);
        }

        [Fact]
        public void CheckAge()
        {
            int id = 1;
            string name = "Matheus";
            int age = 280;
            DateTime dateOfBirth = DateTime.Now.AddYears(-age);
            bool banned = false;

            var alien = new Alien(id, name, dateOfBirth, banned);

            Assert.Equal(alien.Age(), age);
        }

        [Theory]
        [InlineData(250)]
        [InlineData(300)]
        [InlineData(261)]
        public void CheckMinimumAgeAllowed_Validates(int age)
        {
            int id = 1;
            string name = "Matheus";
            DateTime dateOfBirth = DateTime.Now.AddYears(-age);
            bool banned = false;

            var alien = new Alien(id, name, dateOfBirth, banned);

            Assert.True(alien.AgeCheckMinimumAllowed());
        }

        [Theory]
        [InlineData(249)]
        [InlineData(100)]
        [InlineData(190)]
        public void VerifyMinimumPermittedAge_Invalid(int age)
        {
            int id = 1;
            string name = "Matheus";
            DateTime dateOfBirth = DateTime.Now.AddYears(-age);
            bool banned = false;

            var alien = new Alien(id, name, dateOfBirth, banned);

            Assert.False(alien.AgeCheckMinimumAllowed());
        }


    }
}
