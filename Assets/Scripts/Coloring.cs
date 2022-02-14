using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



public class Coloring : MonoBehaviour
{

    [SerializeField] TextAsset StructureFileSkull;
    [SerializeField] TextAsset StructureFileLegRight;
    [SerializeField] TextAsset StructureFileSpine;
    [SerializeField] TextAsset StructureFileFace;
    [SerializeField] TextAsset StructureFileOrgans;
    [SerializeField] TextAsset StructureFileLegLeft;
    [SerializeField] TextAsset StructureFileHips;
    [SerializeField] TextAsset StructureFileArmLeft;
    [SerializeField] TextAsset StructureFileTorso;
    [SerializeField] TextAsset StructureFileArmRight;
    [SerializeField] TextAsset StructureFileNeck;
    [SerializeField] TextAsset StructureFileBrain;

    [SerializeField] ARSessionOrigin Origin;

    [SerializeField] bool SwitchSkull;
    [SerializeField] bool SwitchLegRight;
    [SerializeField] bool SwitchSpine;
    [SerializeField] bool SwitchFace;
    [SerializeField] bool SwitchOrgans;
    [SerializeField] bool SwitchLegLeft;
    [SerializeField] bool SwitchHips;
    [SerializeField] bool SwitchArmLeft;
    [SerializeField] bool SwitchTorso;
    [SerializeField] bool SwitchArmRight;
    [SerializeField] bool SwitchNeck;
    [SerializeField] bool SwitchBrain;

    private HumanBody body;
    private GameObject humanPrefab;
    private ARTrackedImageManager imageManager;

    public class HumanBody
    {
        public Bodypart skull;
        public Bodypart legRight;
        public Bodypart spine;
        public Bodypart face;
        public Bodypart organs;
        public Bodypart legLeft;
        public Bodypart hips;
        public Bodypart armLeft;
        public Bodypart torso;
        public Bodypart armRight;
        public Bodypart neck;
        public Bodypart brain;
    }

    private static string ReadFileToTextAsset(TextAsset assetfile)
    {
        string content = assetfile.text;
        return content;

    }

    public class Bodypart
    {
        public List<string> parts;

        public void switchit(GameObject body, bool OnOff)
        {
            /*Debug.Log(body.transform.GetChild(0).gameObject.name);
            Debug.Log(body.transform.GetChild(1).gameObject.name);
            Debug.Log(body.transform.Find("3rd Ventricle L (88000251)").gameObject.name);
            */
            foreach (string p in parts)
            {
                Transform parttransform = body.transform.Find(p);
                if (parttransform != null)
                {
                    parttransform.gameObject.SetActive(OnOff); 
                } else
                {
                    Debug.Log("Not found: " + p);
                }
                ///Debug.Log(p);
            }

        }

    }



    // Start is called before the first frame update
    void Start()
    {

        imageManager = Origin.GetComponent<ARTrackedImageManager>();
        Debug.Log("BUG 3");



        body = new HumanBody();
        body.skull = new Bodypart();
        body.legRight = new Bodypart();
        body.legLeft = new Bodypart();
        body.armRight = new Bodypart();
        body.armLeft = new Bodypart();
        body.spine = new Bodypart();
        body.face = new Bodypart();
        body.organs = new Bodypart();
        body.hips = new Bodypart();
        body.torso = new Bodypart();
        body.neck = new Bodypart();
        body.brain = new Bodypart();

        string readstring;
        readstring = ReadFileToTextAsset(StructureFileSkull);
        body.skull = JsonUtility.FromJson<Bodypart>(readstring);

        readstring = ReadFileToTextAsset(StructureFileLegRight);
        body.legRight = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileLegLeft);
        body.legLeft = JsonUtility.FromJson<Bodypart>(readstring);

        readstring = ReadFileToTextAsset(StructureFileArmRight);
        body.armRight = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileArmLeft);
        body.armLeft = JsonUtility.FromJson<Bodypart>(readstring);

        readstring = ReadFileToTextAsset(StructureFileSpine);
        body.spine = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileFace);
        body.face = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileOrgans);
        body.organs = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileHips);
        body.hips = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileTorso);
        body.torso = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileNeck);
        body.neck = JsonUtility.FromJson<Bodypart>(readstring);
        readstring = ReadFileToTextAsset(StructureFileBrain);
        body.brain = JsonUtility.FromJson<Bodypart>(readstring);





    }

    // Update is called once per frame
    void Update()
    {

        if (imageManager != null)
        {
            /* Code for Human body being created by image tracking, untested new for hierarchy
            GameObject trackedPrefab = imageManager.trackedImagePrefab;
            GameObject childHelp = trackedPrefab.transform.GetChild(0).gameObject;
            humanPrefab = childHelp.transform.GetChild(0).gameObject;
            */


            body.brain.switchit(humanPrefab, SwitchBrain);
            body.hips.switchit(humanPrefab, SwitchHips);
            body.legLeft.switchit(humanPrefab, SwitchLegLeft);
            body.legRight.switchit(humanPrefab, SwitchLegRight);
            body.spine.switchit(humanPrefab, SwitchSpine);
            body.armLeft.switchit(humanPrefab, SwitchArmLeft);
            body.armRight.switchit(humanPrefab, SwitchArmRight);
            body.face.switchit(humanPrefab, SwitchFace);
            body.skull.switchit(humanPrefab, SwitchSkull);
            body.organs.switchit(humanPrefab, SwitchOrgans);
            body.torso.switchit(humanPrefab, SwitchTorso);
            body.neck.switchit(humanPrefab, SwitchNeck);

        }
    }


}


