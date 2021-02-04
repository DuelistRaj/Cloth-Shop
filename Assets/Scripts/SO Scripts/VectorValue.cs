using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    public Vector2 initialValue;
    public float spriteDirection;
    public int dollarAmount;

    public List<Sprite> walkDownSprites;
    public List<Sprite> walkUpSprites;
    public List<Sprite> walkLeftSprites;
    public List<Sprite> walkRightSprites;
}
