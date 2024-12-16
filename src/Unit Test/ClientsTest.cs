using Data_Tier;
using Object_Tier;
using Business_Tier;
using CustomExceptions;

namespace Unit_Test
{
    [TestClass]
    public sealed class ClientsTest
    {
        [TestMethod]
        public void TestRegisterClient_ValidClient()
        {
            // Arrange
            Client c1 = Client.CreateClient("Hugo Cruz", 967333980);

            // Act
           Company.RegisterClient(c1);

            // Assert
            Assert.IsTrue(Clients.Instance.ExistClient(c1)); 
        }

        [TestMethod]
        public void TestRegisterClient_NullClient_ShouldThrowException()
        {
            // Arrange
            Client c1 = null;

            // Act & Assert
            var exception = Assert.ThrowsException<ConfigurationErrorException>(() => Company.RegisterClient(c1));

            // Verifique se a mensagem de exceção é a esperada
            Assert.AreEqual("Client cannot be null", exception.Message);
        }

    }
}
