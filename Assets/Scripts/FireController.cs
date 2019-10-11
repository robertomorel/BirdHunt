using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public GameObject[] guns;
    public void ActivateFireEffects()
    {
        // -- Encontra todos os game objects filhos 
        GameObject activeGun = FindActiveGun();
        Debug.Log("Active gun name: " + activeGun.name);

        // -- Encontra a partícula de bala
        Transform bulletEffect = activeGun.transform.Find("Bullets_Effect");
        // -- Roda animações de partículas 
        RunParticlesEffects(bulletEffect);
        // -- Encontra a partícula de fumaça
        Transform smokeEffect = activeGun.transform.Find("Smoke");
        // -- Roda animações de partículas
        RunParticlesEffects(smokeEffect);

    }

    /*
     Encontra a arma ativa do array.
     Atenção!! Deve existir sempre apenas uma arma ativa.
         */
    private GameObject FindActiveGun()
    {

        if (guns.Length == 0)
        {
            Debug.Log("Error! There is no gun avaliable in the array.");
        }

        for (int i = 0; i < guns.Length; i++)
        {
            if (guns[i].activeInHierarchy)
            {
                return guns[i];
            }
        }
        Debug.Log("Error! The code never should be here.");
        return null;
    }

    private void RunParticlesEffects(Transform tgo)
    {
        if (tgo != null)
        {
            GameObject go = tgo.gameObject;
            // -- Confirmar se game object está desativado 
            go.SetActive(false);
            // -- Captura o transform do game object 
            Transform t = go.transform;
            // -- Instanciar game object da partícula de fumaça igual ao que já existe
            GameObject newGO = Instantiate(go, t.position, t.rotation, t.parent);
            // -- Ativa o gameobject - caso esteja desativado
            newGO.SetActive(true);
            // -- Anicia a animação da partícula 
            newGO.GetComponent<ParticleSystem>().Play();
        }
    }

}