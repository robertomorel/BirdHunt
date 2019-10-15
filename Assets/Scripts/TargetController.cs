using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public static TargetController instance;   // -- Referência para a própria instância 

    private void Awake()
    {
        // -- Cria uma instância 
        if (!instance)
        {
            instance = this;
        }
    }

    /*
     OnTriggerEnter é disparado quando um Rigidbody com colisor intersecciona 
     um colisor marcado como "Trigger". Já OnCollisionEnter dispara quando um 
     Rigidbody com colisor colide com um outro colisor. O trigger é utilizado 
     quando a interação deve ser sem bloqueio do movimento, como quando se cria 
     uma área que dispara um evento quando o personagem entra nela. Já o collider 
     é usado quando um corpo precisa bater no outro para o evento ocorrer.
     */

    private void OnTriggerEnter(Collider other)
    {
        MoveTarget();
    }

    /*
        Este método faz com que o target se mova para distâncias randômicas dentro de um vector3
    */
    public void MoveTarget()
    {
        /*
        Limites da área de voo
            X[-0.163, 0.198]
            Y[0.128, 0.441]
            Z[-0.18, 0.178]
        */
        Vector3 temp;
        temp.x = Random.Range(3.54f, 6.93f);
        temp.y = Random.Range(0.804f, 3.783f);
        temp.z = Random.Range(3.8f, 6.64f);
        transform.position = temp;
    }
}
