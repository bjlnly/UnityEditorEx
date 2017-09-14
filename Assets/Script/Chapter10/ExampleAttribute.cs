using UnityEngine;
using System.Collections;

public class ExampleAttribute : PropertyAttribute
{

}

[System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class Range2Attribute : PropertyAttribute
{
    public readonly int min;
    public readonly int max;

    public Range2Attribute(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}
