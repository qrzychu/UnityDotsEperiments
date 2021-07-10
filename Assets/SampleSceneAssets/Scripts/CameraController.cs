using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float panSpeed;
    [SerializeField] public int panBorder;

    [SerializeField] public KeyCode UpKey;
    [SerializeField] public KeyCode DownKey;
    [SerializeField] public KeyCode LeftKey;
    [SerializeField] public KeyCode RightKey;
    
    public void Update()
    {
        float deltaTime = Time.deltaTime;
      
        Vector3 position = transform.position;
        
        if(Input.GetKey(UpKey) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            position.z += panSpeed * deltaTime;
        }
        
        if(Input.GetKey(DownKey) || Input.mousePosition.y <= panBorder)
        {
            position.z -= panSpeed * deltaTime;
        }
        
        if(Input.GetKey(LeftKey) || Input.mousePosition.x <= panBorder)
        {
            position.x -= panSpeed * deltaTime;
        }
        
        if(Input.GetKey(RightKey) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            position.x += panSpeed * deltaTime;
        }

        transform.position = position;
    }
}
