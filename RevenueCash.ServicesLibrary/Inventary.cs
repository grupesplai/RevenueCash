using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueCash.ServicesLibrary
{
    public class Inventary
    {
        [DtaNames("first_name")]
    public string FirstName { get; set; }

    [DtaNames("last_name")]
    public string LastName { get; set; }

    [DtaNames("dob")]
    public DateTime DateOfBirth { get; set; }

    [DtaNames("job_title")]
    public string JobTitle { get; set; }

    [DtaNames("taken_name")]
    public int TakenName { get; set; }

    [DtaNames("is_american")]
    public bool IsAmerican { get; set; }
    }
}
