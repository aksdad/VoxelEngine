using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
class Vector2Comparer : IComparer<Vector2>
{
    public int Compare(Vector2 a, Vector2 b)
    {
        if (a.y < b.y)
            return -1;
        if (a.y == b.y)
        {
            if (a.x == b.x)
                return 0;
            if (a.x < b.x)
                return -1;
        }
        return 1;
    }
}