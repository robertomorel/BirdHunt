using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    private AudioSource _audioSource;        // -- Referência ao audio da arma
    public static GunController instance;    // -- Referência à instancia do próprio objeto

    private Animator animator;

    private void Awake()
    {
        // -- Criando instância
        if (!instance)
        {
            instance = this;
        }
        animator = GetComponentInChildren<Animator>();
        // -- Instancia o componente de audio
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    // Update is called once per frame
    public void Shot()
    {
        GameObject.Find("Raycast").GetComponent<RaycastController>().Fire();
        // -- Dá play no audio quando método chamado
        _audioSource.Play();
        animator.Play("Play");
    }
}
