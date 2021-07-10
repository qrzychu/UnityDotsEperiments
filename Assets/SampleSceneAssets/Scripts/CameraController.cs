using System.Text;
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

    [SerializeField] public bool allowMousePan = false;
    
    public void Update()
    {
        float deltaTime = Time.deltaTime;
      
        Vector3 position = transform.position;

        bool mouseAtUpperBorder = allowMousePan && Input.mousePosition.y >= Screen.height - panBorder;
        bool mouseAtLeftBorder  = allowMousePan && Input.mousePosition.x <= panBorder;
        bool mouseAtLowerBorder = allowMousePan && Input.mousePosition.y <= panBorder;
        bool mouseAtRightBorder = allowMousePan && Input.mousePosition.x >= Screen.width - panBorder;

        
        if(Input.GetKey(UpKey) || mouseAtUpperBorder)
        {
            position.z += panSpeed * deltaTime;
        }

        if(Input.GetKey(DownKey) || mouseAtLowerBorder)
        {
            position.z -= panSpeed * deltaTime;
        }

        if(Input.GetKey(LeftKey) || mouseAtLeftBorder)
        {
            position.x -= panSpeed * deltaTime;
        }

        if(Input.GetKey(RightKey) || mouseAtRightBorder)
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
