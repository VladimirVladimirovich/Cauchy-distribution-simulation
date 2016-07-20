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
        public MetropolisMethod(int experimentsAmount, int partitionsAmount, double gamma, double intervalBegin, double intervalEnd, double x0) : base(experimentsAmount, partitionsAmount, gamma, intervalBegin, intervalEnd, x0)
        {
        }
        #endregion

        #region Public methods
        public override void InsertNewValue(double value)
        {
            base.InsertNewValue(value);
        }

        public override void ExecuteMethod()
        {
            
        }

        public List<double> GetResultList()
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
        }

        public double GetPDF(double value)
        {
            return base.GetPDF(value);
        }
        #endregion
    }
}
