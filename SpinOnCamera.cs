using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // Ссылка на Transform игрока.  Перетащите игрока из Hierarchy в это поле в Inspector.

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }
    }
}