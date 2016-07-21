using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class MetropolisMethod : Method
    {
        #region Constructors
        public MetropolisMethod(int experimentsAmount, 
            int partitionsAmount, double gamma, double intervalBegin, double intervalEnd,
            double x0) : base(experimentsAmount, partitionsAmount, gamma, intervalBegin, intervalEnd, x0) { }
        #endregion

        #region Public methods
        public override void InsertNewValue(double value)
        {
            base.InsertNewValue(value);
        }

        public override void ExecuteMethod()
        {
            double metropolisValue = 0.0;
            double lastXDistance = random.NextDouble();
            double alphaXDistance = (this.intervalEnd - this.intervalBegin) / 2.0;

            while (true)
            {
                double curXDistance = lastXDistance + alphaXDistance * (-1.0 + 2.0 * random.NextDouble());

                if (curXDistance < this.intervalBegin || curXDistance > this.intervalEnd)
                    continue;
                else
                {
                    double curXDensity = this.GetPDF(curXDistance);
                    double lastXDensity = this.GetPDF(lastXDistance);
                    double attitude = curXDensity / lastXDensity;

                    if (curXDensity >= lastXDensity)
                    {
                        metropolisValue = curXDistance;
                        lastXDistance = curXDistance;
                        this.InsertNewValue(metropolisValue);
                        break;
                    }
                    else if (attitude < 1.0)
                    {
                        if (random.NextDouble() < attitude)
                        {
                            metropolisValue = curXDistance;
                            lastXDistance = curXDistance;
                            this.InsertNewValue(metropolisValue);
                            break;
                        }
                    }
                    else
                        continue;
                }
            }
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
