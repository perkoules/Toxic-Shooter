using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbGreen : MonoBehaviour
{
    public Player player;
    private void OnTriggerStay2D(Collider2D other)
    {        
        if (other.CompareTag("Green"))
        {
            if (Input.GetMouseButton(1))
            {
                player.GreenAbsorbed(other.gameObject);
            }
        }
    }
}
