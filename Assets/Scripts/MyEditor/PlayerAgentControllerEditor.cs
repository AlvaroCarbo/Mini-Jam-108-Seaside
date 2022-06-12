using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace MyEditor
{
    [CustomEditor(typeof(PlayerAgentController))]
    public class PlayerAgentControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();

            PlayerAgentController myScript = (PlayerAgentController) target;
            EditorGUILayout.LabelField("Agent Controller", EditorStyles.boldLabel);
        
            if (Application.isPlaying)
            {
                myScript.gameObject.GetComponent<NavMeshAgent>().destination = EditorGUILayout.Vector3Field("Destination", myScript.Target);
                // if (GUILayout.Button("Set Destination"))
                // {
                //     myScript.SetNavMeshAgentDestination(myScript.Target);
                // }
            
            }
        }
    }
}