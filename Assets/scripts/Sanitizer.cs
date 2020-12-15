using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanitizer : MonoBehaviour
{

    //private Animator animations;
    public GameObject sanitiser;
    private float fireCountdown = 5f;
    private float sanitiserCountdown = 5f;
    public ParticleSystem sprayEffect;
    public Vector3 placementOffset;

    // Start is called before the first frame update
    void Start()
    {
        //animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sanitiser.activeSelf)
        {
            if (sanitiserCountdown <= 0f)
            {
                sanitiser.SetActive(false);
            }
            sanitiserCountdown -= Time.deltaTime;
        }
        if (RoundSystem.roundOngoing)
        {
            if (fireCountdown <= 0f)
            {
                sprayEffect.Play();
                Squeeze();
                fireCountdown = 10f;
            }
            else
            {
                //animations.SetBool("isSqueezing", false);
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void Squeeze()
    {
        //animations.SetBool("isSqueezing", true);
        sanitiser.SetActive(true);
    }
}
