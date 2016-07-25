using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    public class MetropolisMethod : Method
    {
        #region Constructor
        public MetropolisMethod(DataInput dataInput) : base(dataInput) { }
        #endregion

        #region Protected methods
        protected override void ExecuteMethod()
        {
            double metropolisValue = 0.0;
            double lastXDistance = this.random.NextDouble();
            double alphaXDistance = (this.intervalEnd - this.intervalBegin) / 2.0;

            while (true)
            {
                double curXDistance = lastXDistance + alphaXDistance * (-1.0 + 2.0 * this.random.NextDouble());

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
                        if (this.random.NextDouble() < attitude)
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

        protected override void OnDispose()
        {

        }
        #endregion
    }
}
