using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonItemListUsers : MonoBehaviour
{

    private void Start()
    {
        Text textButtonClick = transform.GetComponentInChildren<Text>();

        textButtonClick.text = this.name;
    }

    public void SelecionarItem()
    {
        Transform parent = transform.parent;
        Text textButtonClick = transform.GetComponentInChildren<Text>();

        foreach (Transform child in parent)
        {
            Text textButtonTemp = child.gameObject.GetComponentInChildren<Text>();
            
            if (textButtonTemp == textButtonClick ) 
            {
                textButtonTemp.color = Color.red;
                LobbyManager.instance.CarregarPlayer(textButtonTemp.text);
            }
            else
            {
                textButtonTemp.color = Color.black;
            }
            
        }

        
    }
}
