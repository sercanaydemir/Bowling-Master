using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookAt : MonoBehaviour
{
    [SerializeField] private Transform OnEnableLookAt;
    private void OnEnable()
    {
        transform.LookAt(OnEnableLookAt);
    }
}
