#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ChangeMateriaGpuInstancingONAuto : Editor
{
    private static void ChangeInstance(Material material)
    {

        
        if (!material.enableInstancing)
        {
            try
            {
                Undo.RecordObject(material, "Assigning enableInstancing");
                material.enableInstancing = true;
               
                Debug.Log("<color=green>Successfully Enable ------ </color> =>" + material.name + " --------  " + count++);
            }
            catch
            {
                Debug.Log("<color=red>Failled ------ </color> =>" + material.name);
            }

        }
       
    }
    private static int count = 0;
    [MenuItem("SH Custom/Performence/Change GPU Instancing of All material In Scene _F3")]//with short key
    private static void EnableDisableInstancingOffAllMaterial()
    {
        count = 0;
        Material[][] materials = GameObject.FindObjectsOfType<MeshRenderer>().Select(a => a.sharedMaterials).ToArray();
        List<Material> tem = new List<Material>();
        for (int i = 0; i < materials.Length; i++)
        {
            for(int j = 0; j < materials[i].Length; j++)
            {
                
               
                if (!tem.Contains(materials[i][j]))
                {
                    tem.Add(materials[i][j]);
                    ChangeInstance(materials[i][j]);
                }
                    
            }
        }
    }

    [MenuItem("SH Custom/Performence/Change GPU Instancing of Selected Material In Scene _F4")]//with short key
    private static void EnableDisableInstancingOffSelectedMaterial()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            Material[] materials = Selection.gameObjects[i].GetComponent<MeshRenderer>().sharedMaterials;
            for (int j = 0; j < materials.Length; j++)
            {
                Debug.Log("<color=red>Failled ------ </color> =>" + materials[i].name);
                ChangeInstance(materials[j]);
            }
        }
    }

}
#endif
