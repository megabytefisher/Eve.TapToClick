using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick
{
    public class TapData
    {
        public DateTime Start { get; set; }
        public int MaximumActiveContacts { get; set; }
        public bool[] InstantaneousActiveContacts { get; set; }
        public double[] TotalContactDistances { get; set; }
        public uint[] PreviousXValues { get; set; }
        public uint[] PreviousYValues { get; set; }
        public bool TapThresholdMet { get; set; }
        public uint MaximumPressure { get; set; }

        public TapData(int maxContacts)
        {
            Start = DateTime.Now;
            InstantaneousActiveContacts = new bool[maxContacts];
            TotalContactDistances = new double[maxContacts];
            PreviousXValues = new uint[maxContacts];
            PreviousYValues = new uint[maxContacts];
        }
    }
}
