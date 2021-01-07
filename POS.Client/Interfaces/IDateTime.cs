using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Client.Interfaces
{
    public interface IDateTime
    {
        static DateTime Now() { return DateTime.UtcNow.AddHours(3); }
    }
}
