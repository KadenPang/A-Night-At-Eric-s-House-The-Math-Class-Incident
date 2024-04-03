using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
  public Inventory inventory;
  private void Awake() {
    inventory = new Inventory(5);
  }
}
