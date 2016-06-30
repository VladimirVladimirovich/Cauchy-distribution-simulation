using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class AnalyticMethod
    {
        public double gamma;
        public double intervalBegin;
        public double intervalEnd;
        public double x0;
        public List<double> resultList;
        public List<double> intervalsList;

        public AnalyticMethod(double gamma, double intervalBegin, double intervalEnd, double x0) 
        {
            this.gamma = gamma;
            this.intervalBegin = intervalBegin;
            this.intervalEnd = intervalEnd;
            this.x0 = x0;
            this.resultList = new List<double>();
            this.intervalsList = new List<double>();

            double delta = (this.intervalEnd - this.intervalBegin) / 1000.0;

            for (double i = this.intervalBegin; i < this.intervalEnd; i += delta) 
            {
                this.intervalsList.Add(i);
                this.resultList.Add(getPDF(i));
            }
        }

        public AnalyticMethod(AnalyticMethod analyticMethod)
        {
            this.gamma = analyticMethod.gamma;
            this.intervalBegin = analyticMethod.intervalBegin;
            this.intervalEnd = analyticMethod.intervalEnd;
            this.x0 = analyticMethod.x0;
            this.resultList = new List<double>(analyticMethod.resultList);
            this.intervalsList = new List<double>(analyticMethod.intervalsList);
        }

        public double getPDF(double value)
        {
            return 1 / (Math.PI * this.gamma * (1 + Math.Pow((value - this.x0) / this.gamma, 2)));
        }

        public List<double> getResultList() { return this.resultList; }
        public List<double> getIntervalsList() { return this.intervalsList; }
    }
}
