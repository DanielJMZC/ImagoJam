using UnityEngine;

public class DoorTransporter : MonoBehaviour
{
    public GameObject playerTP;
    public GameObject player;

    private bool nearDoor = false;

    void Update()
    {


        if (nearDoor && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Enter");

            player.transform.position = playerTP.transform.position;

            nearDoor = false;
        }
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nearDoor = false;
        }
    }
}
