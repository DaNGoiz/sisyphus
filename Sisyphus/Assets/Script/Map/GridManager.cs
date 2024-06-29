using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private const int scanRange = 60;
    private PlayerController player;
    //public Node[,] grid;
    Vector2 currentPosition = new Vector2();
    private void Awake()
    {
        //grid = new Node[scanRange, scanRange];
        player = GameObject.FindWithTag(TagName.player).GetComponent<PlayerController>();
    }
    //ÔÝÍ£¿ª·¢
    public IEnumerator Scan()
    {
        currentPosition.Set(0, 0);
        return null;
    }
}
