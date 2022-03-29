using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int parts;

    public int Parts { get => parts; set => parts = value; }
}
