using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Bonus;
using UnityEngine;

public abstract class Bonus<T> : MonoBehaviour
{
    public abstract BonusType Type { get; }
    public abstract T BonusValue { get; }
}
