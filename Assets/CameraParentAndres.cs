using UnityEngine;
 public class CameraParent : MonoBehaviour 
{
 [SerializeField] private string playerTag = "Player";
 private Transform _playerTransform;
 
void Start()
 {
 _playerTransform = GameObject.FindWithTag(playerTag).transform;
 _playerTransform.GetComponent<MarbleControl>().SetReferenceTransform(transform);
 }
void Update() 
{
 transform.position = _playerTransform.position; 
}
}
