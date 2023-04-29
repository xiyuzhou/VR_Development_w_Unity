using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillTarget : MonoBehaviour
{
    private GameObject target;
    public float timeToSelect = 5f;
    [SerializeField]
    private ParticleSystem deathParticlePrefab;
    Transform camera;
    private float countDown;
    public TMP_Text scoreText;
    public int score = 0;


    void Start()
    {
        camera = Camera.main.transform;
        countDown = timeToSelect;
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Target")
            {
                target = hit.collider.gameObject;
                isHitting = true;
            }
        }

        if (isHitting)
        {
            if (target != null)
            {
                OnSelect(target);
            }
            var cache = target.GetComponent<HealthBar>();
            if (cache != null)
            {
                if (cache.TakeDamage(20f * timeToSelect * Time.deltaTime))
                {
                    var deathparticle = Instantiate(deathParticlePrefab, target.transform.position, target.transform.rotation);
                    Destroy(deathparticle, 4f);
                    //Destroy(target.gameObject);
                    SetRandomPosition();
                    cache.currentHealth = cache.maxHealth;
                    cache.healthBar.value = 1;
                    score += 1;
                    scoreText.text = "Score: " + score;
                }
            }
        }
        else
        {
            if (target != null)
            {
                OnDeselect(target);
            }
        }
    }

    void OnDeselect(GameObject selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null)
            outline.OutlineWidth = 0;
        var bobHeadSpeed = target.GetComponent<Bouncing>();
        if (bobHeadSpeed != null)
            bobHeadSpeed.onGaze = false;
    }

    void OnSelect(GameObject selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline != null)
            outline.OutlineWidth = 10;
        var bobHeadSpeed = target.GetComponent<Bouncing>();
        if (bobHeadSpeed != null)
            bobHeadSpeed.onGaze = true;
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }

}
