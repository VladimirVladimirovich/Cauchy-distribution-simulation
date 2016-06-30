using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class InverseFunctionMethod
    {
        public int experimentsAmount;
        public int partitionsAmount;
        public double gamma;
        public double intervalBegin;
        public double intervalEnd;
        public double intervalDelta;
        public double leftZone;
        public double rightZone;
        public double x0;
        public List<double> resultList;
        public List<double> intervalsList;

        public InverseFunctionMethod(int experimentsAmount, int partitionsAmount, double gamma, double intervalBegin, double intervalEnd, double x0) 
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
            this.resultList = new List<double>(new double[this.partitionsAmount + 1]);
            this.intervalsList = new List<double>();
        }

        public InverseFunctionMethod(InverseFunctionMethod inverseFunctionMethod)
        {
            this.experimentsAmount = inverseFunctionMethod.experimentsAmount;
            this.partitionsAmount = inverseFunctionMethod.partitionsAmount;
            this.gamma = inverseFunctionMethod.gamma;
            this.intervalBegin = inverseFunctionMethod.intervalBegin;
            this.intervalEnd = inverseFunctionMethod.intervalEnd;
            this.x0 = inverseFunctionMethod.x0;
            this.intervalDelta = inverseFunctionMethod.intervalDelta;
            this.leftZone = inverseFunctionMethod.leftZone;
            this.rightZone = inverseFunctionMethod.rightZone;
            this.resultList = new List<double>(inverseFunctionMethod.resultList);
            this.intervalsList = new List<double>(inverseFunctionMethod.intervalsList);
        }

        public void insertNewValue(double value)
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

        public double getRandomValue(double x)
        {
            return this.x0 + this.gamma * Math.Tan(Math.PI * (x - 0.5));
        }

        public List<double> getResultList() 
        {
            double max = resultList.Max();
            AnalyticMethod analytic = new AnalyticMethod(this.gamma, this.intervalBegin, this.intervalEnd, this.x0);
            double maxAnalytic = analytic.getResultList().Max();

            for (int i = 0; i < resultList.Count; i++)
                resultList[i] = (resultList[i] / max) * maxAnalytic;

            resultList[resultList.Count - 1] = resultList[resultList.Count - 2];

            return this.resultList; 
        }

        public List<double> getIntervalsList() { return this.intervalsList; }
    }
}
