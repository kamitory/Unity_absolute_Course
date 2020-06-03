using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem cartridge;
    public Transform firePos;
    private ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
    }

    private void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        cartridge.Play();
        muzzleFlash.Play();
    }
}
