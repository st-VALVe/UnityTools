using UnityEditor;
using UnityEngine;

namespace Editor
{
    [ExecuteAlways]
    public class AlignSceneViewToGame : MonoBehaviour
    {
        private static Camera _mainCam;

        [MenuItem("GameObject/Align Scene View To Game %#&f")]
        private static void AlignSceneCameraToGameView()
        {
            _mainCam = Camera.main;
            if (_mainCam == null) return;
            
            var settings = new SceneView.CameraSettings
            {
                fieldOfView = _mainCam.fieldOfView,
                nearClip = _mainCam.nearClipPlane,
                farClip = _mainCam.farClipPlane
            };

            var sceneView = SceneView.lastActiveSceneView;
            sceneView.cameraSettings = settings;

            var mainCamTransform = _mainCam.transform;
            sceneView.AlignViewToObject(mainCamTransform);
        }
    }
}