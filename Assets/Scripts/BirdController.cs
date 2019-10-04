using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private GameObject _targetFocus;          // -- Guarda o GO que será usado como alvo de movimentação

    [SerializeField] private float _speed;    // -- Referência à velocidade de movimentação do bird

    // Start is called before the first frame update
    void Start()
    {
        // -- Instancia o target 
        _targetFocus = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        // -- Calcula a distância entre o bird e o alvo
        Vector3 target = _targetFocus.transform.position - this.transform.position;
        Debug.Log(target.magnitude); // -- Distância do bird ao alvo

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
}
