using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Material material;
    public float offsetSpeed = 0.3f;

    private void Update()
    {
        transform.position = Vector3.forward * player.transform.position.z;
        material.SetVector("Vector2_46626D1C", new Vector2(0, -transform.position.z * offsetSpeed));
    }
}
