using System.ComponentModel;

namespace BALPortal
{
    public enum clsEnumRequestType
    {
        [Description("INSERT")]
        INSERT = 1,

        [Description("UPDATE")]
        UPDATE = 2,

        [Description("DELETE")]
        DELETE = 3,

        [Description("FREEZE")]
        FREEZE = 4,

        [Description("UPDATE_STATUS")]
        UPDATE_STATUS = 5
    }
}
