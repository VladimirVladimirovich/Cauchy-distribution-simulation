using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class MetropolisMethod
    {
        #region Private fields
        private int experimentsAmount;
        private int partitionsAmount;
        private double gamma;
        private double intervalBegin;
        private double intervalEnd;
        private double intervalDelta;
        private double leftZone;
        private double rightZone;
        private double x0;
        #endregion

        #region Public fields
        public List<double> resultList;
        public List<double> intervalsList;  
        #endregion

        #region Constructors
        public MetropolisMethod(int experimentsAmount, int partitionsAmount, double gamma, double intervalBegin, double intervalEnd, double x0)
        {
            this.experimentsAmount = experimentsAmount;
            this.partitionsAmount = partitionsAmount;
            this.gamma = gamma;
            this.intervalBegin = intervalBegin;
            this.intervalEnd = intervalEnd;
            this.x0 = x0;
            this.intervalDelta = (this.intervalEnd - this.intervalBegin) / (double)this.partitionsAmount;
            this.leftZone = this.intervalBegin;
            this.rightZone = this.intervalBegin + this.intervalDelta;
            this.resultList = new List<double>(new double[this.partitionsAmount]);
            this.intervalsList = new List<double>();
        }

        public MetropolisMethod(MetropolisMethod metropolisMethod)
        {
            this.experimentsAmount = metropolisMethod.experimentsAmount;
            this.partitionsAmount = metropolisMethod.partitionsAmount;
            this.gamma = metropolisMethod.gamma;
            this.intervalBegin = metropolisMethod.intervalBegin;
            this.intervalEnd = metropolisMethod.intervalEnd;
            this.x0 = metropolisMethod.x0;
            this.intervalDelta = metropolisMethod.intervalDelta;
            this.leftZone = metropolisMethod.leftZone;
            this.rightZone = metropolisMethod.rightZone;
            this.resultList = new List<double>(metropolisMethod.resultList);
            this.intervalsList = new List<double>(metropolisMethod.intervalsList);
        } 
        #endregion

        #region Public methods
        public void InsertNewValue(double value)
        {
            for (int i = 0; i < this.partitionsAmount; i++)
            {
                if (value > this.leftZone && value <= this.rightZone)
                {
                    this.resultList[i]++;
                    break;
                }

                this.leftZone += this.intervalDelta;
                this.rightZone += this.intervalDelta;
            }

            this.leftZone = this.intervalBegin;
            this.rightZone = this.intervalBegin + this.intervalDelta;
        }

        public List<double> GetResultList()
        {
            double max = this.resultList.Max();
            AnalyticMethod analytic = new AnalyticMethod(this.gamma, this.intervalBegin, this.intervalEnd, this.x0);
            double maxAnalytic = analytic.GetResultList().Max();

            for (int i = 0; i < this.resultList.Count; i++)
                this.resultList[i] = (this.resultList[i] / max) * maxAnalytic;

            return this.resultList;
        }

        public List<double> GetIntervalsList() { return this.intervalsList; } 
        #endregion
    }
}
