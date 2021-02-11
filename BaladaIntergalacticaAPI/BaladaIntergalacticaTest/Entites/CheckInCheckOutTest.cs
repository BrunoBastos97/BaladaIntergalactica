using BaladaIntergalactica.API.Entities;
using System;
using Xunit;

namespace BaladaIntergalacticaTest.Entidades
{
    public class CheckInCheckOutTest
    {
        [Fact]
        public void Valid_Constructor()
        {
            int id = 1;
            int idAlien = 1;
            int idBallad = 1;
            int idObjectNotAllowed = 1;

            var checkInCheckOut = new CheckInCheckOut(id, idAlien, idBallad, idObjectNotAllowed);

            Assert.Equal(id, checkInCheckOut.Id);
            Assert.Equal(id, checkInCheckOut.IdAlien);
            Assert.Equal(id, checkInCheckOut.IdBallad);
            Assert.Equal(id, checkInCheckOut.IdObjectNotAllowed);
        }

        [Fact]
        public void HasProhibitedObject()
        {
            int id = 1;
            int idAlien = 1;
            int idBallad = 1;
            int? idObjectNotAllowed = 1;

            var checkInCheckOut = new CheckInCheckOut(id, idAlien, idBallad, idObjectNotAllowed);

            Assert.True(checkInCheckOut.HasObjectNotAllowed());
        }

        [Fact]
        public void MinimumCheckOutTime()
        {
            int id = 1;
            int idAlien = 1;
            int idBallad = 1;
            int idObjectNotAllowed = 1;
            var dateTimeExit = DateTime.Now.AddMinutes(-1);

            var checkInCheckOut = new CheckInCheckOut(id, idAlien, idBallad, idObjectNotAllowed);

            Assert.True(checkInCheckOut.MinimumCheckOutTime(dateTimeExit));

        }

        [Fact]
        public void CheckIn()
        {
            int id = 1;
            int idAlien = 1;
            int idBallad = 1;
            int? idObjectNotAllowed = null;
            var now = DateTime.Now;

            var checkinCheckOut = new CheckInCheckOut(id, idAlien, idBallad, idObjectNotAllowed);
            checkinCheckOut.CheckIn();

            Assert.True(checkinCheckOut.DateTimeEntry > now);
        }

        [Fact]
        public void CheckOut()
        {
            int id = 1;
            int idAlien = 1;
            int idBallad = 1;
            int? idObjectNotAllowed = null;

            var checkInCheckOut = new CheckInCheckOut(id, idAlien, idBallad, idObjectNotAllowed);
            checkInCheckOut.CheckOut();

            Assert.True(checkInCheckOut.DateTimeExit != null);
        }


    }
}
