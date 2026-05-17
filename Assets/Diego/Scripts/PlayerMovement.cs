using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Canvas ManagerCanvas;
    public float moveSpeed = 5f;

    public bool onCommandManager;
    public bool onFirCamp;

    public Animator animator;


    void Start()
    {
        onCommandManager = false;
        onFirCamp = false;

        ManagerCanvas.gameObject.SetActive(false);
    }


    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Movimiento
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        // Voltear sprite según dirección
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Animación correr
        animator.SetBool("isRunning", moveInput != 0);


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
        }
        else if (other.CompareTag("Fire"))
        {
            onFirCamp = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Command"))
        {
            onCommandManager = false;
        }
        else if (other.CompareTag("Fire"))
        {
            onFirCamp = false;
        }
    }
}