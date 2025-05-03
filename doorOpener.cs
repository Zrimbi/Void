using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    private Transform doorPetli;
    private bool isOpen = false;
    void Start()
    {
        doorPetli = GetComponent<Transform>();
    }

    void Update()
    {
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                if (isOpen == true && doorPetli.rotation.y < 230)
                {
                    doorPetli.rotation = Quaternion.Euler(new Vector3(0, 230));
                    Debug.Log(isOpen);
                }
                else if (isOpen == false && doorPetli.rotation.y > 90)
                {
                    doorPetli.rotation = Quaternion.Euler(new Vector3(0, 90));
                    Debug.Log(isOpen);
                }
                Debug.Log(0);
            }
        }
    }
}
