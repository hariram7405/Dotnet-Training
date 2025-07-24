using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Phase2IssueTracker.Models
{
    public interface IReportable
    {
        void ReportStatus();
        void GetSummary();
    }
}
