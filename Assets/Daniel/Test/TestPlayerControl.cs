using Unity.VisualScripting;
using UnityEngine;

public class TestPlayerControl : MonoBehaviour
{
    public Canvas ManagerCanvas;
    public float moveSpeed = 5f;
    public bool onCommandManager;


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

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Command"))
        {
            onCommandManager = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Command"))
        {
            onCommandManager = false;
        }
    }

}