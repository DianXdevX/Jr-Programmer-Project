using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance; //static er aquilo que ja foi visto e um valor golbal para todas as intasia 
    public Color TeamColor; // para armazenar a cor que  o jogador selecionar 
    private void Awake()
    {
       
        //se o  instance  for diferente de 0  ou nulo  destruao 
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;  // pelo que entendi  isso permite instanciar o objeto sem  ter que fazer um get componet ou um gameobject find
        DontDestroyOnLoad(gameObject);  // permite que o  objeto permaneca "vivo" entre as cenas 
        LoadColor(); //carega o arquivo se existir
    }
    [System.Serializable] // e usado para converter em json 
    class SaveData
    {
        public Color TeamColor;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();  //instacia um novo savedata
        data.TeamColor = TeamColor;  // data   cor do coisa e igual a esta cor 

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // sobreescre  se jha tiver 
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json"; //pega o caminnho do sabe
        if (File.Exists(path)) // se o arquivo exise  no caminho  escolhido 
        {
            string json = File.ReadAllText(path); // testo do   arquivo e lido 
            SaveData data = JsonUtility.FromJson<SaveData>(json);  // "decripitogrfa osave "  confertando de json para  unity

            TeamColor = data.TeamColor; //  a cor e igual a cor salva 
        }
    }
}
