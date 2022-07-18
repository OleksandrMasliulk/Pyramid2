using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveSanity
{
    public int MaxSanity { get; }
    public void ModifySanity(int amount);
}
