using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float panSpeed = 50f;
    [SerializeField] public int panBorder = 10;
    [SerializeField] public float3 panLimit = new float3(50f, 50f, 50f);

    [SerializeField] public float scrollSpeed = 100f;

    [SerializeField] public KeyCode UpKey = KeyCode.W;
    [SerializeField] public KeyCode DownKey = KeyCode.S;
    [SerializeField] public KeyCode LeftKey = KeyCode.A;
    [SerializeField] public KeyCode RightKey = KeyCode.D;
    
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

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y += -scroll * scrollSpeed * 100f * deltaTime;

        position.x = Mathf.Clamp(position.x, -panLimit.x, panLimit.x);
        position.y = Mathf.Clamp(position.y, 0, panLimit.y);
        position.z = Mathf.Clamp(position.z, -panLimit.z, panLimit.z);

        transform.position = position;
    }
}
