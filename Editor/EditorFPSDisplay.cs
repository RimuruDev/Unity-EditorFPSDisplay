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
using UnityEngine;
using UnityEditor;

namespace RimuruDev
{
    [InitializeOnLoad]
    public sealed class EditorFPSDisplay
    {
        private static float fps;
        private static int frameCount;
        private const float OneSecond = 1;
        private static double lastUpdateTime;
        private static readonly Rect rect = new(10, 10, 100, 50);

        static EditorFPSDisplay()
        {
            EditorApplication.update += Update;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        ~EditorFPSDisplay()
        {
            EditorApplication.update -= Update;
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private static void Update()
        {
            frameCount++;
            var timeNow = EditorApplication.timeSinceStartup;

            if (timeNow - lastUpdateTime >= OneSecond)
            {
                fps = frameCount / (float)(timeNow - lastUpdateTime);
                frameCount = 0;
                lastUpdateTime = timeNow;
            }
        }

        private static void OnSceneGUI(SceneView sceneView)
        {
            Handles.BeginGUI();
            GUILayout.BeginArea(rect);
            GUILayout.Label($"FPS: {fps:F1}", EditorStyles.whiteLabel);
            GUILayout.EndArea();
            Handles.EndGUI();
        }
    }
}
#endif