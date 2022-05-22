using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEditor;

public class LoadCharacterAni : MonoBehaviour
{
    private Dictionary<string, GameObject> CharacterPrefab = new Dictionary<string, GameObject>();
    private Dictionary<string, RuntimeAnimatorController> CharacterAniVontroller = new Dictionary<string, RuntimeAnimatorController>();

    // Start is called before the first frame update
    void Start()
    {
        string[] prefabsName = Directory.GetFileSystemEntries(@"Assets/Prefabs/", "*.fbx");
        foreach (var file in prefabsName)
        {
            CharacterPrefab.Add(file.Replace(@"Assets/Prefabs/","").Replace(".fbx",""), (GameObject)AssetDatabase.LoadAssetAtPath(file, typeof(GameObject)));
            Debug.Log("prfab: " + file.Replace(@"Assets/Prefabs/", "").Replace(".fbx", ""));
        }
        string[] aniName = Directory.GetFileSystemEntries(@"Assets/Animate/", "*.controller");
        foreach (var file in aniName)
        {
            CharacterAniVontroller.Add(file.Replace(@"Assets/Animate/","").Replace(".controller", "").Replace("_Ani", ""), (RuntimeAnimatorController)AssetDatabase.LoadAssetAtPath(file, typeof(RuntimeAnimatorController)));
            Debug.Log("ani: " + file.Replace(@"Assets/Animate/", "").Replace(".controller", "").Replace("_Ani", ""));
        }


       int i = -1;
        foreach (var prefab in CharacterPrefab)
        {
            GameObject gameCharacter = Instantiate(prefab.Value,new Vector3(i,0,0),Quaternion.identity);
            if (CharacterAniVontroller.ContainsKey(prefab.Key))
            {
                gameCharacter.GetComponent<Animator>().runtimeAnimatorController = CharacterAniVontroller[prefab.Key];
            }
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
