using UnityEditor;
using UnityEngine;

namespace Utils
{
	public class MixamoRenameUtils
	{
		[MenuItem("Utils/Rename Selected Objects (with children)")]
		private static void RenameSelectedObjects()
		{
			foreach (GameObject obj in Selection.gameObjects)
			{
				if (obj == null) continue;
				RenameRecursive(obj.transform);
			}
		}

		private static void RenameRecursive(Transform target)
		{
			string oldName = target.name;
			if (oldName.Contains("mixamorig"))
			{
				string newName = oldName.Replace("mixamorig", "mixamorig2");
				Undo.RecordObject(target.gameObject, "Rename Object");
				target.name = newName;
				Debug.Log($"Переименован: {oldName} → {newName}");
			}

			foreach (Transform child in target)
			{
				RenameRecursive(child);
			}
		}

		[MenuItem("Utils/Rename Selected Objects (with children)", true)]
		private static bool ValidateRenameSelectedObjects()
		{
			return Selection.gameObjects != null && Selection.gameObjects.Length > 0;
		}
	}
}