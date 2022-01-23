using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class da : MonoBehaviour{
    [SerializeField] private Tilemap kappa;
    private TileBase a;
    void Start() {
        a = kappa.GetTile(new Vector3Int(4, -4, 0));
        
        print(a.name);
    }
    
}
