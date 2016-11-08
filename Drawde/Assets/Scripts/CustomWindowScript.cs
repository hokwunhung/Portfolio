
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CustomWindowScript : EditorWindow 
{
	private string prefabName;
    private string newtagName;
	private string tagName;
	private bool lookatObj = true;
	private bool objChild = true;
	private Object GameObjectPrefab;
    private GameObject[] parents;
    private GameObject[] selections;
    private bool selectPrefab = true;
	private bool tagGroupEnabled = true;
	private bool selGroupEnabled;
    private float offsetMIN = -100f;
    private float offsetMAX = 100f;
    private float offsetX;
    private float offsetY;
    private float offsetZ;

	
	[MenuItem("CustomTool/EmptyObjectCreator")]

	private static void Init()
	{
		CustomWindowScript window = (CustomWindowScript)EditorWindow.GetWindow (typeof(CustomWindowScript));
		window.Show ();
	}

	private void OnGUI()
	{
		GUILayout.Label ("Prefab Creator", EditorStyles.boldLabel);
		GUILayout.Label ("↓ Prefab Object ↓");
		GameObjectPrefab = EditorGUILayout.ObjectField(GameObjectPrefab, typeof(Object), true);
		objChild = EditorGUILayout.Toggle ("Prefab as Child", objChild);
		lookatObj = EditorGUILayout.Toggle ("Look at Object", lookatObj);
        selectPrefab = EditorGUILayout.Toggle("Select Prefab", selectPrefab);
        prefabName = EditorGUILayout.TextField("Set Name", prefabName);
        newtagName = EditorGUILayout.TagField("Set Tag Name", newtagName);
        offsetMIN = EditorGUILayout.FloatField ("Offset Minimum", offsetMIN);
		offsetMAX = EditorGUILayout.FloatField ("Offset Maximum", offsetMAX);
		offsetX = EditorGUILayout.Slider("Offset X", offsetX, offsetMIN, offsetMAX);
		offsetY = EditorGUILayout.Slider("Offset Y", offsetY, offsetMIN, offsetMAX);
		offsetZ = EditorGUILayout.Slider("Offset Z", offsetZ, offsetMIN, offsetMAX);



		selGroupEnabled = EditorGUILayout.BeginToggleGroup("Selection Option",selGroupEnabled);
        Vector3 offsetPosition = new Vector3(offsetX, offsetY, offsetZ);
        List<GameObject> pick = new List<GameObject>();
        if (GUILayout.Button ("Create Prefab Via Selection")) 
		{
            selections = Selection.gameObjects;
            foreach (GameObject sel in selections)
            {
                if (newtagName != "")
                {
                    GameObject prefab = Instantiate(GameObjectPrefab, sel.transform.position + offsetPosition, Quaternion.identity) as GameObject;
                    prefab.tag = newtagName;
                    pick.Add(prefab);
                    if (prefabName != "")
                        prefab.name = prefabName;
                    if (lookatObj)
                        prefab.transform.LookAt(sel.transform);
                    if (objChild)
                        prefab.transform.parent = sel.transform;
                }

            }
            if (selectPrefab)
                Selection.objects = pick.ToArray();
        }
		EditorGUILayout.EndToggleGroup();


		tagGroupEnabled = EditorGUILayout.BeginToggleGroup("Tag Option", tagGroupEnabled);
		tagName = EditorGUILayout.TagField("Tag Name", tagName);

		if (GUILayout.Button ("Create Prefab Via Tag"))
		{     
			parents = GameObject.FindGameObjectsWithTag(tagName);
            foreach (GameObject parent in parents)
            {
                if (newtagName != "")
                {
                    GameObject prefab = Instantiate(GameObjectPrefab, parent.transform.position + offsetPosition, Quaternion.identity) as GameObject;
                    prefab.tag = newtagName;
                    pick.Add(prefab);
                    if (prefabName != "")
                        prefab.name = prefabName;
                    if (lookatObj)
                        prefab.transform.LookAt(parent.transform);
                    if (objChild)
                        prefab.transform.parent = parent.transform;
                }
            }
            if (selectPrefab)
                Selection.objects = pick.ToArray();

        }
		EditorGUILayout.EndToggleGroup();
        

		if (tagGroupEnabled == true)
			selGroupEnabled = false;
		if (tagGroupEnabled == false)
			selGroupEnabled = true;
        pick.Clear();


            Repaint ();
	}
	//http://docs.unity3d.com/ScriptReference/EditorWindow.html
}
