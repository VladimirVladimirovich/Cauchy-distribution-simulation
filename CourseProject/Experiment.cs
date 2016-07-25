using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseProject
{
    [Serializable]
    public class Experiment
    {
        #region Private fields
        private DataInput dataInput;
        private Dictionary<string, Method> methods;

        private const string inverseFunctionKey = "Inverse function";
        private const string neymanStringKey = "Neyman";
        private const string metropolisStringKey = "Metropolis";
        #endregion

        #region Constructor
        public Experiment(DataInput dataInput)
        {
            this.dataInput = dataInput;
            this.methods = new Dictionary<string, Method>();

            if (this.dataInput.IsInverseFunctionChecked)
            {
                InverseFunctionMethod inverseMethod = new InverseFunctionMethod(inverseFunctionKey, dataInput);
                inverseMethod.OnComplete += this.MethodWorkComplete;
                this.methods.Add(inverseFunctionKey, inverseMethod);
            }
            if (this.dataInput.IsNeymanChecked)
            {
                NeymanMethod neymanMethod = new NeymanMethod(neymanStringKey, dataInput);
                neymanMethod.OnComplete += this.MethodWorkComplete;
                this.methods.Add(neymanStringKey, neymanMethod);
            }
            if (this.dataInput.IsMetropolisChecked)
            {
                MetropolisMethod metropolisMethod = new MetropolisMethod(metropolisStringKey, dataInput);
                metropolisMethod.OnComplete += this.MethodWorkComplete;
                this.methods.Add(metropolisStringKey, metropolisMethod);
            }
        }
        #endregion

        #region Private methods
        private void DisposeBackgroundWorkers()
        {
            foreach (KeyValuePair<string, Method> pair in this.methods)
            {
                try
                {
                    pair.Value.Dispose();
                }
                catch (Exception e) 
                { 
                    System.Console.WriteLine(e.Message); 
                }
            }
        } 
        #endregion

        public delegate void DrawChartEventHandler(String methodName);
        public event DrawChartEventHandler DrawChart;

        #region Public properties
        public DataInput DataInput 
        {
            get
            {
                return this.dataInput;
            } 
        }

        public Dictionary<string, Method> Methods
        {
            get
            {
                return this.methods;
            }
        }
        #endregion

        #region Public methods
        public void LaunchExperiment()
        {
            foreach (KeyValuePair<string, Method> pair in methods)
            {
                pair.Value.RunWorkAsync();
            }
        }

        public void MethodWorkComplete(Method sender)
        {
            if (sender.IsCancelled)
            {
                
            }
            else if (sender.Error != null)
            {
                
            }
            else
            {
                DrawChart(sender.Name);
            }
        }

        public IEnumerable<double> GetResultList(string methodName)
        {
            Method method;

            if (this.methods.TryGetValue(methodName, out method))
            {
                return method.ResultList;
            }
            else
            {
                Console.WriteLine(methodName + "not found");
                return null;
            }
        }

        public IEnumerable<double> GetIntervalsList(string methodName)
        {
            Method method;

            if (this.methods.TryGetValue(methodName, out method))
            {

                return method.IntervalsList;
            }
            else
            {
                Console.WriteLine(methodName + "not found");
                return null;
            }
        }

        public IEnumerable<double> GetAnalyticResultList(string methodName)
        {
            Method method;

            if (this.methods.TryGetValue(methodName, out method))
            {
                return method.AnalyticResultList;
            }
            else
            {
                Console.WriteLine(methodName + "not found");
                return null;
            }
        }

        public IEnumerable<double> GetAnalyticIntervalsList(string methodName)
        {
            Method method;

            if (this.methods.TryGetValue(methodName, out method))
            {
                return method.AnalyticIntervalsList;
            }
            else
            {
                Console.WriteLine(methodName + "not found");
                return null;
            }
        } 
        #endregion
    }
}
