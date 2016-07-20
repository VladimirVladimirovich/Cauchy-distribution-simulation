using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class DataInput
    {
        #region Auto-properties
        public int ExperimentsAmount { get; private set; }
        public int ActualExperimentsAmount { get; set; }
        public int PartitionsAmount { get; private set; }
        public double Gamma { get; private set; }
        public int IntervalBegin { get; private set; }
        public int IntervalEnd { get; private set; }
        public int X0 { get; private set; }
        public double XAxisStep { get; private set; }
        public bool IsInverseFunctionChecked { get; private set; }
        public bool IsNeymanChecked { get; private set; }
        public bool IsMetropolisChecked { get; private set; }
        #endregion

        #region Constructors
        public DataInput(int experimentsAmount, int partitionsAmount, double gamma, int intervalBegin, int intervalEnd, bool isInverseFunctionChecked, bool isNeymanChecked, bool isMetropolisChecked)
        {
            this.ExperimentsAmount = experimentsAmount;
            this.ActualExperimentsAmount = 0;
            this.PartitionsAmount = partitionsAmount;
            this.Gamma = gamma;
            this.IntervalBegin = intervalBegin;
            this.IntervalEnd = intervalEnd;
            this.X0 = (this.IntervalBegin + this.IntervalEnd) / 2;
            this.XAxisStep = (this.IntervalEnd - this.IntervalBegin) / (double)this.PartitionsAmount;
            this.IsInverseFunctionChecked = isInverseFunctionChecked;
            this.IsNeymanChecked = isNeymanChecked;
            this.IsMetropolisChecked = isMetropolisChecked;
        }

        public DataInput(DataInput dataInput)
        {
            this.ExperimentsAmount = dataInput.ExperimentsAmount;
            this.ActualExperimentsAmount = dataInput.ActualExperimentsAmount;
            this.PartitionsAmount = dataInput.PartitionsAmount;
            this.Gamma = dataInput.Gamma;
            this.IntervalBegin = dataInput.IntervalBegin;
            this.IntervalEnd = dataInput.IntervalEnd;
            this.X0 = dataInput.X0;
            this.XAxisStep = dataInput.XAxisStep;
            this.IsInverseFunctionChecked = dataInput.IsInverseFunctionChecked;
            this.IsNeymanChecked = dataInput.IsNeymanChecked;
            this.IsMetropolisChecked = dataInput.IsMetropolisChecked;
        } 
        #endregion
    }
}
