using UnityEngine;

public class ParadoCorrendo : MonoBehaviour
{
    private CharacterController controller;
    private Transform myCamera;
    private Animator animator;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        movement = myCamera.TransformDirection(movement);
        movement.y = 0;


        controller.Move(movement * Time.deltaTime * 5);
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 10);
        }

        animator.SetBool("Correndo", movement != Vector3.zero);
    }
}