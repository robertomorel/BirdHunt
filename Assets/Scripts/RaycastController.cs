using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{

    public float maxDistanceRay = 100.0f;         // -- Distância máxima que a arma pode acertar um alvo   
    public static RaycastController instance;     // -- Referência para a instância ao próprio objeto
    public float fireRate = 1.6f;                 // -- Tempo de espera até o próximo tiro
    private bool nextShot = true;                 // -- Bool que verifica que o player já pode atirar

    AudioSource audioSource;                      // -- Referência ao componente de audio do Raycast
    public AudioClip[] clips;                     // -- Array de clips de audio

    [SerializeField]
    private GameObject _bird;                     // -- Referência ao GO do bird

    [SerializeField]
    private GameObject _explosion;                // -- Referência ao GO da explosão do bird

    private void Awake()
    {
        // -- Cria instância para o próprio objeto
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // -- Inicia corrotina para criação do pássaro 
        StartCoroutine(SpawNewBird());
        // -- Instancia componente de audio
        audioSource = GetComponent<AudioSource>();
    }

    /*
        Método para tocar o som numerado por parâmetro
    */
    public void PlaySound(int sound)
    {
        // -- Seleciona o clipe de audio
        audioSource.clip = clips[sound];
        // -- Toca o clipe de audio selecionado
        audioSource.Play();
    }

    public void Fire()
    {
        // -- Se o player puder atirar...
        if (nextShot)
        {
            // -- Chama corrotina de tiro
            StartCoroutine(TakeShot());
            // -- Setta variável que impede tiro seguido
            nextShot = false;
        }
    }

    private IEnumerator SpawNewBird()
    {
        // -- Espera 3s antes de executar o método
        yield return new WaitForSeconds(3.0f);

        // -- Instancia um novo bird
        GameObject newBird = Instantiate(_bird);

        // -- Faz o bird ser filho do Terrain
        newBird.transform.parent = GameObject.Find("Terrain").transform;

        // -- Escala novo bird
        newBird.transform.localScale = new Vector3(10f, 10f, 10f);

        // -- Posição inicial randomica
        Vector3 temp;
        temp.x = Random.Range(-0.163f, 0.198f);
        temp.y = Random.Range(0.128f, 0.441f);
        temp.z = Random.Range(-0.18f, 0.178f);
        newBird.transform.position = temp;

    }

    private IEnumerator TakeShot()
    {

        // -- toca som do tiro
        GunController.instance.Shot();

        // -- Cria um ray 
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // -- Inicia variável hit do tipo RaycastHit
        RaycastHit hit;

        // -- Diminui quantidade de tiros permitidos por round
        //GameManager.instance.shotsPerRound--;

        // -- Utiliza máscara para todos os elementos que estiverem no layer "Bird"
        int layerMask = LayerMask.GetMask("Bird");

        // -- Criar um raycast para verificar se algum elemento no layerMask foi atingido  
        if (Physics.Raycast(ray, out hit, maxDistanceRay, layerMask))
        {

            // -- Toma objeto atingido
            GameObject objHitted = hit.collider.gameObject;

            // -- Toma posição do objeto atingido
            Vector3 birdPosition = objHitted.transform.position;

            // -- Se o objeto atingido tiver a tag "Bird"...
            if (objHitted.tag == "Bird")
            {
                // -- Cria uma instância do efeito de fogo
                GameObject fire = Instantiate(_explosion, birdPosition, Quaternion.identity);

                // -- Toca o som na posição 1    
                PlaySound(1);

                // -- Destroi o objeto atingido     
                Destroy(objHitted);

                // -- Inicia corrotina para criação de novo pássaro     
                StartCoroutine(SpawNewBird());

            }

        }

        yield return new WaitForSeconds(fireRate);

        nextShot = true;

    }

}