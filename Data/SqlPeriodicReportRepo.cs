using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlPeriodicReportItemRepo : IPeriodicReportItemRepo
    {
        private readonly CommanderContext _context;

        public SqlPeriodicReportItemRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreatePeriodicReport(PeriodicReportItem periodic)
        {
            if (periodic == null)
            {
                throw new ArgumentNullException(nameof(periodic));
            }
            _context.PeriodicReportItem.Add(periodic);
        }

        public void DeletePeriodicReport(PeriodicReportItem periodic)
        {
            if (periodic == null)
            {
                throw new ArgumentNullException(nameof(periodic));
            }
            _context.PeriodicReportItem.Remove(periodic);
        }

        public IEnumerable<PeriodicReportItem> GetAllPeriodicReports()
        {
            return _context.PeriodicReportItem.ToList();
        }

        public PeriodicReportItem GetPeriodicReportById(int id)
        {
            return _context.PeriodicReportItem.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PeriodicReportItem> GetPeriodicReportByIdStudent(string id)
        {
            List<PeriodicReportItem> periodics = _context.PeriodicReportItem.ToList();
            List<PeriodicReportItem> periodicsResult = new List<PeriodicReportItem>();
            foreach (PeriodicReportItem periodic in periodics)
            {
                string idStudent = periodic.IdStudent.ToLower().Trim();
                if (idStudent.CompareTo(id.ToLower()) == 0)
                {
                    periodicsResult.Add(periodic);
                }
            }

            return periodicsResult;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePeriodicReport(PeriodicReportItem periodic)
        {
            //Nothing
        }
    }
}