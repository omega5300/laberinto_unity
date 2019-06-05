using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject Player;
    private Vector3 POSINI;

    // Start is called before the first frame update
    void Start()
    {
        POSINI =this.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position + POSINI;
    }
}
