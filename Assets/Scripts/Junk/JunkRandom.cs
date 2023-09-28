using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : MyUpdateMonoBehaviour
{
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = GetComponent<JunkController>();
        Debug.Log(transform.name + ": Load JunkController", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkController.SpawnPoints.GetRandom();
        Vector3 position = ranPoint.position;
        Quaternion rotation = transform.rotation;
        Transform obj = this.junkController.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, position, rotation);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
