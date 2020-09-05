using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("CARGANDO MAPAS...");
            HashSet<Mapa> aux = persistenciaMapas.CargarMapas();
            print("El total de mapas es de: "+ aux.Count);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            print("testing hashmap");
            HashSet<Mapa> aux = new HashSet<Mapa>();
            char[,] a= new char[2,2];
           /* a[0, 0] = 'a';
            a[0, 1] = 'b';
            a[1, 1] = 'c';
            a[1, 0] = 'd';
            byte[] b = new byte[2];
            b[0] = 23;
            b[1] = 4;*/
            Mapa m = new Mapa(null, null, "Bosque", TypeOfLand.FOREST);
            Mapa n = new Mapa(null, null, "Bosque", TypeOfLand.FOREST);
            print(m.Equals(n));
            aux.Add(m);
            aux.Add(n);
            foreach (Mapa q in aux)
            {
                print(q.getNombre());
            }
            print("El total de mapas es de: " + aux.Count);
        } 
    }
}
