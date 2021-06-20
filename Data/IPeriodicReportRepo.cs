using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data 
{
    public interface IPeriodicReportItemRepo
    {
        bool SaveChanges();
        IEnumerable<PeriodicReportItem> GetAllPeriodicReports();

        IEnumerable<PeriodicReportItem> GetPeriodicReportByIdStudent(string id);
        PeriodicReportItem GetPeriodicReportById(int id);
        void CreatePeriodicReport(PeriodicReportItem periodic);
        void UpdatePeriodicReport(PeriodicReportItem periodic);
        void DeletePeriodicReport(PeriodicReportItem periodic);
    }
}