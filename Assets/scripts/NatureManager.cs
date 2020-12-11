using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureManager : MonoBehaviour
{
    public GameObject[] natureObjects;
    public Vector3 treeOffset;
    public int numOfTrees;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
        Random rnd = new Random();
        List<int> samples = new List<int>();
        for (int i = 0; i < numOfTrees; i++)
        {
            while (true)
            {
                bool taken = false;
                int newSample = Random.Range(0, nodes.Length);
                foreach (int sample in samples)
                {
                    if (sample == newSample) { taken = true; }
                }
                if (!taken)
                {
                    samples.Add(newSample);
                    break;
                }
            }
        }

        for (int i = 0; i < nodes.Length; i++)
        {
            foreach (int sample in samples)
            {
                if (sample == i)
                {
                    int natureObject = Random.Range(0, natureObjects.Length);
                    GameObject newTree = Instantiate(natureObjects[natureObject], nodes[i].transform.position + treeOffset, nodes[i].transform.rotation);
                    nodes[i].GetComponent<Node>().nature = newTree;
                }
            }
        }
    }
}
