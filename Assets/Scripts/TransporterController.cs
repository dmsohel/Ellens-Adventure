using UnityEngine;
public class TransporterController : MonoBehaviour
{
    [SerializeField] float horizontal = 4;
    [SerializeField] float Speed = 4;

    void Update()
    {
        PlatformMovement();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SideWayTrigger"))
        {
            horizontal = -horizontal;
        }
        
    }

    private void PlatformMovement()
    {
        Vector3 position = transform.position;
        position.x += horizontal * Speed * Time.deltaTime;
        transform.position = position;
    }
    
}
