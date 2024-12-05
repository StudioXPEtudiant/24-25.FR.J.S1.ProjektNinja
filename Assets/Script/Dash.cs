using UnityEngine;

namespace Script
{
    public class Dash : MonoBehaviour
    {
        [SerializeField] private Transform living;
        [SerializeField] private int level = 1;
    
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
            Vector3 dash = Vector3.zero;
            if ((Input.GetKey(KeyCode.LeftShift)) && (living.position.x <= 0))
            {
                dash.x = 15;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && (living.position.x > 0))
            {
                dash.x = -15;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && (living.position.y > 0))
            {
                dash.y = 15;
            }
            else if ((Input.GetKey(KeyCode.LeftShift)) && (living.position.y < 0))
            {
                dash.y = -15;
            }

            living.position += dash * (level * Time.deltaTime);
        }   
    }
}
