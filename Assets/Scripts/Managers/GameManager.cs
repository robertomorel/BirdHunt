using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    AudioSource audioSource;

    public AudioClip[] clips;

    public int score;

    bool isRobot = true;

    [SerializeField]
    private GameObject _bird;                     // -- Referência ao GO do bird

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SpawNewBirds();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawNewBirds()
    {
        InvokeRepeating("SpawNewBird", 0.3f, 10.0f);
    }

    void SpawNewBird()
    {
        isRobot = !isRobot;

        // -- Instancia um novo bird
        GameObject newBird = Instantiate(_bird);

        // -- Faz o bird ser filho do Terrain
        newBird.transform.parent = GameObject.Find("Terrain").transform;

        // -- Escala novo bird
        newBird.transform.localScale = new Vector3(10f, 10f, 10f);

        // -- Posição inicial randomica
        Vector3 temp;
        temp.x = Random.Range(3.54f, 6.93f);
        temp.y = Random.Range(0.804f, 3.783f);
        temp.z = Random.Range(3.8f, 6.64f);
        newBird.transform.position = temp;

        SetBirdParams(newBird);
    }

    void SetBirdParams(GameObject bird) 
    {
        BirdController controller = bird.GetComponent<BirdController>();
        controller.isRobot = isRobot;
        controller.level = isRobot ? Random.Range(1, 5) : 1;
        controller.Begin();
        Debug.Log("Surgiu um novo pássaro com o nível " + controller.level + "!!!");
    }

}