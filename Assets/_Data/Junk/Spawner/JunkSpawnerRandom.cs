using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : MyUpdateMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] protected JunkSpawnerController junkSpawnerController;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    protected virtual void LoadJunkController()
    {
        if (this.junkSpawnerController != null) return;
        this.junkSpawnerController = GetComponent<JunkSpawnerController>();
        Debug.Log(transform.name + ": Load JunkSpawnerController", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform ranPoint = this.junkSpawnerController.SpawnPoints.GetRandom();
        Vector3 position = ranPoint.position;
        Quaternion rotation = transform.rotation;

        Transform prefab = this.junkSpawnerController.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerController.JunkSpawner.Spawn(prefab, position, rotation);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerController.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
