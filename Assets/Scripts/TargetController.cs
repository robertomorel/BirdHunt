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
        Vector3 temp;
        temp.x = Random.Range(3.4f, 6.5f);
        temp.y = Random.Range(0.4f, 1.4f);
        temp.z = Random.Range(2.7f, 7.7f);
        transform.position = temp;
        //if (DefaultTrackableEventHandler.trueFalse)
        //{
        //    RaycastController.instance.PlaySound(0);
        //}

    }
}
