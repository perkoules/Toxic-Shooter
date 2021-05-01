using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbRed : MonoBehaviour
{
    public Player player;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Red"))
        {
            if (Input.GetMouseButton(1))
            {
                player.RedAbsorbed(other.gameObject);
            }
        }
    }
}
