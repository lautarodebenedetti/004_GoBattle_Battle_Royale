using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorParticulas : MonoBehaviour
{
    public ParticleSystem particulasNieve;
    public ParticleSystem particulasLluvia;
    public Camera camara;

    void Start()
    {
        desactivarParticulas(particulasNieve);
        desactivarParticulas(particulasLluvia);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateParticleRain();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ActivateParticleSnow();
        }
    }

    public void ActivateParticleRain()
    {
        desactivarParticulas(particulasNieve);
        //print("LLAMANDO A LA LLUVIA!");
        float duracion = 1.2F;
        float lerp = Mathf.PingPong(Time.time, duracion) / duracion; //tipo de transicion linea!
        Color colorInicio = Color.blue;
        Color colorFin = Color.gray;
        //RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorInicio, colorFin, lerp));        
        RenderSettings.skybox.SetColor("_Tint", colorFin);
        RenderSettings.fog = true;
        RenderSettings.ambientSkyColor = colorFin;
        camara.backgroundColor = colorFin;
        RenderSettings.ambientLight = colorFin;
        setParent(particulasLluvia);
        activarYdesactivarParticulas(particulasLluvia);
    }

    public void ActivateParticleSnow()
    {
        desactivarParticulas(particulasLluvia);
        RenderSettings.fog = false;
        //print("LLAMANDO A LA NIEVE!");
        setParent(particulasNieve);
        activarYdesactivarParticulas(particulasNieve);
    }

    void setParent(ParticleSystem particulas)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        //particulas.transform.parent = this.transform;

        //Display the parent's name in the console.
        //print("Parent del objeto: " + particulas.transform.parent.name);
    }


    void activarParticulas(ParticleSystem particulas)
    {
        var emision = particulas.emission;
        emision.enabled = true;
    }

    public void desactivarParticulas(ParticleSystem particulas)
    {
        var emision = particulas.emission;
        emision.enabled = false;
    }

    void activarYdesactivarParticulas(ParticleSystem particulas)
    {
        var emision = particulas.emission;
        if (emision.enabled)
        {
        //    print("DESACTIVANDO PARTICULAS");
            desactivarParticulas(particulas);
        }
        else
        {
        //    print("ACTIVANDO PARTICULAS");
            activarParticulas(particulas);
        }
    }
}
