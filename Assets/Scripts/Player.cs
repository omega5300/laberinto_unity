using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Fuerza;
    private Vector3 mivector;
    private Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float H= Input.GetAxis("Horizontal");
        float V= Input.GetAxis("Vertical");
        mivector = new Vector3(H, 0, V);
        Rb.AddForce(mivector * Fuerza * Time.deltaTime);
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
        }
    }

}
