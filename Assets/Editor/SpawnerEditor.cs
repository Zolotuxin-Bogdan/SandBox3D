using UnityEngine;
using UnityEditor;
using Assets.SpawnSystem;

namespace Assets.Editor
{
    [CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : UnityEditor.Editor {
        Spawner m_Target;
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();           
        }
        private void OnSceneGUI() {
            m_Target = (Spawner)target;

            GUIStyle textStyle = new GUIStyle();
            textStyle.fontSize = 14;
            textStyle.fontStyle = FontStyle.Bold;
            textStyle.normal.textColor = Color.white;
            textStyle.alignment = TextAnchor.MiddleCenter;

            Handles.Label(m_Target.transform.position + Vector3.down, "Spawner\n" + m_Target.transform.position.ToString(), textStyle);
            Handles.color = Color.green;
            Handles.DrawWireCube(m_Target.transform.position, m_Target.transform.localScale);

            Handles.Label(m_Target.spawnPoint + Vector3.down * 0.5f, "Spawn point", textStyle);
            Handles.DrawWireCube(m_Target.spawnPoint, m_Target.transform.localScale * 0.5f);
            Handles.color = Color.cyan;
            Handles.DrawDottedLine(m_Target.transform.position, m_Target.spawnPoint, 5);
        }
    }
}