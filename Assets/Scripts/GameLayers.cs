using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField]
    private LayerMask solidObjectsLayer;
    [SerializeField]
    private LayerMask interactablesLayer;

    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer
    {
        get => solidObjectsLayer;
    }

    public LayerMask InteractablesLayer
    {
        get => interactablesLayer;
    }
}
