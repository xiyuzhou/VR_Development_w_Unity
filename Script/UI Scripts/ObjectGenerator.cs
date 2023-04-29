using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public float floatStrength = 20f;

    public GameObject objectPrefab;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    public float minT = 1;
    public float maxT = 3;
    private float waitingTime;
    void Start()
    {
        waitingTime = Random.Range(minT, maxT);
    }

    void Update()
    {
        waitingTime -= Time.deltaTime;
        if (waitingTime <= 0)
        {
            GenerateObjects();
            waitingTime = Random.Range(minT, maxT);
        }
    }

    void GenerateObjects()
    {
        var x = Random.Range(minX, maxX);
        var z = Random.Range(minZ, maxZ);
        float k = Random.Range(1f, 3f);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit))
        {
            var a = Instantiate(objectPrefab, hit.point, Quaternion.identity);
            a.transform.localScale = new Vector3(k, k, k);
            Rigidbody rb = a.GetComponent<Rigidbody>();
            Vector3 force = Vector3.up * floatStrength;
            rb.AddForce(force);

            GameObject.Destroy(a, 20f);
            a = null;
        }
    }
}
