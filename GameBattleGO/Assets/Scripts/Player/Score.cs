using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
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
    public int kills { get; set; }
    public double damage { get; set; }
    public double collectItems { get; set; }
    public double damageProduced { get; set; }
    public double scoreDestruyingObjects { get; set; }
    public double finalScore { get; set; }
}
