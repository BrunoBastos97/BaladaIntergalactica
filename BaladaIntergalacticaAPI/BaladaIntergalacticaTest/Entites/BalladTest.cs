using BaladaIntergalactica.API.Entities;
using Xunit;

namespace BaladaIntergalacticaTest.Entidades
{
    public class BalladTest
    {
        [Fact]
        public void Valid_Constructor()
        {
            int id = 1;
            string name = "Matheus";

            var ballad = new Ballad(id, name);

            Assert.Equal(ballad.Id, id);
            Assert.Equal(ballad.Name, name);
        }

    }
}
