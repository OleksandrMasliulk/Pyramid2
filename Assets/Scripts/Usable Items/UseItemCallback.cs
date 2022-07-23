using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItemCallback
{
    public enum ResultType
    {
        Success,
        Failed
    }
    
    public ResultType Result { get; private set; }

    public UseItemCallback(ResultType result)
    {
        Result = result;
    }
}
