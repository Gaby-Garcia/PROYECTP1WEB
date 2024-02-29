using PROYECTP1W.Core.Services;
using PROYECTP1W.Core.Entities;


namespace PROYECTP1W.Test;


public class UnitTest1
{
    //Verificar si la meta se actualiza correctamente despues de establecerla
    [Fact]
    public void GoalsAndLimits_WhenMetaIsSet_ShouldUpdateUserMeta()
    {
        // Arrange
        var expected = 1000;
        var user1 = new Users { nombre = "Javier", meta = 1000};
        var empService = new EMPService();

        // Act
        Users user = empService.setMeta(user1.meta);

        // Assert
        Assert.Equal(expected, user.meta);
    }

    //Verifica que el presupuesto se actualiza despues de establecerla
    [Fact]
    public void GoalsAndLimits_WhenPresupuestoIsSet_ShouldUpdateUserPresupuesto()
    {
        // Arrange
        var expected = 1000;
        var user1 = new Users { nombre = "Gaby", presupuesto = 1000};
        var empService = new EMPService();

        // Act
        Users user = empService.setPresupuesto(user1.presupuesto);

        // Assert
        Assert.Equal(expected, user.presupuesto);
    }


    //Verifica el calculo del faltante para lograr la meta
    [Fact]
    public void GoalsAndLimits_CalculateGoal()
    {
        // Arrange
        var user = new Users { nombre = "Gaby", meta = 5500};
        var saldo = 500;
        var empService = new EMPService();
        var expectedCount = 5000;

        // Act
        decimal faltante = empService.calcularFaltanteMeta(user, saldo);

        // Assert
        Assert.Equal(expectedCount, faltante);
    }


    //Verifica el calculo del restante para llegar al presupuesto
    [Fact]
    public void GoalsAndLimits_CalculateBudget()
    {
        // Arrange
        var user = new Users { nombre = "Gaby", presupuesto = 15000};
        var gastos = 9000;
        var empService = new EMPService();
        var expectedCount = 6000;

        // Act
        decimal restante = empService.calcularRestantePresupuesto(user, gastos);

        // Assert
        Assert.Equal(expectedCount, restante);
    }


    //Verificar que no deje retirar mas dinero del que tiene
    [Fact]
    public void IncomeSf_UserHasNoMoney()
    {
        // Arrange
        var saldo = 5000;
        var monto = 7000;
        var sfService = new SfService();
        var expected = false;

        // Act
        bool flag = sfService.HaveMoney(monto, saldo);

        // Assert
        Assert.Equal(expected, flag);
    }
}
