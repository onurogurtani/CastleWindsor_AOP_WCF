using System;
using System.Diagnostics;
using Castle.DynamicProxy;

namespace CastleWindsor_AOP_WCF.Aspects
{
    public class Performance : IInterceptor
    {
        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                invocation.Proceed();
                TextLogHelper.WriteLog(string.Format("Total execution time  is:" + stopwatch.ElapsedMilliseconds + " ms"));
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                TextLogHelper.WriteLog(string.Format("Total execution time  is:" + stopwatch.ElapsedMilliseconds + " ms"));
                throw ex;
            }
        }

        #endregion
    }
}