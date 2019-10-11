using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentListUsers : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        AtualizaListaPersons();    
    }

    public void AtualizaListaPersons()
    {
        Debug.Log("Destruindo elementos");
        foreach (Button item in gameObject.GetComponentsInChildren<Button>())
        {
            Debug.Log("Destruindo item = " + item);
            Destroy(item.gameObject);
        }
        
        List<string> listaPersons = LobbyManager.instance.BuscarPlayers();

        for (int i = 0; i < listaPersons.Count; i++)
        {
            Button b = Instantiate(button, transform);
            b.name = listaPersons[i];
            b.gameObject.SetActive(true);
        }
    }
}
