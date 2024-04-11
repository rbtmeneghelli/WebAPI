using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobs.Core;

namespace WebJobs.DefaultWebAPI
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            StartupWebJob.Start(args);
        }
    }
}
