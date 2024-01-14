using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    private SlimeType slimeType;
    public SlimeType SlimeType => slimeType;

    public virtual void Setup()
    {

    }
}