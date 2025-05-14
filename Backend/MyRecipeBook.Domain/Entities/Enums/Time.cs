using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Domain.Entities.Enums
{
    public enum Time
    {
        Less_Than_10_Minutes = 0,
        Between_10_And_30_Minutes = 1,
        Between_30_And_60_Minutes = 2,
        More_Than_1_Hour = 3,
        More_Than_2_Hours = 4,
        More_Than_3_Hours = 5
    }
}
