using BLL.DTO;

namespace BLL.Services.Interfaces;

public interface IReportService
{
    IEnumerable<ReportDTO> GetReports(int page);

}