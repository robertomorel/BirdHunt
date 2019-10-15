using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{

    public float maxDistanceRay = 100.0f;         // -- Distância máxima que a arma pode acertar um alvo   
    public static RaycastController instance;     // -- Referência para a instância ao próprio objeto

    AudioSource audioSource;                      // -- Referência ao componente de audio do Raycast
    public AudioClip[] clips;                     // -- Array de clips de audio

    [SerializeField]
    private GameObject _bird;                     // -- Referência ao GO do bird

    [SerializeField]
    private GameObject _explosion;                // -- Referência ao GO da explosão do bird

    public GameObject guns;

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

    public void TakeShot()
    {

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
                // -- Toca o som na posição 1    
                PlaySound(1);
                objHitted.GetComponent<BirdController>().bird.Hit(10 /*TODO: Temporário...*/);
            }

        }

        guns.GetComponent<GunController>().nextShot = true;

    }

}