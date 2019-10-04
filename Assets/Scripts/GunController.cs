using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    private AudioSource _audioSource;        // -- Referência ao audio da arma
    public static GunController instance;    // -- Referência à instancia do próprio objeto

    private void Awake()
    {
        // -- Criando instância
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // -- Instancia o componente de audio
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void FireSound()
    {
        // -- Dá play no audio quando método chamado
        _audioSource.Play();
    }
}
