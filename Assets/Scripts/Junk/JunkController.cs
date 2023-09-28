using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : MyUpdateMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get { return model; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": Load Model", gameObject);
    }
}
