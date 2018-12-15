//Genrate c# objects using http://json2csharp.com/

using System.Collections.Generic;

public class Guest
{
    public string fname { get; set; }
    public string lname { get; set; }
}

public class Guestbook
{
    public List<Guest> guest { get; set; }
}

public class RootObject
{
    public Guestbook guestbook { get; set; }
}