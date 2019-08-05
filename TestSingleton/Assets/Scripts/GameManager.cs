using UnityEngine;
using System.IO;

public enum Genre
{
    Male,
    Female
}

public enum Ethnicity
{
    Black,
    Brown,
    White
}

public class Player
{
    public Genre Genre;
    public Ethnicity Ethnicity;
}

public class GameAudio
{
    public bool Music;
    public bool Dialog;
    public bool Sfx;
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private string _dataPath;
    
    public static GameManager Instance { get { return _instance; } }
    public bool hasAppleWatch;
    public GameAudio GameAudio;
    public Player Player;

    private void Awake()
    {
        SetInstance();
        SetPlayer();
    }

    private void Start()
    {
        _dataPath = Path.Combine(Application.persistentDataPath, "PlayerData.txt");
        Player = LoadCharacter (_dataPath);
    }

    private void SetInstance()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
    }

    public void SetPlayer()
    {
        Player = new Player();
        Player.Ethnicity = Ethnicity.Brown;
        Player.Genre = Genre.Female;
    }

    void Update ()
    {

        Debug.Log("*********Player.e*********");
        Debug.Log(Player.Ethnicity);
        Debug.Log(Player.Genre);
        Debug.Log("****************************");
        
        if(Input.GetKeyDown (KeyCode.S))
            SaveCharacter (Player, _dataPath);
//            SaveCharacter (_dataPath);

        if (Input.GetKeyDown (KeyCode.L))
            Player = LoadCharacter (_dataPath);
    }

    static void SaveCharacter (Player data, string path)
//    static void SaveCharacter (string path)
    {
//        Player data = new Player();
//        data.Ethnicity = Ethnicity.White;
//        data.Genre = Genre.Male;
        string jsonString = JsonUtility.ToJson (data);
        using (StreamWriter streamWriter = File.CreateText (path))
        {
            streamWriter.Write (jsonString);
        }
    }

    static Player LoadCharacter (string path)
    {
        using (StreamReader streamReader = File.OpenText (path))
        {
            string jsonString = streamReader.ReadToEnd ();
            return JsonUtility.FromJson<Player> (jsonString);
        }
    }
}
