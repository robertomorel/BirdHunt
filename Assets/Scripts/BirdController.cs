using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private GameObject _targetFocus;                         // Guarda o GO que será usado como alvo de movimentação

    public Material birdMaterial;                            // Referência à renderização do bird
    public Material[] robotBirdMaterial;                     // Referência à renderização do bird

    private GameManager _gameManager;                          // Referência ao script GameManager 
    public Bird bird;

    public ParticleSystem explosionParticles;         // Reference to the particles that will play on explosion.

    // -- Características do Bird
    [HideInInspector] public int level;
    [HideInInspector] public float speed;
    [HideInInspector] public bool isRobot;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _targetFocus = GameObject.Find("Target");
    }

    public void Begin()
    {
        speed = Random.Range(0.5f, 1.8f);
        bird = new Bird(isRobot, level, speed);
        bird.Setup();
        bird.instance = this;

        Renderer renderer = GetComponentInChildren<Renderer>();

        // -- Os birds normais sempre serão destruídos com apenas um tiro de qualquer arma
        if (!bird.isRobot)
        {
            renderer.material = birdMaterial;
        }
        else
        {
            renderer.material = robotBirdMaterial[bird.level - 1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // -- Calcula a distância entre o bird e o alvo
        Vector3 target = _targetFocus.transform.position - this.transform.position;

        // -- Se distância em linha reta entre os dois vetores for menor que 1...
        if (target.magnitude < 1)
        {
            // -- Move target para nova calculada direção
            TargetController.instance.MoveTarget();
            //_targetFocus.SendMessage("MoveTarget");
        }

        // -- Faz com que o bird sempre olhe para o target
        transform.LookAt(_targetFocus.transform);

        // -- Setta velocidade randômica 

        // -- Move o bird até o target 
        transform.Translate(0, 0, speed * Time.deltaTime);

        if (bird.IsDead())
        {
            /* 
                A bala será destruída, portanto, para que a partícula e o audio sejam ativados,
                o parentesco deve ser quebrado.
            */
            explosionParticles.transform.parent = null;

            // Play the particle system.
            explosionParticles.Play();

            // Once the particles have finished, destroy the gameobject they are on.
            //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
            ParticleSystem.MainModule mainModule = explosionParticles.main;
            Destroy(explosionParticles.gameObject, mainModule.duration);

            _gameManager.score += bird.level * 10;
            Debug.Log("Score Updated: " + _gameManager.score + "!!!");

            Destroy(this.gameObject);
        }
    }

}