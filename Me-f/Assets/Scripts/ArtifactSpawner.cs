using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSpawner : MonoBehaviour
{
    public GameObject[] artifactPrefabs;
    private HashSet<GameObject> items = new HashSet<GameObject>();
    public int numArtifacts = 3;
    public int shift = -2;

    void Start()
    {
        // Spawn artifacts
        SpawnArtifacts();
    }

    void SpawnArtifacts()
    {
        // Randomly spawn artifacts
        for (int i = 0; i < numArtifacts; i++)
        {
            int index = Random.Range(0, artifactPrefabs.Length);
            Vector3 artifactPos = new Vector3(transform.position.x + shift, transform.position.y, transform.position.z);
            GameObject artifact = Instantiate(artifactPrefabs[index], artifactPos, Quaternion.identity);
            artifact.transform.parent = transform;
            shift += 2;
        }
    }
}
