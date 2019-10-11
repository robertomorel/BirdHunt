using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    public GameObject textLanguage;
    
    public GameObject menu;
    public GameObject menuNew;
    public GameObject menuLoad;
    public GameObject menuCredits;    
    public List<GameObject> listMenus;    

    public InputField inputPlayerNameText;
    public GameObject listPerson_Content;

    public string filePathRoot = "";
    public string filePath;
    public string nomePlayer;

    public UserSerialized player = null;
    
    public static bool avancarParaStartUI = false;

    public static LobbyManager instance = null;

    private void Awake()
    {
        filePathRoot = Application.persistentDataPath;

        if(instance == null)
        {
            instance = this;
        }        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (LobbyManager.avancarParaStartUI)
        {
            CarregarPlayer( PlayerPrefs.GetString("PlayerLogado") );
            LoadStartUI();
            LobbyManager.avancarParaStartUI = false;
        }
        else
        {
            LoadMenu();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: Criar função que ativa e desabilita dinamicamente
    public void LoadMenu()
    {
        inputPlayerNameText.text = "";

        AtivarMenu(menu);
    }

    public void LoadMenuNew()
    {
        AtivarMenu(menuNew);        
    }

    public void LoadMenuLoad()
    {
        player = null;

        listPerson_Content.GetComponent<ContentListUsers>().AtualizaListaPersons();

        AtivarMenu(menuLoad);        
    }

    public void LoadMenuCredits()
    {
        AtivarMenu(menuCredits);
    }

    public void LoadStartUI()
    {
        buttonOnClickChangeScene( "Intro" );
    }

    public void LoadMenuExit()
    {
        Application.Quit();
    }

    public void LoadMenuChangeLanguage()
    {
        MultiIdiomaManager.instance.ChangeLanguage();

        TextMeshProUGUI tmpro = textLanguage.GetComponent<TextMeshProUGUI>();

        tmpro.text = MultiIdiomaManager.instance.languageAtual;

        menu.SetActive(false);
        menu.SetActive(true);
    }

    public void LoadCreatePerson()
    {
        if(inputPlayerNameText.text == "")
        {
            return;
        }

        //TODO: Validar se já não existe o jogador e lançar mensagem de erro caso já exista

        CarregarPlayer( inputPlayerNameText.text );

        LoadStartUI();
    }

    void AtivarMenu(GameObject menuAtivo)
    {
        for (int i = 0; i < listMenus.Count; i++)
        {
            if(listMenus[i] == menuAtivo)
            {
                listMenus[i].SetActive(true);
            }
            else
            {
                listMenus[i].SetActive(false);
            }
        }
    }

    /*
		Função que cria um arquivo binário com a ficha do personagem
		Autor: Thiago Melo
    */
    public UserSerialized CarregarDadosPlayer()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(filePath, FileMode.Open);

        UserSerialized unitPlayer = (UserSerialized)bf.Deserialize(fileStream);

        fileStream.Close();

        Debug.Log("Carregando dados do usuário existente: " + nomePlayer);
        Debug.Log("Dados do arquivo:" + unitPlayer.ToString());
        
        return unitPlayer;
    }

    /*
		Função que atualiza o arquivo binário com os novos dados do personagem
		Autor: Thiago Melo
    */
    public UserSerialized SalvarDadosPlayer(UserSerialized unitPlayer)
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("Salvando dados do novo usuário: " + nomePlayer);
            Debug.Log("Dados do novo arquivo:" + unitPlayer.ToString());
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream;

        if (File.Exists(filePath))
        {
            fileStream = File.Open(filePath, FileMode.Open);
        }
        else
        {
            fileStream = File.Create(filePath);
        }

        bf.Serialize(fileStream, unitPlayer);

        fileStream.Close();

        return unitPlayer;
    }

    public List<string> BuscarPlayers()
    {
        DirectoryInfo dirInfo = new DirectoryInfo(filePathRoot);
        List<string> result = new List<string>(); 

        foreach (FileInfo file in dirInfo.GetFiles())
        {
            if( file.FullName.IndexOf(".dat") == -1)
            {
                continue;
            }

            string temp = file.FullName.Replace(".dat", "")
                          .Replace("player_", "")
                          .Replace( (filePathRoot + "/").Replace("/","\\"), "");

            result.Add(temp);
        }


        return result;
    }

    public void CarregarPlayer(string namePerson)
    {
        nomePlayer = namePerson;

        filePath = filePathRoot + "/player_" + nomePlayer + ".dat";

        Debug.Log("filePath = " + filePath);

        if (File.Exists(filePath))
        {
            player = CarregarDadosPlayer();
        }
        else
        {
            player = SalvarDadosPlayer(new UserSerialized(nomePlayer, new Vector3Int(1, 5, 0)));
        }
    }

    public void buttonOnClickChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene, LoadSceneMode.Single);
    }

}
