using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableItem : MonoBehaviour
{
    public bool hasCurrentBelt = false;
    public enum ItemType { BirdHead, BirdBody, Battery };
    public ItemType itemType;

}
