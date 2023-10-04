using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;        
        Debug.Log(transform.name + ": Load Collider", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
        this._rigibody.isKinematic = true;
        Debug.Log(transform.name + ": Load Rigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //if (other.transform.parent == this.bulletController.Shooter) return;

        this.bulletController.DamageSender.Send(other.transform);
        //this.CreateImpactFX(other);
    }
    /*
    protected virtual void CreateImpactFX(Collider other)
    {
        string fxName = this.GetImpactFX();

        Vector3 hitPosition = other.transform.position;
        Quaternion hitRotation = other.transform.rotation;
        Transform fxImpact =  FXSpawner.Instance.Spawn(fxName, hitPosition, hitRotation);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impactOne;
    }
    */
}
