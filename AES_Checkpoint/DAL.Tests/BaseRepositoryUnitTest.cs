using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests;
using Moq;
using Xunit;

public class BaseRepositoryUnitTest
{
    [Fact]
    public void Create_InputReportInstance_CalledAddMethodOfDBSetWithReportInstance()
    {
        // Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<ReportContext>().Options;
        var mockContext = new Mock<ReportContext>(opt);
        var mockDbSet = new Mock<DbSet<Report>>();
        
        mockContext.Setup(context => context.Set<Report>()).Returns(mockDbSet.Object);
        var repository = new TestReportRepository(mockContext.Object);
        
        Report expectedReport = new Mock<Report>().Object;
        
        //Act
        repository.Create(expectedReport);
        
        // Assert
        mockDbSet.Verify(
        dbSet => dbSet.Add(
            expectedReport
            ), Times.Once());
    }
}