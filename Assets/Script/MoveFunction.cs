using System;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class MoveFunction : MonoBehaviour
    {
        [SerializeField] private float radius = 5;
        [SerializeField] private Transform self;
        [SerializeField] private Transform target;
        public NavMeshAgent agent;
        private double distance = 1d;

        // Start is called before the first frame update
        void Start()
        {
    
        }

        // Update is called once per frame
        void Update()
        {
            distance = Math.Sqrt((Math.Pow(self.position.x - target.position.x, 2)) +
                                 (Math.Pow(self.position.y - target.position.y, 2)) +
                                 (Math.Pow(self.position.z - target.position.z, 2)));
                         

            if (radius >= distance)
            {
                agent.SetDestination(target.position);
            }

        }

    }
}
