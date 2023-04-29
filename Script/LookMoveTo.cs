using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;
    private Transform camera;

    public Transform infoBubble;
    private Text infoText;
    void Start()
    {
        camera = Camera.main.transform;
        if (infoBubble != null)
        {
            infoText = GetComponentInChildren<Text>();
        }

    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;
        Debug.DrawRay(camera.position, camera.rotation *
        Vector3.forward * 100.0f);
        ray = new Ray(camera.position, camera.rotation *
        Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                if (infoBubble != null)
                {
                    infoText.text = "X:" + hit.point.x.ToString("F2") +
                    ", " +
                    "Z:" + hit.point.z.ToString("F2");
                    infoBubble.LookAt(camera.position);
                    infoBubble.Rotate(0, 180f, 0);
                }
                transform.position = hit.point;
            }
        }
    }
}