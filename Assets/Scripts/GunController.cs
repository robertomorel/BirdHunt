using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{

    private AudioSource _audioSource;             // -- Referência ao audio da arma
    public static GunController instance;         // -- Referência à instancia do próprio objeto

    public float fireRate = 1.6f;                 // -- Tempo de espera até o próximo tiro
    public bool nextShot = true;                 // -- Bool que verifica que o player já pode atirar

    public CursorLockMode cursorMode;
    public bool visibleCursor;

    public Animator animator;

    public Button buttonFire;
    private bool useButtonFire;
    public bool testButtonFire;

    private void Awake()
    {
        // -- Criando instância
        if (!instance)
        {
            instance = this;
        }
        //animator = GetComponentInChildren<Animator>();
        // -- Instancia o componente de audio
        _audioSource = GetComponent<AudioSource>();

        Cursor.lockState = this.cursorMode;
        Cursor.visible = this.visibleCursor;

        if (this.buttonFire)
        {
            #if (UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL)
            this.useButtonFire = false;
            #elif UNITY_ANDROID
            this.useButtonFire = true;
            #endif

            if (this.useButtonFire || this.testButtonFire){
                this.buttonFire.gameObject.SetActive(true);
            }
            else{
                this.buttonFire.gameObject.SetActive(false);
            }

            this.buttonFire.onClick.AddListener(delegate{
                if (nextShot)
                {
                    nextShot = false;
                    StartCoroutine(Shot());
                }    
            });
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !useButtonFire && !testButtonFire)
        {
            if (nextShot)
            {
                nextShot = false;
                StartCoroutine(Shot());
            }
        }
    }

    // Update is called once per frame
    private IEnumerator Shot()
    {
        GameObject.Find("Raycast").GetComponent<RaycastController>().TakeShot();
        // -- Dá play no audio quando método chamado
        _audioSource.Play();
        animator.SetTrigger("run");
        yield return new WaitForSeconds(fireRate);
    }
}