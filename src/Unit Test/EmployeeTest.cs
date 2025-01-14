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
        Company.RegistEmployee(e1);

        // Assert
        Assert.IsTrue(Employees.Instance.EmployeeExist(e1));
    }
}
