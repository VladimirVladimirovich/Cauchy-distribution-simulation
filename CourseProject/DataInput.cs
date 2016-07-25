using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    public class DataInput
    {
        #region Public properties
        public int ExperimentsAmount { get; private set; }
        public int ActualExperimentsAmount { get; set; }
        public int PartitionsAmount { get; private set; }
        public double Gamma { get; private set; }
        public int IntervalBegin { get; private set; }
        public int IntervalEnd { get; private set; }
        public int X0 { get; private set; }
        public bool IsInverseFunctionChecked { get; private set; }
        public bool IsNeymanChecked { get; private set; }
        public bool IsMetropolisChecked { get; private set; }
        #endregion

        #region Constructor
        public DataInput(int experimentsAmount, int partitionsAmount, double gamma, int intervalBegin, int intervalEnd, bool isInverseFunctionChecked, bool isNeymanChecked, bool isMetropolisChecked)
        {
            this.ExperimentsAmount = experimentsAmount;
            this.ActualExperimentsAmount = 0;
            this.PartitionsAmount = partitionsAmount;
            this.Gamma = gamma;
            this.IntervalBegin = intervalBegin;
            this.IntervalEnd = intervalEnd;
            this.X0 = (this.IntervalBegin + this.IntervalEnd) / 2;
            this.IsInverseFunctionChecked = isInverseFunctionChecked;
            this.IsNeymanChecked = isNeymanChecked;
            this.IsMetropolisChecked = isMetropolisChecked;
        }
        #endregion
    }
}
