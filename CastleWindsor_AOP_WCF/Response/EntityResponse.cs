using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CastleWindsor_AOP_WCF.Response
{
    [DataContract]
    public class EntityResponse<TRequestType>
    {
        public List<TRequestType> _entityDataList = new List<TRequestType>();

        [DataMember]
        public ResponseCodes ResponseCode { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }

        [DataMember]
        public List<TRequestType> EntityDataList
        {
            get { return _entityDataList; }
            set { _entityDataList = value; }
        }

        [DataMember]
        public TRequestType EntityData { get; set; }

        [DataMember]
        public string ResponseUserFriendlyMessageKey { get; set; }

        [DataMember]
        public string ResponseErrorMessage { get; set; }
    }
}