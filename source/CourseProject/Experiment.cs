using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class Experiment
    {
        public DataInput dataInput;
        public AnalyticMethod analyticMethodObj;
        public InverseFunctionMethod inverseFunctionMethodObj;
        public NeymanMethod neymanMethodObj;
        public MetropolisMethod metropolisMethodObj;

        public Experiment(DataInput dataInput, AnalyticMethod analyticMethodObj, InverseFunctionMethod inverseFunctionMethodObj, NeymanMethod neymanMethodObj, MetropolisMethod metropolisMethodObj) 
        {
            this.dataInput = new DataInput(dataInput);
            this.analyticMethodObj = new AnalyticMethod(analyticMethodObj);
            this.inverseFunctionMethodObj = new InverseFunctionMethod(inverseFunctionMethodObj);
            this.neymanMethodObj = new NeymanMethod(neymanMethodObj);
            this.metropolisMethodObj = new MetropolisMethod(metropolisMethodObj);
        }

        public Experiment(Experiment experiment)
        {
            this.dataInput = new DataInput(experiment.dataInput);
            this.analyticMethodObj = new AnalyticMethod(experiment.analyticMethodObj);
            this.inverseFunctionMethodObj = new InverseFunctionMethod(experiment.inverseFunctionMethodObj);
            this.neymanMethodObj = new NeymanMethod(experiment.neymanMethodObj);
            this.metropolisMethodObj = new MetropolisMethod(experiment.metropolisMethodObj);
        }

        public void executeInverseMethod(Random random)
        {
            double value = this.inverseFunctionMethodObj.getRandomValue(random.NextDouble());

            if (value > dataInput.intervalBegin && value < dataInput.intervalEnd)
                inverseFunctionMethodObj.insertNewValue(value);
        }

        public void executeNeymanMethod(int i, Random random)
        {
            double value = 0.0;

            if (dataInput.intervalBegin < 0 && dataInput.intervalEnd <= 0)
                value = dataInput.intervalEnd + random.NextDouble() * dataInput.intervalBegin - dataInput.intervalEnd;
            else if (dataInput.intervalBegin >= 0 && dataInput.intervalEnd > 0)
                value = dataInput.intervalBegin + random.NextDouble() * dataInput.intervalEnd - dataInput.intervalBegin;
            else
            {
                if (i % 2 == 0)
                    value = dataInput.intervalEnd + random.NextDouble() * dataInput.intervalBegin - dataInput.intervalEnd;
                else
                    value = dataInput.intervalBegin + random.NextDouble() * dataInput.intervalEnd - dataInput.intervalBegin;
            }

            double maxValue = neymanMethodObj.getMaxValue() * random.NextDouble();
            double analyticValue = analyticMethodObj.getPDF(value);

            if (analyticValue > maxValue)
                neymanMethodObj.insertNewValue(value);
        }

        public void executeMetropolisMethod(Random random)
        {
            double lastXDistance = random.NextDouble();
            double alphaXDistance = (dataInput.intervalEnd - dataInput.intervalBegin);

            while (true)
            {
                double curXDistance = lastXDistance + alphaXDistance * (-1.0 + 2.0 * random.NextDouble());

                if (curXDistance < dataInput.intervalBegin || curXDistance > dataInput.intervalEnd)
                    continue;
                else
                {
                    double curXDensity = analyticMethodObj.getPDF(curXDistance);
                    double lastXDensity = analyticMethodObj.getPDF(lastXDistance);
                    double attitude = curXDensity / lastXDensity;

                    //if (curXDensity >= lastXDensity)
                    if (attitude >= 1.0)
                    {
                        //lastXDistance = curXDistance;
                        metropolisMethodObj.insertNewValue(curXDistance);
                        break;
                    }
                    else if (attitude < 1.0)
                    {
                        if (random.NextDouble() < attitude)
                        {
                            //lastXDistance = curXDistance;
                            metropolisMethodObj.insertNewValue(curXDistance);
                            break;
                        }
                    }
                    else
                        continue;
                }
            }

        }

        public void fillIntervalsList()
        {
            for (double i = dataInput.intervalBegin; Math.Round(i, 2) <= dataInput.intervalEnd; i += dataInput.xAxisStep)
            {
                inverseFunctionMethodObj.intervalsList.Add(i);
                neymanMethodObj.intervalsList.Add(i);
                metropolisMethodObj.intervalsList.Add(i);
            }

            //if (inverseFunctionMethodObj.resultList.Count != inverseFunctionMethodObj.intervalsList.Count)
                //inverseFunctionMethodObj.intervalsList.RemoveAt(0);

            //if (neymanMethodObj.resultList.Count != neymanMethodObj.intervalsList.Count)
              //  neymanMethodObj.intervalsList.RemoveAt(0);

            //if (metropolisMethodObj.resultList.Count != metropolisMethodObj.intervalsList.Count)
              //  metropolisMethodObj.intervalsList.RemoveAt(0);
        }

    }
}
