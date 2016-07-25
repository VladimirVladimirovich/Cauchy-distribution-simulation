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
        #endregion

        #region Constructor
        public Experiment(DataInput dataInput)
        {
            this.dataInput = dataInput;
            this.methods = new Dictionary<string, Method>();

            if (this.dataInput.IsInverseFunctionChecked)
                this.methods.Add("Inverse function", new InverseFunctionMethod(dataInput));
            if (this.dataInput.IsNeymanChecked)
                this.methods.Add("Neyman", new NeymanMethod(dataInput));
            if (this.dataInput.IsMetropolisChecked)
                this.methods.Add("Metropolis", new MetropolisMethod(dataInput));
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
                pair.Value.RunBackgroundWorker();
            }
        }

        public bool IsWorkFinished()
        {
            foreach (KeyValuePair<string, Method> pair in methods)
            {
                if (!pair.Value.IsWorkFinished)
                    return false;
            }

            this.DisposeBackgroundWorkers();

            return true;
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
