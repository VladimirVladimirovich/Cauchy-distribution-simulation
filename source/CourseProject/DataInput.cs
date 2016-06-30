using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class DataInput
    {
        public int experimentsAmount;
        public int actualExperimentsAmount;
        public int partitionsAmount;
        public double gamma;
        public int intervalBegin;
        public int intervalEnd;
        public int x0;
        public double xAxisStep;
        public bool isInverseFunctionChecked;
        public bool isNeymanChecked;
        public bool isMetropolisChecked;

        public DataInput(int experimentsAmount, int partitionsAmount, double gamma, int intervalBegin, int intervalEnd, bool isInverseFunctionChecked, bool isNeymanChecked, bool isMetropolisChecked)
        {
            this.experimentsAmount = experimentsAmount;
            this.actualExperimentsAmount = 0;
            this.partitionsAmount = partitionsAmount;
            this.gamma = gamma;
            this.intervalBegin = intervalBegin;
            this.intervalEnd = intervalEnd;
            this.x0 = (this.intervalBegin + this.intervalEnd) / 2;
            this.xAxisStep = (this.intervalEnd - this.intervalBegin) / (double)this.partitionsAmount;
            this.isInverseFunctionChecked = isInverseFunctionChecked;
            this.isNeymanChecked = isNeymanChecked;
            this.isMetropolisChecked = isMetropolisChecked;
        }

        public DataInput(DataInput dataInput)
        {
            this.experimentsAmount = dataInput.experimentsAmount;
            this.actualExperimentsAmount = dataInput.actualExperimentsAmount;
            this.partitionsAmount = dataInput.partitionsAmount;
            this.gamma = dataInput.gamma;
            this.intervalBegin = dataInput.intervalBegin;
            this.intervalEnd = dataInput.intervalEnd;
            this.x0 = dataInput.x0;
            this.xAxisStep = dataInput.xAxisStep;
            this.isInverseFunctionChecked = dataInput.isInverseFunctionChecked;
            this.isNeymanChecked = dataInput.isNeymanChecked;
            this.isMetropolisChecked = dataInput.isMetropolisChecked;
        }
    }
}
