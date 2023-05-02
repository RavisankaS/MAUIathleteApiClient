using System;
using RSIRIWARDENAGE1_Test3.Models;
using RSIRIWARDENAGE1_Test3.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RSIRIWARDENAGE1_Test3.Data
{
    internal interface ISportRepository
    {
        Task<List<Sport>> GetSports();
        Task<Sport> GetSport(int ID);
    }
}
