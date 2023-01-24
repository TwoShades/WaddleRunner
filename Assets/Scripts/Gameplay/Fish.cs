﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PickupFish();
    }

    private void PickupFish()
    {
        //increment the fish count

        //increment the score

        //play sfx

        //tigger animation
        anim.SetTrigger("Pickup");
        GameStats.Instance.CollectFish();
    }

    public void OnShowChunk()
    {
        anim?.SetTrigger("Idle");
    }
}
