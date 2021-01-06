using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Contracts
{
    public interface IDateTime
    {
        static DateTime Now() { return DateTime.UtcNow.AddHours(3); }
    }
}
