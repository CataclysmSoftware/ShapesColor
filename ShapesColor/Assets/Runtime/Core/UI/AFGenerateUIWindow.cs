using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
public class AFGenerateUIWindow : EditorWindow
{
	private enum UIType
	{
		Screen,
		Panel
	}

	private Dictionary<string, Type> components = new Dictionary<string, Type>();

	private List<Type> typesPrincipale = new List<Type>
	{
		typeof(Slider),
		typeof(Scrollbar),
		typeof(Dropdown)
	};

	private List<Type> types = new List<Type>
	{
		typeof(InputField),
		typeof(ScrollRect),
		typeof(Button),
		typeof(Image),
		typeof(Text),
		typeof(Transform)
	};

	[MenuItem("Window/UIGenerator")]
	public static void ShowWindow()
	{
		GetWindow<AFGenerateUIWindow>("UIGenerator");
	}

	public void OnGUI()
	{
		var obj = (GameObject)Selection.activeObject;
		if (obj == null)
		{
			GUILayout.Label("\nNull\n");
		}
		else
		{
			GUILayout.Label("\n" + obj.name + "\n");
		}

		if (GUILayout.Button("Generate screen"))
		{
			GenerateScreen((GameObject)Selection.activeObject);
		}

		if (GUILayout.Button("Generate panel"))
		{
			GeneratePanel((GameObject)Selection.activeObject);
		}
	}

	private void CreateDirectory(UIType type)
	{
		if (!Directory.Exists("Assets/Runtime"))
		{
			Directory.CreateDirectory("Assets/Runtime");
		}
		if (!Directory.Exists("Assets/Runtime/UI"))
		{
			Directory.CreateDirectory("Assets/Runtime/UI");
		}

		if (type == UIType.Screen)
		{

			if (!Directory.Exists("Assets/Runtime/UI/Screens"))
			{
				Directory.CreateDirectory("Assets/Runtime/UI/Screens");
			}
			if (!Directory.Exists("Assets/Runtime/UI/Screens/Components"))
			{
				Directory.CreateDirectory("Assets/Runtime/UI/Screens/Components");
			}
		}
		else if (type == UIType.Panel)
		{
			if (!Directory.Exists("Assets/Runtime/UI/Panels"))
			{
				Directory.CreateDirectory("Assets/Runtime/UI/Panels");
			}
			if (!Directory.Exists("Assets/Runtime/UI/Panels/Components"))
			{
				Directory.CreateDirectory("Assets/Runtime/UI/Panels/Components");
			}
		}
	}

	private void GeneratePanel(GameObject gameObject)
	{
		CreateDirectory(UIType.Panel);

		var path = "Assets/Runtime/UI/Panels/Components/UI" + gameObject.name + "PanelComponents.cs";

		var content = "";

		content += "using System.Collections; " +
					"\nusing System.Collections.Generic;" +
					"\nusing UnityEngine;" +
					"\nusing UnityEngine.UI; \n\n";

		content += "public class UI" + gameObject.name + "PanelComponents : AFMonoBehaviour" +
					"\n" +
					"{\n";

		GetComponents(gameObject, "");

		foreach (var el in components)
		{
			content += "\tpublic " + el.Value.Name + " " + GetName(el.Key) + "{ get; protected set; }\n";
		}

		content += "\n\tprivate void Awake()\n\t{\n";

		foreach (var el in components)
		{
			content += "\t\t" + GetName(el.Key) + " = transform.Find(\"" + el.Key + "\").GetComponent<" + el.Value.Name + ">();\n";
		}

		content += "\t}\n";

		content += "}";
		File.Delete(path);
		File.WriteAllText(path, content);
		AssetDatabase.Refresh();

		GeneratePanelController(gameObject);

		var type = Type.GetType("UI" + gameObject.name + "PanelComponents,Assembly-CSharp");
		if (!gameObject.TryGetComponent(type, out Component _))
		{
			gameObject.AddComponent(type);
		}
	}

	public void GenerateScreen(GameObject gameObject)
	{
		CreateDirectory(UIType.Screen);

		var path = "Assets/Runtime/UI/Screens/Components/UI" + gameObject.name + "ScreenComponents.cs";

		var content = "";

		content += "using System.Collections; " +
					"\nusing System.Collections.Generic;" +
					"\nusing UnityEngine;" +
					"\nusing UnityEngine.UI; \n\n";

		content += "public class UI" + gameObject.name + "ScreenComponents : AFMonoBehaviour" +
					"\n" +
					"{\n";

		GetComponents(gameObject, "");

		foreach (var el in components)
		{
			content += "\tpublic " + el.Value.Name + " " + GetName(el.Key) + "{ get; protected set; }\n";
		}

		content += "\n\tprivate void Awake()\n\t{\n";

		foreach (var el in components)
		{
			content += "\t\t" + GetName(el.Key) + " = transform.Find(\"" + el.Key + "\").GetComponent<" + el.Value.Name + ">();\n";
		}

		content += "\t}\n";

		content += "}";
		File.Delete(path);
		File.WriteAllText(path, content);
		AssetDatabase.Refresh();

		var type = Type.GetType("UI" + gameObject.name + "ScreenComponents,Assembly-CSharp");

		if (!gameObject.TryGetComponent(type, out Component _))
		{
			gameObject.AddComponent(type);
		}

		GenerateScreenController(gameObject);
	}

	private void GeneratePanelController(GameObject gameObject)
	{
		var path = "Assets/Runtime/UI/Panels/UI" + gameObject.name + "PanelController.cs";

		if (!File.Exists(path))
		{
			var content = "";

			content += "using System.Collections; " +
						"\nusing System.Collections.Generic;" +
						"\nusing UnityEngine;\n\n";

			content += "public class UI" + gameObject.name + "PanelController : AFScreen" +
						"\n" +
						"{\n";

			content += "\tprivate UI" + gameObject.name + "PanelComponents view;\n\n";

			content += "\tprivate void Awake()\n\t{\n";

			content += "\t\tbase.Awake();\n" +
				"\t\tview = GetComponent<UI" + gameObject.name + "PanelComponents>();\n";

			content += "\t}\n";

			content += "}";
			File.Delete(path);
			File.WriteAllText(path, content);
			AssetDatabase.Refresh();

			var type = Type.GetType("UI" + gameObject.name + "PanelController,Assembly-CSharp");

			if (!gameObject.TryGetComponent(type, out Component _))
			{
				gameObject.AddComponent(type);
			}
		}
	}

	private void GenerateScreenController(GameObject gameObject)
	{
		var path = "Assets/Runtime/UI/Screens/UI" + gameObject.name + "ScreenController.cs";

		if (!File.Exists(path))
		{
			var content = "";

			content += "using System.Collections; " +
						"\nusing System.Collections.Generic;" +
						"\nusing UnityEngine;\n\n";

			content += "public class UI" + gameObject.name + "ScreenController : AFScreen" +
						"\n" +
						"{\n";


			content += "\tprivate UI" + gameObject.name + "ScreenComponents view;\n\n";

			content += "\tprivate void Awake()\n\t{\n";

			content += "\t\tbase.Awake();\n" +
				"\t\tview = GetComponent<UI" + gameObject.name + "ScreenComponents>();\n";

			content += "\t}\n";

			content += "}";
			File.Delete(path);
			File.WriteAllText(path, content);
			AssetDatabase.Refresh();

			var type = Type.GetType("UI" + gameObject.name + "ScreenController,Assembly-CSharp");

			if (!gameObject.TryGetComponent(type, out Component _))
			{
				gameObject.AddComponent(type);
			}
		}
	}

	private Type GetComponentType(GameObject gameObject)
	{
		foreach (var type in typesPrincipale)
		{
			var component = gameObject.GetComponent(type);
			if (component != null)
			{
				return component.GetType();
			}
		}

		foreach (var type in types)
		{
			var component = gameObject.GetComponent(type);
			if (component != null)
			{
				return component.GetType();
			}
		}

		return typeof(Transform);
	}

	private void GetComponents(GameObject gameObject, string path)
	{
		var objectPath = path;
		foreach (Transform UIObject in gameObject.transform.GetComponentInChildren<Transform>(true))
		{
			var type = GetComponentType(UIObject.gameObject);
			components[objectPath + UIObject.name] = type;
			if (!typesPrincipale.Contains(type))
			{
				GetComponents(UIObject.gameObject, path + UIObject.name + "/");
			}
			else
			{
				path = "";
			}
		}
	}

	private string GetName(string name)
	{
		return "UI" + name.Replace(" ", "").Replace("/", "");
	}
}
#endif