using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    public class InverseFunctionMethod : Method
    {
        #region Constructor
        public InverseFunctionMethod (string name, DataInput dataInput) : base(name, dataInput) { } 
        #endregion

        #region Private methods
        private double GetRandomValue(double x)
        {
            return this.x0 + this.gamma * Math.Tan(Math.PI * (x - 0.5));
        }
        #endregion   

        #region Protected methods
        protected override void ExecuteMethod()
        {
            double value = this.GetRandomValue(this.random.NextDouble());

            if (value > this.intervalBegin && value < this.intervalEnd)
                this.InsertNewValue(value);
        }
        #endregion
    }
}
