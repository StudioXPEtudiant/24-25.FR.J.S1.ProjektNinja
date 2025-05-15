using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -5f);
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 lookAtOffset = new Vector3(0f, 1f, 0f);
    [SerializeField] private LayerMask obstacleMask; // Définis les murs à éviter

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        // Raycast depuis le joueur vers la position désirée de la caméra
        Vector3 direction = desiredPosition - target.position;
        float distance = direction.magnitude;

        if (Physics.Raycast(target.position, direction.normalized, out RaycastHit hit, distance, obstacleMask))
        {
            // Reculer la caméra juste avant l’obstacle
            desiredPosition = hit.point - direction.normalized * 0.3f;
        }

        // Mouvement fluide
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Regarder le joueur
        transform.LookAt(target.position + lookAtOffset);
    }
}