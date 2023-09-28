using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : MyUpdateMonoBehaviour
{
    [SerializeField] protected JunkController junkController;
    public JunkController JunkController { get { return junkController; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log(transform.name + ": Load JunkController", gameObject);
    }
}
