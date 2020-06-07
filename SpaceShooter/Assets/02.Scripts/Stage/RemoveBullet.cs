﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "BULLET")
        {
            ShowEffecft(coll);
            //Destroy(coll.gameObject);
            coll.gameObject.SetActive(false);
        }
    }

    private void ShowEffecft(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);

        GameObject spark = Instantiate(sparkEffect, contact.point+ (-contact.normal*0.05f), rot);
        spark.transform.SetParent(this.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
