using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Fuerza;
    private Vector3 mivector;
    private Rigidbody Rb;
    private AudioSource AudioMaster;
    public AudioClip AudioCoin;

    // Start is called before the first frame update
    void Start()
    {
        AudioMaster = this.GetComponent<AudioSource> ();
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
            AudioMaster.PlayOneShot(AudioCoin);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Finish")
        {
            /*
             * la escena se pone tanto el valor numerico o el nombre de la escena
             * ejemplos:
             * 
             * SceneManager.LoadScene(1);
             * 
             * o           
             * 
             * SceneManager.LoadScene("lab2");           
             * 
             */

            SceneManager.LoadScene(1);
        }

    }

}
