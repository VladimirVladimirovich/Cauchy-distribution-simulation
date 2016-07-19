using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class AnalyticMethod
    {
        #region Private fields
        private double gamma;
        private double intervalBegin;
        private double intervalEnd;
        private double x0;
        #endregion

        #region Public fields
        private List<double> resultList;
        private List<double> intervalsList;  
        #endregion

        #region Constructors
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
                this.resultList.Add(this.GetPDF(i));
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
        #endregion

        #region Public methods
        public double GetPDF(double value)
        {
            return 1 / (Math.PI * this.gamma * (1 + Math.Pow((value - this.x0) / this.gamma, 2)));
        }

        public List<double> GetResultList() { return this.resultList; }
        public List<double> GetIntervalsList() { return this.intervalsList; } 
        #endregion
    }
}
