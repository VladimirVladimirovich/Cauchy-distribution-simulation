using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class NeymanMethod : Method
    {
        #region Private fields
        private bool even; 
        #endregion

        #region Constructor
        public NeymanMethod(DataInput dataInput) : base(dataInput) 
        { 
            this.even = true; 
        }
        #endregion

        #region Private methods
        private double GetMaxValue()
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
        #endregion

        #region Protected methods
        protected override void ExecuteMethod()
        {
            double value = 0.0;

            if (this.intervalBegin < 0 && this.intervalEnd <= 0)
                value = this.intervalEnd + this.random.NextDouble() * this.intervalBegin - this.intervalEnd;
            else if (this.intervalBegin >= 0 && this.intervalEnd > 0)
                value = this.intervalBegin + this.random.NextDouble() * this.intervalEnd - this.intervalBegin;
            else
            {
                if (even)
                {
                    value = this.intervalEnd + this.random.NextDouble() * this.intervalBegin - this.intervalEnd;
                    this.even = false;
                }
                else
                {
                    value = this.intervalBegin + this.random.NextDouble() * this.intervalEnd - this.intervalBegin;
                    this.even = true;
                }
            }

            double maxValue = this.GetMaxValue() * this.random.NextDouble();
            double analyticValue = this.GetPDF(value);

            if (analyticValue > maxValue)
                this.InsertNewValue(value);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion
    }
}
