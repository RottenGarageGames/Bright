using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public static class NumberGenerator
{
    public static int GetRandomNumber(int min, int max)
    {
        System.Random rnd = new System.Random();
        var value = rnd.Next(min, max);
        return value;
    }
}
