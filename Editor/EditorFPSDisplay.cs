// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
//
// **************************************************************** //

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace RimuruDev
{
    [InitializeOnLoad]
    public sealed class EditorFPSDisplay
    {
        private static float fps;
        private static int frameCount;
        private static double lastUpdateTime;
        private static bool subscribed;

        private const float oneSecond = 1f;
        private static readonly Rect rect = new(10, 10, 100, 50);

        static EditorFPSDisplay()
        {
            Subscribe();

            AssemblyReloadEvents.beforeAssemblyReload -= Unsubscribe;
            AssemblyReloadEvents.beforeAssemblyReload += Unsubscribe;

            EditorApplication.quitting -= Unsubscribe;
            EditorApplication.quitting += Unsubscribe;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Initialize()
        {
            Unsubscribe();

            fps = 0f;
            frameCount = 0;
            lastUpdateTime = EditorApplication.timeSinceStartup;

            Subscribe();
        }

        private static void Subscribe()
        {
            if (subscribed)
                return;

            subscribed = true;
            
            EditorApplication.update += Update;
            SceneView.duringSceneGui += OnSceneGui;
        }

        private static void Unsubscribe()
        {
            if (!subscribed)
                return;

            subscribed = false;
            
            EditorApplication.update -= Update;
            SceneView.duringSceneGui -= OnSceneGui;
        }

        private static void Update()
        {
            frameCount++;
            
            var timeNow = EditorApplication.timeSinceStartup;
            var delta = timeNow - lastUpdateTime;

            if (!(delta >= oneSecond))
                return;
            
            fps = frameCount / (float)delta;
            frameCount = 0;
            lastUpdateTime = timeNow;
        }

        private static void OnSceneGui(SceneView sceneView)
        {
            Handles.BeginGUI();
            {
                GUILayout.BeginArea(rect);
                {
                    GUILayout.Label($"FPS: {fps:F1}", EditorStyles.whiteLabel);
                }
                GUILayout.EndArea();
            }
            Handles.EndGUI();
        }
    }
}
#endif