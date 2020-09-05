using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int id { get; set; }
    public int referencePlayerId { get; set; }
    public double damage { get; set; }
    public double velocity { get; set; }
    public double range { get; set; }
    public double strengthGravity { get; set; }
    public TypeOfProjectile typeOfProjectile { get; set; }
    public GameObject object3D { get; set; }

}
