using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{

    public float maxDistanceRay = 100.0f;         // -- Distância máxima que a arma pode acertar um alvo   
    public static RaycastController instance;     // -- Referência para a instância ao próprio objeto
    public Text birdName;                         // -- Nome do bird
    public Transform gunFlashTarget;              // -- Referência ao local onde o flash da arma será ativado 
    public float fireRate = 1.6f;                 // -- Tempo de espera até o próximo tiro
    private bool nextShot = true;                 // -- Bool que verifica que o player já pode atirar
    private string objName = "";                  // -- Nome do objeto acertado (para testes)

    AudioSource audioSource;                      // -- Referência ao componente de audio do Raycast
    public AudioClip[] clips;                     // -- Array de clips de audio

    [SerializeField]
    private GameObject _bird;                     // -- Referência ao GO do bird

    [SerializeField]
    private GameObject _gunFlash;                 // -- Referência ao flash da arma será ativado

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
        temp.x = Random.Range(3.4f, 6.5f);
        temp.y = Random.Range(0.4f, 1.4f);
        temp.z = Random.Range(2.7f, 7.7f);
        newBird.transform.position = temp;

    }

    private IEnumerator ClearExplosion()
    {
        // -- Aguarda 1,5s antes de iniciar o método
        yield return new WaitForSeconds(1.5f);

        // -- Toma referências ao GO com a tag "Boom"    
        GameObject[] smokeGroup = GameObject.FindGameObjectsWithTag("Boom");
        // -- Varre todos os elementos encontrados...
        foreach (GameObject smoke in smokeGroup)
        {
            // -- Destroi elementos
            Destroy(smoke.gameObject);
        }
    }

    private IEnumerator TakeShot()
    {

        // -- toca som do tiro
        GunController.instance.FireSound();

        // -- Cria um ray 
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // -- Inicia variável hit do tipo RaycastHit
        RaycastHit hit;

        // -- Diminui quantidade de tiros permitidos por round
        GameManager.instance.shotsPerRound--;

        // -- Utiliza máscara para todos os elementos que estiverem no layer "Bird"
        int layerMask = LayerMask.GetMask("Bird");

        // -- Criar um raycast para verificar se algum elemento no layerMask foi atingido  
        if (Physics.Raycast(ray, out hit, maxDistanceRay, layerMask))
        {

            // -- Toma objeto atingido
            GameObject objHitted = hit.collider.gameObject;

            // -- Setta nome do objeto atingido 
            string objName = objHitted.name;

            // -- Setta nome do bird
            birdName.text = objName;

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

                // -- Inicia corrotina que destruirá todas as explosões            
                StartCoroutine(ClearExplosion());

                // -- Reinicia os tiros por round    
                GameManager.instance.shotsPerRound = 3;
                // -- Incrementa score
                GameManager.instance.playerScore++;
                // -- Incrementa o round
                GameManager.instance.roundScore++;
            }

        }

        GameObject gunFlash = Instantiate(_gunFlash);
        gunFlash.transform.position = gunFlashTarget.position;

        yield return new WaitForSeconds(fireRate);

        nextShot = true;

        GameObject[] gunSmokeGroup = GameObject.FindGameObjectsWithTag("GunSmoke");
        foreach (GameObject gunSmoke in gunSmokeGroup)
        {
            Destroy(gunSmoke.gameObject);
        }

    }

}