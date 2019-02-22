using System.Runtime.Serialization;

namespace RoadStatus.Code.Dtos
{
    [DataContract]
    public class RoadCorridor
    {
        [DataMember(Name = "$type")]
        public string Type { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "statusSeverity")]
        public string StatusSeverity { get; set; }

        [DataMember(Name = "statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [DataMember(Name = "bounds")]
        public string Bounds { get; set; }

        [DataMember(Name = "envelope")]
        public string Envelope { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}