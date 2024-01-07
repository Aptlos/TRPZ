using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace BLL.Tests;

public class ReportServiceTests
{
    [Fact]
    public void Ctor_InputNull_ThrowArgumentNullException()
    {
        // Arrange
        IUnitOfWork nullUnitOfWork = null;
        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(
            () => new ReportService(nullUnitOfWork)
        );
    }
    
    [Fact]
    public void GetReports_UserIsAdmin_ThrowMethodAccessException()
    {
        // Arrange
        User user = new Admin(1, "test", 1);
        SecurityContext.SetUser(user);
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        IReportService reportService = new ReportService(mockUnitOfWork.Object);
        // Act
        // Assert
        Assert.Throws<MethodAccessException>(() => reportService.GetReports(0));
    }

    [Fact]
    public void GetReports_ReportFromDAL_CorrectMappingToReportDTO()
    {
        // Arrange
        User user = new Director(1, "test", 1);
        SecurityContext.SetUser(user);
        var reportService = GetReportService();
        // Act
        var actualReportDto = reportService.GetReports(0).First();
        // Assert
        Assert.True(
            actualReportDto.ReportId == 1
            && actualReportDto.Creator == 2
            && actualReportDto.Intruder == 1
            && actualReportDto.Reason == 3
        );
    }

    IReportService GetReportService()
    {
        var mockContext = new Mock<IUnitOfWork>();
        var expectedReport = new Report() { 
            ReportId = 1, 
            Creator = 2,
            Intruder = 1, 
            Reason = 3
        };
        var mockDbSet = new Mock<IReportRepository>();
        mockDbSet
            .Setup(z => 
                z.Find(
                    It.IsAny<Func<Report,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
            .Returns(
                new List<Report>() { expectedReport }
            );
        mockContext
            .Setup(context =>
                context.Reports)
            .Returns(mockDbSet.Object);
        IReportService streetService = new ReportService(mockContext.Object);
        return streetService;
    }
}

