using System.Collections.Generic;
using CastleWindsor_AOP_WCF.Response;

namespace CastleWindsor_AOP_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TestService : ITestService
    {
        #region ITestService Members

        public PrimitiveResponse TestPrimitive(int agentId)
        {
            return new PrimitiveResponse
                       {
                           EntityPrimaryKey = "1",
                           PrimitiveResponseValue = "success",
                           ResponseCode = ResponseCodes.Success,
                           ResponseMessage = "success"
                       };
        }

        public EntityResponse<Data> TestEntity(int agentId)
        {
            var datalist = new List<Data>();
            datalist.Add(new Data {Text = "onur", Value = 1});
            datalist.Add(new Data {Text = "ayse", Value = 2});
            datalist.Add(new Data {Text = "fatma", Value = 3});
            return new EntityResponse<Data>
                       {
                           EntityData = datalist[0],
                           EntityDataList = datalist,
                           ResponseCode = ResponseCodes.Success,
                           ResponseMessage = "success"
                       };
        }

        #endregion
    }
}