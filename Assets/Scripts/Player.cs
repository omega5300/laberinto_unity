using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Fuerza;
    private Vector3 mivector;
    private Rigidbody Rb;
    private AudioSource AudioMaster;
    public AudioClip AudioCoin;

    public Text txtCoins;
    public float Coins;
    public Text txtTime;
    private float TimeValue;
    private Scene EscenaActual;

    // Start is called before the first frame update
    void Start()
    {
        TimeValue = 30f;
        EscenaActual = SceneManager.GetActiveScene();
        AudioMaster = this.GetComponent<AudioSource>();
        Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeValue = TimeValue - Time.deltaTime;

        if (TimeValue <= 0)
        {
            TimeValue = 0.7f;
            SceneManager.LoadScene(EscenaActual.name);
        }

        txtTime.text = "Tiempo: "+TimeValue.ToString ("F0");

        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");
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
            Coins = Coins+1;
            TimeValue = TimeValue + 3f;
            txtCoins.text = "Score: "+Coins.ToString("F0");
            AudioMaster.PlayOneShot(AudioCoin);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(1);
        }

        if (other.gameObject.tag == "Finish")
        {
            if (EscenaActual.name == "Lab1")
            {
                SceneManager.LoadScene("Lab2");
            }
            else
            {
                SceneManager.LoadScene("Lab1");
            }
        }

        if (other.gameObject.tag == "Damage")
        {
            SceneManager.LoadScene (EscenaActual.name);
        }

    }

}
