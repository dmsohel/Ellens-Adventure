using UnityEngine;
public class TransporterControllerUpwards : MonoBehaviour
{
    [SerializeField] float Speed = 4;
    [SerializeField] float vertical = 4;


    void Update()
    {
        PlatformMovement();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("UpDownTrigger"))
        {
            vertical = -vertical;
        }

    }

    private void PlatformMovement()
    {
        Vector3 position = transform.position;
        position.y += vertical * Speed * Time.deltaTime;
        transform.position = position;
    }
}
