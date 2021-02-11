using BaladaIntergalactica.API.Entities;
using Xunit;

namespace BaladaIntergalacticaTest.Entidades
{
    public class ObjectNotAllowedTest
    {
        [Fact]
        public void Valid_Constructor()
        {
            int id = 1;
            string name = "Cannum";

            var prohibitedObject = new ObjectNotAllowed(id, name);

            Assert.Equal(id, prohibitedObject.Id);
            Assert.Equal(name, prohibitedObject.Name);
        }
    }
}
