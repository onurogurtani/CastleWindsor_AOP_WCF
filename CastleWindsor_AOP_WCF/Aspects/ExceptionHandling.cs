using System;
using System.Reflection;
using Castle.DynamicProxy;
using CastleWindsor_AOP_WCF.Response;

namespace CastleWindsor_AOP_WCF.Aspects
{
    public class ExceptionHandling : IInterceptor
    {
        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                if (invocation.Method.ReturnParameter.ParameterType.FullName ==
                    "CastleWindsorWCF_AOP_Demo.Response.PrimitiveResponse")
                {
                    invocation.ReturnValue = new PrimitiveResponse
                                                 {
                                                     EntityPrimaryKey = null,
                                                     PrimitiveResponseValue = "",
                                                     ResponseCode = ResponseCodes.ServiceError,
                                                     ResponseErrorMessage = "Service Error",
                                                     ResponseMessage = "Service Error",
                                                     ResponseUserFriendlyMessageKey = ""
                                                 };
                    TextLogHelper.WriteLog("Inner Exception " + ex.InnerException.StackTrace);
                    TextLogHelper.WriteLog("Error Message " + ex.Message);
                    TextLogHelper.WriteLog("Error StackTrace " + ex.StackTrace);
                    TextLogHelper.WriteLog("Result of " + invocation.Method.Name + " is: " + "Fail");
                    throw;
                }
                else
                {
                    Type listType = invocation.Method.ReturnType;
                    object ret = Activator.CreateInstance(listType);
                    Type type = ret.GetType();
                    PropertyInfo responseCode = type.GetProperty("ResponseCode");
                    responseCode.SetValue(ret, ResponseCodes.ServiceError, null);
                    PropertyInfo responseErrorMessage = type.GetProperty("ResponseErrorMessage");
                    responseErrorMessage.SetValue(ret, "Service Error", null);
                    PropertyInfo responseMessage = type.GetProperty("ResponseMessage");
                    responseMessage.SetValue(ret, "Service Error", null);
                    invocation.ReturnValue = ret;

                    TextLogHelper.WriteLog("Inner Exception " + ex.InnerException.StackTrace);
                    TextLogHelper.WriteLog("Error Message " + ex.Message);
                    TextLogHelper.WriteLog("Error StackTrace " + ex.StackTrace);
                    TextLogHelper.WriteLog("Result of " + invocation.Method.Name + " is: " + "Fail");
                    throw;
                }
            }
        }

        #endregion
    }
}