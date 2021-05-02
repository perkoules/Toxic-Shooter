using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbGreen : MonoBehaviour
{
    public Player player;
    private bool isIn = false;
    private void OnTriggerStay2D(Collider2D other)
    {        
        if (other.CompareTag("Green"))
        {
            isIn = true;
            player.IsInsideGreen(isIn, other.gameObject);
        }
        else
        {
            isIn = false;
            player.IsInsideGreen(isIn, other.gameObject);
        }
    }
}
