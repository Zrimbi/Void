using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBox : MonoBehaviour
{
    private BoxCollider bc;
    public Animator animator;
    private int timer = 0;
    private MeshRenderer meshRenderer;

    void Start()
    {
        bc = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            bc.isTrigger = true;
        }
        else
        {
            bc.isTrigger = false;
        }

        if (meshRenderer.enabled == false)
        {
            timer += 1;
        }
        if (timer / 40 > 10)
        {
            Destroy(gameObject); // Уничтожить себя при касании игрока.
        }
    }

    // Пример: Уничтожение объекта при столкновении.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Backpack[Random.Range(0,13)] += Random.Range(1,3);
            animator.Play("boom");
            meshRenderer.enabled = false;
            
        }
    }
}
