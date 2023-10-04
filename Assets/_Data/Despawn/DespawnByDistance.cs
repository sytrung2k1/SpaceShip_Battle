using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLinit = 70f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Camera mainCam;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + ": Load Camera");
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCam.transform.position);
        if(this.distance > disLinit) return true;
        return false;
    }
}
