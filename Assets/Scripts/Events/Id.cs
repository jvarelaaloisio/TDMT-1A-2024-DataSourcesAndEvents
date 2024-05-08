using System;
using UnityEngine;

[Serializable]
public class Id : IId
{
    [field: SerializeField] public string name { get; set; }

    public override string ToString()
    {
        return name;
    }
}