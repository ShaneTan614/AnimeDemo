using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float jumpForce = 1.0f;
    int Jumpcount = 0;
    public Animator PlayerAnim;
    public Rigidbody PlayerRb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, -180, 0);
            PlayerAnim.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            PlayerAnim.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerAnim.SetBool("isMove", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerAnim.SetBool("isMove", true);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            PlayerAnim.SetBool("isMove", false);
        }
        PlayerJump();




    }
    private void OncollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jumpcount = 0;

        }
    }
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jumpcount < 1)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Jumpcount++;

        }

    }
}


