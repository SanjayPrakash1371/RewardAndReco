using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services.RequestClasses
{
    public  class CheckVoted
    {
        public int campId { get; set; }
        public string VoterId { get; set; }
    }
}
