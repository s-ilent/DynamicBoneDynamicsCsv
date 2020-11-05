using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CIFER.Tech.DynamicBoneDynamicsCsv
{
    public class DynamicBoneDynamicsCsvWindow : EditorWindow
    {
        private static Transform _targetRoot;
        private bool _isDynamicBoneSaveLoad = true, _isColliderSaveLoad = true;

        [MenuItem("Tools/CIFER.Tech/DynamicBoneDynamicsCsv")]
        private static void Open()
        {
            var window = GetWindow<DynamicBoneDynamicsCsvWindow>("DB CSV");
            window.minSize = new Vector2(350f, 200f);

            _targetRoot = GetRootBone();
        }

        private void OnGUI()
        {
            _targetRoot =
                EditorGUILayout.ObjectField("Dynamic Bone Root", _targetRoot, typeof(Transform), true) as Transform;

            if (GUILayout.Button("Set current selection as root"))
            {
                _targetRoot = GetRootBone();
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Configuration", new GUIStyle
            {
                alignment = TextAnchor.MiddleCenter
            });

            _isDynamicBoneSaveLoad = EditorGUILayout.ToggleLeft("Dynamic Bone", _isDynamicBoneSaveLoad);
            _isColliderSaveLoad = EditorGUILayout.ToggleLeft("Dynamic Bone Collider", _isColliderSaveLoad);

            GUILayout.FlexibleSpace();

            //エラー、警告判定
            if (_targetRoot == null)
            {
                EditorGUILayout.HelpBox("Please select the root object.", MessageType.Error);
                return;
            }

            EditorGUILayout.BeginHorizontal();
            {
                //セーブ
                if (GUILayout.Button("Save as..."))
                {
                    var filePath = EditorUtility.SaveFilePanel(
                        "Save Dynamic Bone setup to...", "", $"{_targetRoot.name}_DynamicBone_Dynamics.csv", "csv");
                    if (filePath.Length <= 0)
                        return;

                    var copyData = new DynamicBoneDynamicsCsv.Data
                    {
                        TargetRoot = _targetRoot,
                        IsDynamicBoneSaveLoad = _isDynamicBoneSaveLoad,
                        IsColliderSaveLoad = _isColliderSaveLoad,
                        FilePath = filePath
                    };
                    DynamicBoneDynamicsCsvSaver.CsvSave(copyData);
                }

                //ロード
                if (GUILayout.Button("Load from..."))
                {
                    var filePath = EditorUtility.OpenFilePanelWithFilters(
                        "Load Dynamic Bone setup from...", "", new[] {"CSV file", "csv", "Text file", "txt"});
                    if (filePath.Length <= 0)
                        return;

                    var copyData = new DynamicBoneDynamicsCsv.Data()
                    {
                        TargetRoot = _targetRoot,
                        IsDynamicBoneSaveLoad = _isDynamicBoneSaveLoad,
                        IsColliderSaveLoad = _isColliderSaveLoad,
                        FilePath = filePath,
                    };
                    DynamicBoneDynamicsCsvLoader.CsvLoad(copyData);
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private static Transform GetRootBone()
        {
            return Selection.transforms.Length <= 0 ? null : Selection.transforms.First();
        }
    }
}