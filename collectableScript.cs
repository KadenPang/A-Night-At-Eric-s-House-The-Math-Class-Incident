using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  public CollectableType type;
  
  private void onTrigger(Collider2D collision)
  {
    Player player = collision.GetComponent<Player>();
    if (player)
    {
      player.inventory.Add(type);
      Destroy(this.gameObject);
    }
  }
}

public enum CollectableType {
  NONE, KEY
}
