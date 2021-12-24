using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    /// <summary>
    /// Author: Jaswinder Sangha
    /// Date: July 23 2019
    /// </summary>
    public class Dock
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool WaterService { get; set; }

        public bool ElectricalService { get; set; }
    }
}
