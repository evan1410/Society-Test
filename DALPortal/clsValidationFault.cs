using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// TODO: Update summary.
/// </summary>

[DataContract]
public class clsValidationFault
{
    [DataMember]
    public string message { get; set; }

    [DataMember]
    public string source { get; set; }

    [DataMember]
    public string description { get; set; }
}
