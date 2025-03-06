using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace PAUL.Script
{
    public class MovePlayer : MonoBehaviour
    {
        // Player
        [SerializeField] private Transform pos;
        [SerializeField] private Rigidbody playerRb;
        
        // Variables et stats
        [SerializeField] private float speed = 2f; // Vitesse normale ajustée
        [SerializeField] private float dashPower = 10f; // Puissance du dash
        [SerializeField] private float dashDuration = 0.2f; // Durée du dash
        [SerializeField] private float dashCooldown = 2f; // Cooldown du dash
        private bool isDashing = false;
        private bool canDash = true;
        private float dashTimeRemaining;
        private float dashCooldownRemaining;

        // Variables internes
        private Vector3 movementDirection = Vector3.zero;
        
        void Update()
        {
            movementDirection = Vector3.zero;

            // Déplacement avec ZQSD
            if (Input.GetKey(KeyCode.W)) movementDirection.x = 1;
            else if (Input.GetKey(KeyCode.S)) movementDirection.x = -1;

            if (Input.GetKey(KeyCode.A)) movementDirection.z = 1;
            else if (Input.GetKey(KeyCode.D)) movementDirection.z = -1;

            // Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartDash();
            }

            // Gestion du cooldown du dash
            if (dashCooldownRemaining > 0)
            {
                dashCooldownRemaining -= Time.deltaTime;
                if (dashCooldownRemaining <= 0) canDash = true;
            }
        }

        void FixedUpdate()
        {
            if (isDashing)
            {
                dashTimeRemaining -= Time.fixedDeltaTime;
                if (dashTimeRemaining <= 0)
                {
                    StopDash();
                }
            }
            else
            {
                ApplyMovement();
            }
        }

        private void ApplyMovement()
        {
            if (movementDirection != Vector3.zero)
            {
                Vector3 force = movementDirection.normalized * speed;
                playerRb.AddForce(force, ForceMode.VelocityChange);

                // Limiter la vitesse pour éviter l'accélération infinie
                Vector3 horizontalVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
                if (horizontalVelocity.magnitude > speed)
                {
                    horizontalVelocity = horizontalVelocity.normalized * speed;
                    playerRb.velocity = new Vector3(horizontalVelocity.x, playerRb.velocity.y, horizontalVelocity.z);
                }
            }
        }

        private void StartDash()
        {
            isDashing = true;
            canDash = false;
            dashTimeRemaining = dashDuration;
            dashCooldownRemaining = dashCooldown;

            // Appliquer la vélocité du dash dans la direction actuelle
            Vector3 dashVelocity = movementDirection.normalized * dashPower;
            playerRb.velocity = new Vector3(dashVelocity.x, playerRb.velocity.y, dashVelocity.z);
            playerRb.useGravity = false; // Désactive la gravité pour un dash plus fluide
        }

        private void StopDash()
        {
            isDashing = false;
            playerRb.useGravity = true; // Réactive la gravité après le dash
        }
    }
}