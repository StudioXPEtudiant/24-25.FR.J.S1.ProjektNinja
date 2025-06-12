using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace PAUL.Script
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private Rigidbody playerRb;

        [SerializeField] private float speed = 2f;
        [SerializeField] private float dashPower = 10f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 2f;

        private bool isDashing = false;
        private bool canDash = true;
        private float dashTimeRemaining;
        private float dashCooldownRemaining;

        private Vector3 movementDirection = Vector3.zero;

        void Update()
        {
            movementDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W)) movementDirection.x = 1;
            else if (Input.GetKey(KeyCode.S)) movementDirection.x = -1;

            if (Input.GetKey(KeyCode.A)) movementDirection.z = 1;
            else if (Input.GetKey(KeyCode.D)) movementDirection.z = -1;

            // Faire tourner le joueur dans la direction du mouvement
            if (movementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection.normalized, Vector3.up);
                transform.rotation = targetRotation;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartDash();
            }

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

                Vector3 horizontalVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
                if (horizontalVelocity.magnitude > speed)
                {
                    horizontalVelocity = horizontalVelocity.normalized * speed;
                    playerRb.velocity = new Vector3(horizontalVelocity.x, playerRb.velocity.y, horizontalVelocity.z);
                }
            }
            else
            {
                // Freinage progressif pour supprimer la glissade
                Vector3 horizontalVelocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
                horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, 0.1f); // Ajuster 0.1f selon la rapidité du freinage
                playerRb.velocity = new Vector3(horizontalVelocity.x, playerRb.velocity.y, horizontalVelocity.z);
            }
        }

        private void StartDash()
        {
            isDashing = true;
            canDash = false;
            dashTimeRemaining = dashDuration;
            dashCooldownRemaining = dashCooldown;

            Vector3 dashVelocity = movementDirection.normalized * dashPower;
            playerRb.velocity = new Vector3(dashVelocity.x, playerRb.velocity.y, dashVelocity.z);
            playerRb.useGravity = false;
        }

        private void StopDash()
        {
            isDashing = false;
            playerRb.useGravity = true;
        }
    }
}