using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private GameObject _targetFocus;                         // Guarda o GO que será usado como alvo de movimentação

    [SerializeField] private float _speed;                   // Referência à velocidade de movimentação do bird

    [HideInInspector] public Renderer[] robotBirdRenderer;   // Referência à renderização do bird
    //[HideInInspector]
    public bool isRobot;                                     // Para saber se o bird é um robô ou real
    [HideInInspector] public int totalLife;                  // Número total de life
    [HideInInspector] public int actLife;                    // Life atual
    [HideInInspector] public int level;                      // Level do bird

    public Material birdMaterial;                            // Referência à renderização do bird
    public Material[] robotBirdMaterial;                     // Referência à renderização do bird

    public GameManager gameManager;                          // Referência ao script GameManager  

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _targetFocus = GameObject.Find("Target");
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        // -- Calcula a distância entre o bird e o alvo
        Vector3 target = _targetFocus.transform.position - this.transform.position;
        //Debug.Log(target.magnitude); // -- Distância do bird ao alvo

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
        _speed = Random.Range(0.1f, 0.8f);
        // -- Move o bird até o target 
        transform.Translate(0, 0, _speed * Time.deltaTime);

    }

    public void Setup()
    {
        switch (level)
        {
            case 1:
                totalLife = 10;
                break;
            case 2:
                totalLife = 20;
                break;
            case 3:
                totalLife = 30;
                break;
            case 4:
                totalLife = 40;
                break;
            case 5:
                totalLife = 50;
                break;
            case 6:
                totalLife = 100;
                break;
            default:
                totalLife = 10;
                break;
        }

        actLife = totalLife;

        Renderer renderer = GetComponentInChildren<Renderer>();

        // -- Os birds normais sempre serão destruídos com apenas um tiro de qualquer arma
        if (!isRobot)
        {
            totalLife = 10;
            renderer.material = birdMaterial;
        } else
        {
            renderer.material = robotBirdMaterial[level - 1];
        }

    }

    public void Hit(int hitStrength)
    {
        actLife -= hitStrength;
        if (actLife < 0)
        {
            actLife = 0;
        }

        if (isRobot) {
            gameManager.score += hitStrength;
        } else
        {
            gameManager.score -= hitStrength;
        }   

    }

    public bool IsDead()
    {
        return (actLife == 0) ? true : false;
    }
}
