using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Canvas ManagerCanvas;
    public float moveSpeed = 5f;
    public bool onCommandManager;
    public bool onFirCamp;


    void Start()
    {
        onCommandManager = false;
        ManagerCanvas.gameObject.SetActive(false);
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && onCommandManager)
        {
            ManagerCanvas.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagerCanvas.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onFirCamp)
        {
            GlobalController.Instance.NextDay();
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Command"))
        {
            onCommandManager = true;
        } else if (other.CompareTag("Fire"))
        {
            onFirCamp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Command"))
        {
            onCommandManager = false;
        }else if (other.CompareTag("Fire"))
        {
            onFirCamp = false;
        }
    }

}
