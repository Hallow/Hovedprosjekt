using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class ProgressScript : MonoBehaviour
{

    private static int RUNTIME_ENVIRONMENT;
    private static int ANDROID = 1;
    private static int EDITOR = 0;

    private string FileLocation;
    private string FileName;
    private string Data;

    public bool loaded;

    public Progress progress;

    public bool[] progressList;

    public Vector3[] lockPositions;

    public GameObject levelLocked;
    public GameObject tempLevelLocked;
    public GameObject padLock;
    public GameObject tempPadLock;

    public GameObject[] buttons;

    // Use this for initialization
    void Start()
    {
        loaded = false;

#if UNITY_ANDROID
        RUNTIME_ENVIRONMENT = 1;
#endif
#if UNITY_EDITOR
        RUNTIME_ENVIRONMENT = 0;
#endif

        lockPositions = new Vector3[5];

        SetLockPositions();

        //FileLocation = Application.dataPath;
        progressList = new bool[6];

        progress = new Progress();

        if (RUNTIME_ENVIRONMENT == ANDROID)
        {
            FileLocation = "/storage/emulated/0/.TOWData/";
            if (!Directory.Exists(FileLocation))
            {
                DirectoryInfo dir = Directory.CreateDirectory(FileLocation);
            }
        }
        else if (RUNTIME_ENVIRONMENT == EDITOR)
        {
            FileLocation = Application.dataPath;
        }

        FileName = "progress.xml";

        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool[] GetCompletedLevels()
    {
        LoadXML();
        return progress.progressList;
    }

    private void Initialize()
    {
    }

    public void SaveXML()
    {
        StreamWriter writer;
        FileInfo file;

        if (RUNTIME_ENVIRONMENT == ANDROID)
            file = new FileInfo(FileLocation + "" + FileName);


        file = new FileInfo(FileLocation + "\\" + FileName);

        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            file.Delete();
            writer = file.CreateText();
        }

        progress.progressList = progressList;

        writer.Write(Data);
        writer.Close();
        Debug.Log("Progress have been saved!");
    }

    public void Load()
    {
        progress = (Progress)DeSerialize(Data);
    }

    public void LoadXML()
    {
        FileInfo file = new FileInfo(FileLocation + "\\" + FileName);

        if (!file.Exists)
        {
            foreach (GameObject o in buttons)
            {
                Debug.Log("level is locked (" + o.GetComponent<WoodlandLevelButtonScript>().level + ")");
                tempPadLock = (GameObject)Instantiate(padLock);
                tempPadLock.transform.position = lockPositions[o.GetComponent<WoodlandLevelButtonScript>().level - 1];

                if (progressList[o.GetComponent<WoodlandLevelButtonScript>().level - 1] == true)
                {
                    o.GetComponent<WoodlandLevelButtonScript>().isClickable = true;
                }
                else
                {
                    o.GetComponent<WoodlandLevelButtonScript>().isClickable = false;
                }
            }
            return;
        }

        StreamReader r = File.OpenText(FileLocation + "\\" + FileName);
        string info = r.ReadToEnd();
        r.Close();
        Data = info;
        if (Data.ToString() != "")
        {
            progress = (Progress)DeSerialize(Data);
        }
    }

    private string Serialize(object o)
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(Progress));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.ASCII);
        xs.Serialize(xmlTextWriter, o);
        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }

    private object DeSerialize(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Progress));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.ASCII);
        return xs.Deserialize(memoryStream);
    }

    string UTF8ByteArrayToString(byte[] characters)
    {
        //UTF8Encoding encoding = new UTF8Encoding();
        ASCIIEncoding encoding = new ASCIIEncoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }

    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        //UTF8Encoding encoding = new UTF8Encoding();
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }

    public void LoadData()
    {
        Debug.Log("loading data...");
        LoadXML();

        if (Data.ToString() != "")
        {
            progress = (Progress)DeSerialize(Data);
            progressList = progress.progressList;
        }

        foreach (GameObject o in buttons)
        {

            if (progressList[o.GetComponent<WoodlandLevelButtonScript>().level - 1] == true)
            {
                o.GetComponent<WoodlandLevelButtonScript>().isClickable = true;
            }
            else
            {
                o.GetComponent<WoodlandLevelButtonScript>().isClickable = false;
                Debug.Log("level is locked (" + o.GetComponent<WoodlandLevelButtonScript>().level + ")");
                tempPadLock = (GameObject)Instantiate(padLock);
                tempPadLock.transform.position = lockPositions[o.GetComponent<WoodlandLevelButtonScript>().level - 1];
            }
        }

        Debug.Log("data loaded!");
        loaded = true;


    }

    public void SaveData()
    {
        for (int i = 0; i < progressList.Length; i++)
        {
            progress.progressList[i] = progressList[i];
        }

        Data = Serialize(progress);
        SaveXML();
    }

    private void SetLockPositions()
    {
        lockPositions[0] = new Vector3(-8.027225f, 10.52024f, -1.189029f);
        lockPositions[1] = new Vector3(7.42332f, 10.52024f, -1.189029f);
        lockPositions[2] = new Vector3(-8.027225f, -3.876885f, -1.189029f);
        lockPositions[3] = new Vector3(7.42332f, -3.876885f, -1.189029f);
        lockPositions[4] = new Vector3(0.1203735f, -17.72676f, -1.189029f);
    }
}
