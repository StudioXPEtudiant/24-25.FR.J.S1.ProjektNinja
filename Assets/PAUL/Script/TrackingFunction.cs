using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;  // Ajouté pour l'utilisation d'IEnumerator

namespace Script
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class TrackingFunction : MonoBehaviour
    {
        [SerializeField] private float radius = 5f;  // Rayon d'activation pour suivre
        [SerializeField] private Transform target;   // Joueur à suivre
        private NavMeshAgent agent;
        private Collider targetCollider; // Collider du joueur

        void Awake()
        {
            // On s'assure qu'un NavMeshAgent est attaché à cet objet
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("Le NavMeshAgent n'est pas attaché à cet objet !", this);
                return; // Arrête l'exécution si l'agent n'est pas trouvé
            }

            // Si un Rigidbody est attaché, on le met en Kinematic pour éviter les conflits de physique
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;  // Rend l'objet non affecté par la physique
            }

            // Récupérer le Collider du joueur (target)
            if (target != null)
            {
                targetCollider = target.GetComponent<Collider>();
            }
        }

        void Start()
        {
            // Si un Collider du joueur est trouvé, on ignore les collisions entre l'objet traqueur et le joueur
            if (targetCollider != null)
            {
                Collider thisCollider = GetComponent<Collider>();
                if (thisCollider != null)
                {
                    Physics.IgnoreCollision(thisCollider, targetCollider, true); // Ignore la collision
                }
            }
        }

        void Update()
        {
            // Vérifier si target est assigné
            if (target == null)
            {
                Debug.LogWarning("Target (le joueur) n'est pas assigné dans l'inspecteur !");
                return;
            }

            // Vérification de la distance entre l'objet et le joueur
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= radius)
            {
                // Si l'agent quitte le NavMesh, on le replace à la position du joueur
                if (!agent.isOnNavMesh)
                {
                    agent.Warp(target.position);  // Ramène l'agent sur le NavMesh
                }

                // Donne la destination à l'agent
                agent.SetDestination(target.position);
            }
        }

        // Gérer les collisions pour éviter des comportements anormaux
        void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(StopTrackingTemporarily());
        }

        // Arrêter temporairement le suivi après une collision pour éviter le bug
        IEnumerator StopTrackingTemporarily()
        {
            agent.isStopped = true;
            yield return new WaitForSeconds(0.5f); // Pause de 0.5 seconde
            agent.isStopped = false;
        }
    }
}