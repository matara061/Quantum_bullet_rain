using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellSpawner : MonoBehaviour
{
    public int numer_of_columns;
    public float speed;
    public float speedAto;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    public float angle;
    public float delay;
   // public float gravity;
    public Material material;
    public float spin_speed;
    private float time;

    ParticleSystem.Particle[] nParticles;
    


    // colocar varios geradores de particulas em um objeto para ter diferentes tipos de ataques 

    public ParticleSystem system; 

    private void Awake()   
    {

           Summon();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;

        transform.rotation = Quaternion.Euler(0, 0, time * spin_speed); // rotaciona 
    }

    void Summon()
    {
        angle = 360f / numer_of_columns; // mudar esse 360 para fazer outros formatos 

        for (int i = 0; i < numer_of_columns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
           // system.Stop();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
           // mainModule.gravityModifier = gravity;// nao testado
            mainModule.startSize = 0.5f;
            mainModule.simulationSpeed = speedAto; // n testado
            mainModule.startSpeed = speed;
           // mainModule.startDelay = delay; // nao funciona, talvez criar outro script e desativar esse cod pelo tempo de delay
            mainModule.maxParticles = 10000;
           // mainModule.duration = 5f;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false; 

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite; // outros formatos sao legais tb
            forma.sprite = null;

            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.collidesWith = LayerMask.GetMask("Player");
            collision.lifetimeLoss = lifetime;
            collision.sendCollisionMessages = true;
        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", delay, firerate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);
        }
    }

    /*   private void LateUpdate()
       {
           InitializeIfNeeded();

           int numParticlesAlive = system.GetParticles(nParticles);

           for (int i = 0; i < numParticlesAlive; i++)
           {
               nParticles[i].velocity += Vector3.up * mDrift;
               nParticles[i].color = Color.blue;
           }

           system.SetParticles(nParticles, numParticlesAlive);
       }

       void InitializeIfNeeded()
       {
           if (system == null)
               system = GetComponent<ParticleSystem>();

           if (nParticles == null || nParticles.Length < system.main.maxParticles)
               nParticles = new ParticleSystem.Particle[system.main.maxParticles];
       }*/
}
