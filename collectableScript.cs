using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  private void onTrigger(Collider2D collision)
  {
    Player player = collision.GetComponent<Player>();
    if (player)
    {
      player.numKey++;
      Destroy(this.gameObject);
    }
  }
}
