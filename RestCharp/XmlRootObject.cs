using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("root")]
public class XmlRootObject
{
    [XmlElement("city")]
    public string City { get; set; }

    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlElement("state")]
    public string State { get; set; }
}
