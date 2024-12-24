using Data_Tier;
using Object_Tier;
using Business_Tier;

namespace Unit_Test;

[TestClass]
public class EmployeeTest
{
    [TestMethod]
    public void TestDeleteEmployee()
    {
        // Arrange
        Employee e1 = Employee.CreateEmployee("Luis","Eng",12.2);

        // Act
        Company;

        // Assert
        Assert.IsTrue(Clients.Instance.ExistClient(c1));
    }
}
