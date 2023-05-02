using RSIRIWARDENAGE1_Test3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSIRIWARDENAGE1_Test3.Data
{
    internal interface IAthleteRepository
    {
        Task<List<Athlete>> GetAthletes();
        Task<Athlete> GetAthlete(int ID);
        Task<List<Athlete>> GetAthletesBySport(int SportID);
    }
}
