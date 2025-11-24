using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * Vertical;

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(0, Horizontal * rotationSpeed * Time.deltaTime, 0);
    }
}
