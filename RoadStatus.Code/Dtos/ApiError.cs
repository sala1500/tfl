using System;
using System.Runtime.Serialization;

namespace RoadStatus.Code.Dtos
{
    [DataContract]
    public class ApiError
    {
        [DataMember(Name = "$type")]
        public string Type { get; set; }

        [DataMember(Name = "timestampUtc")]
        public DateTime TimestampUtc { get; set; }

        [DataMember(Name = "exceptionType")]
        public string ExceptionType { get; set; }

        [DataMember(Name = "httpStatusCode")]
        public int HttpStatusCode { get; set; }

        [DataMember(Name = "httpStatus")]
        public string HttpStatus { get; set; }

        [DataMember(Name = "relativeUri")]
        public string RelativeUri { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}