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
        
        mockContext.Setup(
            context => context.Set<Report>(
                )).Returns(mockDbSet.Object);
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
    
    [Fact]
    public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
    {
        // Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<ReportContext>().Options;
        var mockContext = new Mock<ReportContext>(opt);
        var mockDbSet = new Mock<DbSet<Report>>();

        mockContext
            .Setup(context =>
                context.Set<Report>(
                ))
            .Returns(mockDbSet.Object);
        Report expectedReport = new Report() { ReportId = 1 };
        
        mockDbSet.Setup(mock => mock.Find(expectedReport.ReportId))
            .Returns(expectedReport);
        var repository = new TestReportRepository(mockContext.Object);
        
        //Act
        var actualReport = repository.Get(expectedReport.ReportId);
        
        // Assert
        mockDbSet.Verify(
            dbSet => dbSet.Find(
                expectedReport.ReportId
            ), Times.Once());
        Assert.Equal(expectedReport, actualReport);
    }

    [Fact]
    public void Delete_InputId_CalledRemoveMethodOfDBSetWithCorrectId()
    {
        //Arrange
        DbContextOptions opt = new DbContextOptionsBuilder<ReportContext>().Options;
        var mockContext = new Mock<ReportContext>(opt);
        var mockDbSet = new Mock<DbSet<Report>>();
        
        mockContext
            .Setup(context =>
                context.Set<Report>(
                ))
            .Returns(mockDbSet.Object);
        
        var repository = new TestReportRepository(mockContext.Object);
        Report deletedReport = new Report() { ReportId = 1 };
        
        mockDbSet.Setup(mock => mock.Find(deletedReport.ReportId))
            .Returns(deletedReport);
        
        //Act
        repository.Delete(1);
        
        // Assert
        mockDbSet.Verify(
            dbSet => dbSet.Remove(
                deletedReport
            ), Times.Once());
        
    }
}