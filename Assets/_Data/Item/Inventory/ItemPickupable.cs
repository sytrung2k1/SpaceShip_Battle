using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickupable : MyUpdateMonoBehaviour
{
    [SerializeField] protected SphereCollider _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.1f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }
}
