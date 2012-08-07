using System.Runtime.Serialization;

namespace CastleWindsor_AOP_WCF.Response
{
    [DataContract]
    public class PrimitiveResponse
    {
        [DataMember]
        public ResponseCodes ResponseCode { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }

        [DataMember]
        public string PrimitiveResponseValue { get; set; }

        [DataMember]
        public string EntityPrimaryKey { get; set; }

        [DataMember]
        public string ResponseUserFriendlyMessageKey { get; set; }

        [DataMember]
        public string ResponseErrorMessage { get; set; }
    }
}