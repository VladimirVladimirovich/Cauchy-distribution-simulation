using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class Experiment
    {
        #region Auto-properties
        public DataInput DataInput { get; private set; }
        public AnalyticMethod AnalyticMethodObj { get; private set; }
        public InverseFunctionMethod InverseFunctionMethodObj { get; private set; }
        public NeymanMethod NeymanMethodObj { get; private set; }
        public MetropolisMethod MetropolisMethodObj { get; private set; } 
        #endregion

        public Experiment(DataInput dataInput, AnalyticMethod analyticMethodObj, InverseFunctionMethod inverseFunctionMethodObj, NeymanMethod neymanMethodObj, MetropolisMethod metropolisMethodObj) 
        {
            this.DataInput = new DataInput(dataInput);
            this.AnalyticMethodObj = new AnalyticMethod(analyticMethodObj);
            this.InverseFunctionMethodObj = new InverseFunctionMethod(inverseFunctionMethodObj);
            this.NeymanMethodObj = new NeymanMethod(neymanMethodObj);
            this.MetropolisMethodObj = new MetropolisMethod(metropolisMethodObj);
        }

        public Experiment(Experiment experiment)
        {
            this.DataInput = new DataInput(experiment.DataInput);
            this.AnalyticMethodObj = new AnalyticMethod(experiment.AnalyticMethodObj);
            this.InverseFunctionMethodObj = new InverseFunctionMethod(experiment.InverseFunctionMethodObj);
            this.NeymanMethodObj = new NeymanMethod(experiment.NeymanMethodObj);
            this.MetropolisMethodObj = new MetropolisMethod(experiment.MetropolisMethodObj);
        }

        public void ExecuteInverseMethod(Random random)
        {
            double value = this.InverseFunctionMethodObj.GetRandomValue(random.NextDouble());

            if (value > this.DataInput.IntervalBegin && value < this.DataInput.IntervalEnd)
                this.InverseFunctionMethodObj.InsertNewValue(value);
        }

        public void ExecuteNeymanMethod(int i, Random random)
        {
            double value = 0.0;

            if (this.DataInput.IntervalBegin < 0 && this.DataInput.IntervalEnd <= 0)
                value = this.DataInput.IntervalEnd + random.NextDouble() * this.DataInput.IntervalBegin - this.DataInput.IntervalEnd;
            else if (this.DataInput.IntervalBegin >= 0 && this.DataInput.IntervalEnd > 0)
                value = this.DataInput.IntervalBegin + random.NextDouble() * this.DataInput.IntervalEnd - this.DataInput.IntervalBegin;
            else
            {
                if (i % 2 == 0)
                    value = this.DataInput.IntervalEnd + random.NextDouble() * this.DataInput.IntervalBegin - this.DataInput.IntervalEnd;
                else
                    value = this.DataInput.IntervalBegin + random.NextDouble() * this.DataInput.IntervalEnd - this.DataInput.IntervalBegin;
            }

            double maxValue = this.NeymanMethodObj.GetMaxValue() * random.NextDouble();
            double analyticValue = this.AnalyticMethodObj.GetPDF(value);

            if (analyticValue > maxValue)
                this.NeymanMethodObj.InsertNewValue(value);
        }

        public void ExecuteMetropolisMethod(Random random)
        {
            double metropolisValue = 0.0;
            double lastXDistance = random.NextDouble();
            double alphaXDistance = (this.DataInput.IntervalEnd - this.DataInput.IntervalBegin) / 2.0;

            while (true)
            {
                double curXDistance = lastXDistance + alphaXDistance * (-1.0 + 2.0 * random.NextDouble());

                if (curXDistance < this.DataInput.IntervalBegin || curXDistance > this.DataInput.IntervalEnd)
                    continue;
                else
                {
                    double curXDensity = this.AnalyticMethodObj.GetPDF(curXDistance);
                    double lastXDensity = this.AnalyticMethodObj.GetPDF(lastXDistance);
                    double attitude = curXDensity / lastXDensity;

                    if (curXDensity >= lastXDensity)
                    {
                        metropolisValue = curXDistance;
                        lastXDistance = curXDistance;
                        this.MetropolisMethodObj.InsertNewValue(metropolisValue);
                        break;
                    }
                    else if (attitude < 1.0)
                    {
                        if (random.NextDouble() < attitude)
                        {
                            metropolisValue = curXDistance;
                            lastXDistance = curXDistance;
                            this.MetropolisMethodObj.InsertNewValue(metropolisValue);
                            break;
                        }
                    }
                    else
                        continue;
                }
            }

        }

        public void FillIntervalsList()
        {
            for (double i = this.DataInput.IntervalBegin; i < this.DataInput.IntervalEnd; i += this.DataInput.XAxisStep)
            {
                this.InverseFunctionMethodObj.intervalsList.Add(i);
                this.NeymanMethodObj.intervalsList.Add(i);
                this.MetropolisMethodObj.intervalsList.Add(i);
            }

            if (this.InverseFunctionMethodObj.resultList.Count != this.InverseFunctionMethodObj.intervalsList.Count)
                this.InverseFunctionMethodObj.intervalsList.RemoveAt(this.DataInput.PartitionsAmount - 1);

            if (this.NeymanMethodObj.resultList.Count != this.NeymanMethodObj.intervalsList.Count)
                this.NeymanMethodObj.intervalsList.RemoveAt(this.DataInput.PartitionsAmount - 1);

            if (this.MetropolisMethodObj.resultList.Count != this.MetropolisMethodObj.intervalsList.Count)
                this.MetropolisMethodObj.intervalsList.RemoveAt(this.DataInput.PartitionsAmount - 1);
        }

    }
}
