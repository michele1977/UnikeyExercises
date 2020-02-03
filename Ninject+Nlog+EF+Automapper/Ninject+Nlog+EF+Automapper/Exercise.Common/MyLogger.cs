using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Common
{
    public class MyLogger
    {
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}
