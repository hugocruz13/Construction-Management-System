using Data_Tier;
using Object_Tier;
using Business_Tier;

namespace Unit_Test
{
    [TestClass]
    public sealed class ClientsTest
    {
        [TestMethod]
        public void TestRegisterClient_ValidClient()
        {
            // Arrange
            Client c1 = Client.CreateClient("Test", 33232432);

            // Act
            Company.RegisterClient(c1);

            // Assert
            Assert.IsTrue(Clients.Instance.ExistClient(c1));
        }

        [TestMethod]
        public void TestGetClientById()
        {
            // Arrange
            Client client = new Client("Teste", 827234234);
            Company.RegisterClient(client);

            // Act 
            Client resultado = Company.GetClientById(client.Id);

            //Assert
            Assert.AreEqual(client, resultado);

        }

    }
}
