using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact
{

    public string Name
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }

    public Artifact(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
