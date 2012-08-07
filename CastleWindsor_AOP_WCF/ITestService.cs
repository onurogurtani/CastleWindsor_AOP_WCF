using System.Runtime.Serialization;
using System.ServiceModel;
using CastleWindsor_AOP_WCF.Response;

namespace CastleWindsor_AOP_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        PrimitiveResponse TestPrimitive(int value);

        [OperationContract]
        EntityResponse<Data> TestEntity(int value);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int Value { get; set; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}