using System.Runtime.Serialization;
using EMS.Business;
using Newtonsoft.Json;

namespace EMS.API
{
    [DataContract]
    public class ServiceContract
    {
        public ServiceContract(int statusCode, ResultModel resultModel, string message)
        {
            StatusCode = statusCode;
            ResultModel = resultModel;
            Message = message;
        }

        [DataMember]
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [DataMember]
        [JsonProperty("resultModel")]
        public ResultModel ResultModel { get; set; }

        [DataMember]
        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
