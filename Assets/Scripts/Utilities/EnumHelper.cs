using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumHelper
{
    public static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new System.Random().Next(v.Length));
    }
}
