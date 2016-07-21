using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class NeymanMethod : Method
    {
        #region Constructors
        public NeymanMethod(int experimentsAmount,
            int partitionsAmount, double gamma, double intervalBegin, double intervalEnd, 
            double x0) : base(experimentsAmount, partitionsAmount, gamma, intervalBegin, intervalEnd, x0) { }
        #endregion

        #region Public methods
        public override void ExecuteMethod(int i)
        {
            double value = 0.0;

            if (this.intervalBegin < 0 && this.intervalEnd <= 0)
                value = this.intervalEnd + random.NextDouble() * this.intervalBegin - this.intervalEnd;
            else if (this.intervalBegin >= 0 && this.intervalEnd > 0)
                value = this.intervalBegin + this.random.NextDouble() * this.intervalEnd - this.intervalBegin;
            else
            {
                if (i % 2 == 0)
                    value = this.intervalEnd + this.random.NextDouble() * this.intervalBegin - this.intervalEnd;
                else
                    value = this.intervalBegin + this.random.NextDouble() * this.intervalEnd - this.intervalBegin;
            }

            double maxValue = this.GetMaxValue() * random.NextDouble();
            double analyticValue = this.GetPDF(value);

            if (analyticValue > maxValue)
                this.InsertNewValue(value);
        }

        public double GetMaxValue()
        {
            double max = this.GetPDF(0);

            for (double i = this.intervalBegin; i < this.intervalEnd; i += 0.005)
            {
                double value = this.GetPDF(i);
                if (value > max)
                    max = value;
            }

            return max;
        }

        public void InsertNewValue(double value)
        {
            base.InsertNewValue(value);
        }

        /*public List<double> GetResultList()
        {
            return base.GetResultList();
        }

        public List<double> GetIntervalsList() 
        { 
            return base.GetIntervalsList(); 
        }

        public List<double> GetAnalyticResultList()
        {
            return base.GetAnalyticResultList();
        }

        public List<double> GetAnalyticIntervalsList()
        {
            return base.GetAnalyticIntervalsList();
        }*/
   
        public double GetPDF(double value)
        {
            return base.GetPDF(value);
        }
        #endregion
    }
}
