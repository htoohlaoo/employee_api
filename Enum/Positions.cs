using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace DemoAPI.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Positions
    {
        [EnumMember(Value = "Developer")]
        Developer,

        [EnumMember(Value = "Junior Developer")]
        JuniorDeveloper,

        [EnumMember(Value = "ML Engineer")]
        MLEngineer,

        [EnumMember(Value = "Project Manager")]
        ProjectManager
    }
}
