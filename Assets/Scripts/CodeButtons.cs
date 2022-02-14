using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class CodeButtons : MonoBehaviour
{
    [SerializeField] GameObject imageCodeButtonPrefab;
    [SerializeField] SelectCodeMode selectCode;
    [SerializeField] string initKapitel;
    [SerializeField] string initGroup;

    private void DisplayGroup()
    {

        Debug.Log("BUG 80-3");
        GameObject GroupArea = transform.Find("Group").gameObject;
        Debug.Log("BUG 80-4");
        GameObject GroupPanel = GroupArea.transform.Find("GroupPanel").gameObject;
        Debug.Log("BUG 80-5");
        Debug.Log("UG 80-6.1start: " + GroupPanel.transform.childCount);

        List<GameObject> OldList = new List<GameObject>();

        for (int i = GroupPanel.transform.childCount - 1; i >= 1; i--)
        {
            ///GameObject.Destroy(GroupPanel.transform.GetChild(i).gameObject);
            OldList.Add(GroupPanel.transform.GetChild(i).gameObject);
        }

        List<string> grouplist = selectCode.Groups();



        foreach (string gr in grouplist)
        {
            Debug.Log("BUG 82-.1: " + gr);
            GameObject obj = Instantiate(imageCodeButtonPrefab, GroupPanel.transform) ;
            Debug.Log("BUG 82-a.1: " + obj.name);
            ///obj.transform.SetParent(GroupPanel.transform, false);
            Button button = obj.GetComponent<Button>();
            GameObject textGroup = obj.transform.Find("Text (TMP)").gameObject;
            TextMeshProUGUI textMeshPro = textGroup.GetComponent<TMPro.TextMeshProUGUI>();
            textMeshPro.text = gr;
            Debug.Log("BUG 82-d.1");
            button.onClick.AddListener(() => OnClickGroup(gr));
        }

        foreach (GameObject obj in OldList)
        {
            GameObject.Destroy(obj);
            //obj.SetActive(false);
        }
    }

    private void DisplayCode()
    {

        Debug.Log("BUG 80-3");
        GameObject CodeArea = transform.Find("Code").gameObject;
        
        GameObject CodePanel = CodeArea.transform.Find("CodePanel").gameObject;
        Debug.Log("BUG 80-5");

        List<GameObject> OldList = new List<GameObject>();

        for (int i = CodePanel.transform.childCount - 1; i >= 1; i--)
        {
            ///GameObject.Destroy(GroupPanel.transform.GetChild(i).gameObject);
            OldList.Add(CodePanel.transform.GetChild(i).gameObject);
        }

        List<string> codelist = selectCode.Codes();



        foreach (string code in codelist)
        {
            Debug.Log("BUG 82-.1: " + code);
            GameObject obj = Instantiate(imageCodeButtonPrefab, CodePanel.transform);
            ///obj.transform.SetParent(GroupPanel.transform, false);
            Button button = obj.GetComponent<Button>();
            GameObject textGroup = obj.transform.Find("Text (TMP)").gameObject;
            TextMeshProUGUI textMeshPro = textGroup.GetComponent<TMPro.TextMeshProUGUI>();
            textMeshPro.text = code;
            Debug.Log("BUG 82-d.1");
            button.onClick.AddListener(() => OnClickCode(code));
        }

        foreach (GameObject obj in OldList)
        {
            GameObject.Destroy(obj);
            //obj.SetActive(false);
        }
    }

    void Start()
    {
        Debug.Log("BUG 80-1");
        GameObject KapitelArea = transform.Find("Kapitel").gameObject;
        Debug.Log("BUG 80-2");
        GameObject KapitelPanel = KapitelArea.transform.Find("KapitelPanel").gameObject;
        Debug.Log("BUG 80-3: " + KapitelPanel.transform.childCount);

        List<GameObject> OldList = new List<GameObject>();
        for (int i = KapitelPanel.transform.childCount - 1; i >= 1; i--)
         {
            Debug.Log("BUG 80");
            //GameObject.Destroy(KapitelPanel.transform.GetChild(i).gameObject);
            OldList.Add(KapitelPanel.transform.GetChild(i).gameObject);
            Debug.Log("BUG 80after");
        }


        Debug.Log("BUG 81after: " + KapitelPanel.transform.childCount);

        List<string> kaplist = selectCode.Kapitel();


      


        foreach (string kap  in kaplist)
         {
            GameObject obj = Instantiate(imageCodeButtonPrefab, KapitelPanel.transform);
            ///obj.transform.SetParent(KapitelPanel.transform, false);
            Button button = obj.GetComponent<Button>();
            GameObject textKapitel= obj.transform.Find("Text (TMP)").gameObject;
            TextMeshProUGUI textMeshPro = textKapitel.GetComponent<TMPro.TextMeshProUGUI>();
            textMeshPro.text = kap;
            Debug.Log("BUG 82d");
            button.onClick.AddListener(() => OnClickKapitel(kap));
         }

        foreach (GameObject obj in OldList)
        {
            GameObject.Destroy(obj);
            //obj.SetActive(false);
        }


        selectCode.KapitalSelected(initKapitel);

        ///-------- Groups

        DisplayGroup();


        selectCode.GroupSelected(initGroup);

        DisplayCode();
        
    }

    void OnClickKapitel(string kapitel)

   
    {
        Debug.Log($"BUG 90: Button clicked {kapitel}");
        selectCode.KapitalSelected(kapitel);
        DisplayGroup();

    }

    void OnClickGroup(string group)


    {
        Debug.Log($"BUG 90.1: Button clicked {group}");
        selectCode.GroupSelected(group);
        DisplayCode();
    }

    void OnClickCode(string code)


    {
        Debug.Log($"BUG 90.2 Button clicked {code}");
        selectCode.CodeSelected(code);
    }
}
