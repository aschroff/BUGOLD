using UnityEngine;
using System.Collections.Generic;

public class SelectCodeMode : MonoBehaviour
{
    [SerializeField] TextAsset CatalogFile;
    [SerializeField] AddPictureMode addPicture;
    [SerializeField] EditPictureMode editPicture;
    [SerializeField] CatalogDiseases cat;
    [SerializeField] string currentKapital;
    [SerializeField] string currentGroup;
    [SerializeField] string currentCode;

    public bool isReplacing = false;

    private void OnEnable()
    {
        UIController.ShowUI("SelectCode");
    }

    private static string ReadFileToTextAsset(TextAsset assetfile)
    {
        string content = assetfile.text;
        return content;

    }

    public List<string> Kapitel()
    {

        Debug.Log("BUG 74");
        List<string> KapitelList = new List<string>();
        if (cat == null)
        {
            CreateCatalog();
        }

        if (cat != null)
        {
            Debug.Log("74 a");
            foreach (string d in cat.diseases)
            {
                Debug.Log("BUG 74aa");
                string Kapitel = KapitelFromDisease(d);
                Debug.Log("BUG 74b");
                if (KapitelList.Contains(Kapitel))
                {
                    Debug.Log("BUG 74c");
                }
                else
                {
                    KapitelList.Add(Kapitel);
                }

            }
        }
        else
        {
            Debug.Log("BUG E: cat still null");
        }
        Debug.Log("BUG 76: " + KapitelList.Count);
        return KapitelList;

    }

    public List<string> Groups(string kapitel = "")
    {
        if (kapitel == null)
        {
            kapitel = currentKapital;
        } else
        {
            if (kapitel == "")
            {
                kapitel = currentKapital;
            }
        }
        Debug.Log("BUG 77a");
        List<string> GroupList = new List<string>();
        if (cat == null)
        {
            CreateCatalog();
        }

        if (cat != null)
        {
            Debug.Log("BUG 77b: " + kapitel);
            foreach (string d in cat.diseases)
            {
                string KapitelDisease = KapitelFromDisease(d);
                if (KapitelDisease == kapitel) {
                    string Group = GroupFromDisease(d);
                    if (!(GroupList.Contains(Group)))
                    {
                        GroupList.Add(Group);
                    }
                }
            }
        }
        else
        {
            Debug.Log("BUG E: cat still null");
        }
        Debug.Log("BUG 77i: " + GroupList.Count);
        return GroupList;

    }

    public List<string> Codes(string group = "")
    {
        if (group == null)
        {
            group = currentKapital;
        }
        else
        {
            if (group == "")
            {
                group = currentGroup;
            }
        }
        Debug.Log("BUG 77a");
        List<string> CodeList = new List<string>();
        if (cat == null)
        {
            CreateCatalog();
        }

        if (cat != null)
        {
            Debug.Log("BUG 77b: " + group);
            foreach (string d in cat.diseases)
            {
                string GroupDisease = GroupFromDisease(d);
                if (GroupDisease == group)
                {
                    string Code = CodeFromDisease(d);
                    if (!(CodeList.Contains(Code)))
                    {
                        CodeList.Add(Code);
                    }
                }
            }
        }
        else
        {
            Debug.Log("BUG E: cat still null");
        }
        Debug.Log("BUG 77i: " + CodeList.Count);
        return CodeList;

    }

    private string KapitelFromDisease(string disease)
    {
        string[] diseaseFields = disease.Split('\t');
        string kapitel = diseaseFields[1];
        return kapitel;
    }

    private string GroupFromDisease(string disease)
    {
        string[] diseaseFields = disease.Split('\t');
        string group = diseaseFields[4];
        return group;
    }

    private string CodeFromDisease(string disease)
    {
        string[] diseaseFields = disease.Split('\t');
        string code = diseaseFields[6];
        return code;
    }

    public class CatalogDiseases
    {
        public List<string> diseases;

    }

    private void CreateCatalog()
    {
        Debug.Log("BUG 70");



        cat = new CatalogDiseases();

        Debug.Log("BUG 71");

        string readstring;
        readstring = ReadFileToTextAsset(CatalogFile);

        Debug.Log("BUG 72");
        cat = JsonUtility.FromJson<CatalogDiseases>(readstring);
        Debug.Log("BUG 72a");
        //List<string> testtemp = Kapitel();
        Debug.Log("BUG 73uiuiuiui: " + cat.diseases[1]);
        //Debug.Log("BUG 73a: " + testtemp);
    }

    // Start is called before the first frame update
    void Start()
    {




    }

    public void KapitalSelected(string Kapital)
    {
        currentKapital = Kapital;
    }

    public void GroupSelected(string group)
    {
        currentGroup = group;
    }

    public void CodeSelected(string code)
    {
        currentCode = code;
    }
}
