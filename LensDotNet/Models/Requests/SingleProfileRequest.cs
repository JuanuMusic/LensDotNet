using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Client.Models.Requests
{
    public class SingleProfileRequest
    {
        public string? Handle {get;set;}
        public string? ProfileId { get; set; }
    }
}
