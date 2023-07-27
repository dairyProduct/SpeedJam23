using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for actually spawning trees.
/// Prototype is a lil messy but gets the job done. Currently tightly coupled to TreeInfo
/// </summary>
public class SpawnTree : MonoBehaviour
{
    [Tooltip ("What gameobject to spawn as the 'tree'")]
    public GameObject treeToSpawn;
    [Tooltip ("Half of the height of the tree object, to offset when spawning")]
    public float treeHeightOffset;

    Vector3 SpawnLocation = Vector3.zero;
    bool spawnedAtLocation = false;
    TreeInfo activeTree;
    public Camera myCam; //Again coupled without a controller since this is a prototype
    [SerializeField]
    [Tooltip("How far and at what angle the camera will sit from the active tree")]
    Vector3 cameraOffset;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnATree();
        }
        if (activeTree != null) //this is currently faulty, as we haven't actually moved the spawnLocation but we reset the bool. TODO
        {
            SetSpawnLocation(activeTree.GetSpawnLocation());
        }

        myCam.transform.position = SpawnLocation + cameraOffset; //This looks funky since the offset stays the same even as the "tree" scales. TODO

    }


    /// <summary>
    /// Sets where the next spawnLocation should be. It also resets our spawner so we can spawn a new tree
    /// </summary>
    /// <param name="spawnLocation"></param>
    public void SetSpawnLocation(Vector3 spawnLocation)
    {
        SpawnLocation = spawnLocation;
        spawnedAtLocation = false; 
    }


    /// <summary>
    /// Place our treeObject at the offset
    /// </summary>
    public void SpawnATree()
    {
        if (!spawnedAtLocation)
        {
            if (activeTree != null)
            {
                activeTree.SetAsActive(false);
            }

            activeTree = Instantiate(treeToSpawn, SpawnLocation + new Vector3(0, treeHeightOffset, 0), Quaternion.identity).GetComponent<TreeInfo>();
            activeTree.SetAsActive(true);
            spawnedAtLocation = true;
        }
    }


}
