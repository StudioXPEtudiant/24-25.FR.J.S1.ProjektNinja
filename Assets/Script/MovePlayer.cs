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
            GetDirection();
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

        void GetDirection()
        {
            string dirVert = "";
            string dirHorz = "";
            string dirTot = "";
            if (Input.GetKey(KeyCode.W))
            {
                dirVert = "N";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dirVert = "S";
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                dirHorz = "E";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dirHorz = "W";
            }
            
            if (dirVert == "N" && dirHorz == "") dirTot = "N";
            else if (dirVert == "N" && dirHorz == "E") dirTot = "N-E";
            else if (dirVert == "" && dirHorz == "E") dirTot = "E";
            else if (dirVert == "S" && dirHorz == "E") dirTot = "S-E";
            else if (dirVert == "S" && dirHorz == "") dirTot = "S";
            else if (dirVert == "S" && dirHorz == "W") dirTot = "S-W";
            else if (dirVert == "W" && dirHorz == "") dirTot = "W";
            else if (dirVert == "N" && dirHorz == "W") dirTot = "N-W";
        }
    }
}
