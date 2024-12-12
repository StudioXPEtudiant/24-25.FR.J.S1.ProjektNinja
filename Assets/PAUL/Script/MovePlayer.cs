using UnityEngine;

namespace Script
{
    public class MovePlayer : MonoBehaviour
    {
    
        [SerializeField] private Transform pos;
        [SerializeField] private float speed = 1;
        
        Vector3 temp = Vector3.zero;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            temp = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                temp.x=1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                temp.x=-1;
            }
        
            if (Input.GetKey(KeyCode.A))
            {
                temp.z=1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                temp.z=-1;
            }

            pos.position += temp * (Time.deltaTime * speed);
        }

        
    }
}
