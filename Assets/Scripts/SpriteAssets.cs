using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssets : MonoBehaviour
{
    [SerializeField]
    private Sprite original;
    [SerializeField]
    private Sprite mayOutfit;
    [SerializeField]
    private Sprite wallyOutfit;

    public static SpriteAssets i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public Sprite Original
    {
        get => original;
    }

    public Sprite MayOutfit
    {
        get => mayOutfit;
    }

    public Sprite WallyOutfit
    {
        get => wallyOutfit;
    }
}
