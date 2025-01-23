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
        
        // Variables and Stats
        [SerializeField] private float speed = 15f;
        
        Vector3 temp = Vector3.zero;
        private string Axis = "z";
        
        
        // Dash variables
        [SerializeField] private float dashTimer = 2f;
        [SerializeField] private float dashPower = 5f;
        [SerializeField] private float dashCooldown = 15f;
        
        private bool CanDash = true;
        private float DHTR;
        private float DHCD;

        // Speed Boost variables
        [SerializeField] private float SpeedBoostTimer = 4f;
        [SerializeField] private float SpeedBoostCooldown = 15f;
        [SerializeField] private float SpeedBoostValue = 10f;

        private bool CanSpeedBoost = true;
        private float SBTR;
        private float SBCD;
        

        
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            temp = Vector3.zero;
            Axis = "z";
            
            // Player movements
            if (Input.GetKey(KeyCode.W))
            {
                temp.x=1;
                Axis = "z";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                temp.x=-1;
                Axis = "s";
            }
        
            if (Input.GetKey(KeyCode.A))
            {
                temp.z=1;
                Axis = "q";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                temp.z=-1;
                Axis = "d";
            }

            pos.position += temp * (Time.deltaTime * speed);
            
            //Dash Timer
            if (DHTR > 0)
            {
                DHTR -= Time.deltaTime;
            }

            if (DHTR < 0)
            {
                DHTR = 0;
                
            }
            
            //Dash Cooldown 
            if (DHCD > 0)
            {
                DHCD -= Time.deltaTime;
            }

            if (DHCD < 0)
            {
                DHCD = 0;
                CanDash = true;
            }
            
            // Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && (CanDash == true) && (DHCD == 0))
            {
                DHTR = dashTimer;
                CanDash = false;
                playerRb.useGravity = false;
                if (Axis == "z")
                {
                    playerRb.velocity = new Vector3(pos.localScale.x * dashPower, 0f, 0f);
                }
                else if (Axis == "s")
                {
                    playerRb.velocity = new Vector3(pos.localScale.x * -dashPower, 0f,0f );
                }
                else if (Axis == "d")
                {
                    playerRb.velocity = new Vector3(0f, 0f, pos.localScale.z * -dashPower);
                }
                else if (Axis == "q")
                {
                    playerRb.velocity = new Vector3(0f, 0f, pos.localScale.z * dashPower);
                }
            }
            else if ((DHTR == 0) && (CanDash == false))
            {
                DHCD = dashCooldown;
                playerRb.useGravity = true;
                playerRb.velocity = Vector3.zero;
                CanDash = true;
            }
            
            
            
            //SpeedBoost Timer
            if (SBTR > 0)
            {
                SBTR -= Time.deltaTime;
            }

            if (SBTR < 0)
            {
                SBTR = 0;
                
            }

            
            //SpeedBoost Cooldown 
            if (SBCD > 0)
            {
                SBCD -= Time.deltaTime;
            }

            if (SBCD < 0)
            {
                SBCD = 0;
                
            }
            
            // SpeedBoost
            if (Input.GetKeyDown(KeyCode.G) && (CanSpeedBoost == true) && (SBCD == 0))
            {
                SBTR = SpeedBoostTimer;
                CanSpeedBoost = false;
                speed += SpeedBoostValue;
            }
            else if ((SBTR == 0) && (CanSpeedBoost == false))
            {
                    SBCD = SpeedBoostCooldown;
                    speed -= SpeedBoostValue;
                    CanSpeedBoost = true;
            }
            
        }
    }
}
