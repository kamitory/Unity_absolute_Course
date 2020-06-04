﻿//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    public Mesh[] meshes;
    public Texture[] textures;

    private int hitCount = 0;
    private Rigidbody rb;
    private MeshFilter meshFilter;
    private MeshRenderer _renderer;
    private AudioSource _audio;

    public float expRadius = 10.0f;
    public AudioClip expSfx;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshFilter = GetComponent<MeshFilter>();

        _renderer = GetComponent<MeshRenderer>();
        _audio = GetComponent<AudioSource>();
        _renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("BULLET"))
        {
            if(++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    private void ExpBarrel()
    {
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2.0f);

        //Instantiate(expEffect, transform.position, Quaternion.identity);
        //rb.mass = 1.0f;
        //rb.AddForce(Vector3.up * 1000.0f);

        IndirectDamage(transform.position);

        int idx = Random.Range(0, meshes.Length);
        meshFilter.sharedMesh = meshes[idx];
        GetComponent<MeshCollider>().sharedMesh = meshes[idx];
        _audio.PlayOneShot(expSfx, 1.0f);
    }

    private void IndirectDamage(Vector3 pos)
    {
        Collider[] colls = Physics.OverlapSphere(pos, expRadius, 1 << 11);
        foreach(var coll in colls)
        {
            var _rb = coll.GetComponent<Rigidbody>();

            _rb.mass = 1.0f;
            _rb.AddExplosionForce(1200.0f, pos, expRadius, 1000.0f);
        }
    }
}
