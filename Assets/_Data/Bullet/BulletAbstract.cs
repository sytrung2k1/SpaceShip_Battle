using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MyUpdateMonoBehaviour
{
    [Header("Bullet Abtract")]
    [SerializeField] protected BulletController bulletController;
    public BulletController BulletController { get { return bulletController; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": Load BulletController", gameObject);
    }
}
