using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[SerializeField]
public class VarCheck : MonoBehaviour
{
    private static VarCheck _instance;

    public static VarCheck Instance
    {
        get
        {
            if (_instance == null)
            {
                //Debug.Log("Creating Instance.");
                GameObject go = new GameObject("Instances");
                if (Purchaser.Instance == null)
                {
                    go.AddComponent<Purchaser>();
                }
                go.AddComponent<VarCheck>();
            }
            //Debug.Log("Instance is Active.");
            return _instance;
        }
    }

    public bool pictureTaken;
    public bool appDone;
    public string appType;
    public string userName;

    public bool applicationFilled { get; set; }
    public bool[] filled { get; set; }
    public string pictureName { get; set; }
    public string contractName { get; set; }
	public string filePath { get; set; }
	public string fileData { get; set; }
    public string appPath { get; set; }

    public int orient { get; set; }
    [HideInInspector]
    public Text nameText;
    [HideInInspector]
    public GameObject accept;
    [HideInInspector]
    public Scene currentScene;

    public string emailBody { get; private set; }
	public string emailSubject { get; private set; }

    public string FromEmail;
    public string ToEmail;
    public string Password;

    private void Awake()
    {
        _instance = this;

        CheckPrefs();

        //THIS IS VERY IMPORTANT AND WILL WASTE WEEKS OF TIME IF YOU FORGET TO DO IT!!!
        DontDestroyOnLoad(this.gameObject);

        if (Application.isEditor)
        {

            appPath = Application.persistentDataPath;
            filePath = Application.persistentDataPath;
        }
        else
        {
            appPath = "";
            filePath = Application.temporaryCachePath;
        }
    }

    // Use start to set values to our variables.

    void Start () 
	{
        ToEmail = Encryption.Decrypt("toe0QZsBaVgCrt9DTG6sAh9BORjdEwcL");
        FromEmail = Encryption.Decrypt("FBmZJOpi+3GPVe+cJkGQtGOoLHv7LsMCL3eCM3M7Ybc=");
        Password = Encryption.Decrypt("F4t5g63WZScW8+9GgZ0qBg==");
        pictureName = "photo.png";
        contractName = "contract.png";
    }

    public void SceneCheck(string scene)
    {
        if (scene == "PDF")
        {
            accept = GameObject.Find("Accept");
            nameText = GameObject.Find("Name Text").GetComponent<Text>();
            filled = new bool[8];
            for (int i = 0; i < filled.Length; i++)
            {
                filled[i] = false;
            }
        }
    }

    public void SetMail()
	{
        emailSubject = userName + "'s Spiritual Contract.";

        /*emailBody = "User type is: " + VarCheck.Instance.appType + "\n";
        emailBody += saveData.UserName + " would like spiritual work done.\n";
        emailBody += "Attached are " + saveData.UserName + "'s contract and picture.";
        emailBody += "\n" + saveData.UserName + " sent this email:";
        emailBody += "\n" + System.DateTime.Now;*/

        emailBody = string.Format("User type is: {0}. \n{1} would like spiritual work done.\nAttached are {1}'s Application and Picture." +
            "\n{1} sent this email:\n{2}", appType, userName, System.DateTime.Now);
	}

    public void LandscapeOnly()
    {
        Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

    public void AutoRotate()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
    }

    public void CheckPrefs()
    {
        if (FileBasedPrefs.HasKeyForString("App Type"))
        {
            appType = FileBasedPrefs.GetString("App Type");
        }
        else
        {
            appType = null;
        }

        if (FileBasedPrefs.HasKeyForString("User Name"))
        {
            userName = FileBasedPrefs.GetString("User Name");
        }

        if (FileBasedPrefs.HasKeyForBool("Picture Taken"))
        {
            pictureTaken = FileBasedPrefs.GetBool("Picture Taken");
        }

        if (FileBasedPrefs.HasKeyForBool("App Done"))
        {
            appDone = FileBasedPrefs.GetBool("App Done");
        }
    }
}
