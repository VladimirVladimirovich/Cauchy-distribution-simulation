using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class InverseFunctionMethod : Method
    {
        #region Constructors
        public InverseFunctionMethod (int experimentsAmount, 
            int partitionsAmount, double gamma, double intervalBegin, double intervalEnd,
            double x0) : base(experimentsAmount, partitionsAmount, gamma, intervalBegin, intervalEnd, x0) { } 
        #endregion

        #region Public methods
        public override void ExecuteMethod()
        {
            double value = this.GetRandomValue(this.random.NextDouble());

            if (value > this.intervalBegin && value < this.intervalEnd)
                this.InsertNewValue(value);
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

        public double GetRandomValue(double x)
        {
            return this.x0 + this.gamma * Math.Tan(Math.PI * (x - 0.5));
        }        
        #endregion
    }
}
