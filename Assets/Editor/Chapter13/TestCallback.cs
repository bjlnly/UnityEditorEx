using System;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor.iOS.Xcode;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.Networking;
using Object = UnityEngine.Object;


public class TestCallback{
    #region PostProcessBuild

    // 在build结束调用
    // 可按照顺序调用，从0开始
    [PostProcessBuild(1)]
    static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        if (buildTarget != BuildTarget.iOS)
            return;

        //Xcode プロジェクトのパスを取得
        var xcodeprojPath = Path.Combine(path, "Unity-iPhone.xcodeproj");
        var pbxprojPath = Path.Combine(xcodeprojPath, "project.pbxproj");

        //Xcode プロジェクトロード
        PBXProject proj = new PBXProject();
        proj.ReadFromFile(pbxprojPath);

        var target = proj.TargetGuidByName("Unity-iPhone");

        proj.AddFrameworkToProject(target, "Social.framework", false);
        proj.WriteToFile(pbxprojPath);
    }

    #endregion


    #region PostProcessScene
    //场景加载时调用
    [PostProcessScene]
    static void OnPostProcessScene()
    {
        // 加载场景时候加载模型
        ////foreach (var sceneSetup in EditorSceneManager.GetSceneManagerSetup())
        //{
        //    var scene = EditorSceneManager.GetActiveScene();//EditorSceneManager.GetSceneByPath(sceneSetup.path);
        //    var go = new GameObject("OnPostProcessScene: " + scene.name);

        //    EditorSceneManager.MoveGameObjectToScene(go,scene);
        //}
        // 打印场景path
        //foreach (var sceneSetup in EditorSceneManager.GetSceneManagerSetup())
        //{
        //    Debug.Log(sceneSetup.path);
        //}
    }
    #endregion
}
//启动编辑器或编译脚本后调用
[InitializeOnLoad]
public class TestInitializeOnLoad
{
    static TestInitializeOnLoad()
    {
        //// 点击play也会调用
        //if (EditorApplication.isPlayingOrWillChangePlaymode)
        //{
        //    return;
        //}
        //Debug.Log("call");

        // 启动编辑器时候执行
        // 启动10s以后就不执行
        if (10 < EditorApplication.timeSinceStartup)
        {
            return;
        }
        Debug.Log("启动编辑器时候调用");
    }

    #region InitializeOnLoadMethod
    // initializeonload的函数版本
    // eg.无法指定执行顺序
    [InitializeOnLoadMethod]
    static void RunMethod()
    {
        Debug.Log("方法调用");
    }
    #endregion

    #region DidReloadScripts

    // 可控制执行顺序的InitializeOnLoadMethod
    // 升序原则
    [DidReloadScripts(0)]
    static void First()
    {
        Debug.Log("first");
    }
    [DidReloadScripts(1)]
    static void Second()
    {
        Debug.Log("Second");
    }
    #endregion

    #region EditorUserBuildSettings.SwitchActiveBuildTarget
    // eg.根据平台不同修改包名
    [InitializeOnLoadMethod]
    static void ChangeBundleIdentifier()
    {
        EditorUserBuildSettings.activeBuildTargetChanged += () =>
        {
            var bundleIdentifier = "com.kyusyukeigo.superapp";

            switch (EditorUserBuildSettings.activeBuildTarget)
            {
                case BuildTarget.iOS:
                    bundleIdentifier += ".ios";
                    break;
                case BuildTarget.Android:
                    bundleIdentifier += ".android";
                    break;
                case BuildTarget.WSAPlayer:
                    bundleIdentifier += ".wp";
                    break;
                default:
                    break;
            }

            if (Debug.isDebugBuild)
            {
                bundleIdentifier += ".dev";
            }

            PlayerSettings.bundleIdentifier = bundleIdentifier;
        };
    }

    #endregion

    #region EditorApplication.hierarchyWindowChanged/projectWindowChanged

    // 层级结构或项目配置发生更改时候调用
    [InitializeOnLoadMethod]
    static void DrawCameraNames()
    {

        var selected = 0;
        var displayNames = new string[0];
        var windowRect = new Rect(10, 20, 200, 24);

        //Hierarchy有修改
        EditorApplication.hierarchyWindowChanged += () =>
        {
            var cameras = Object.FindObjectsOfType<Camera>();
            var cameraNames = new string[0];

            // 多场景的时候，可以把握在哪个场景的相机
            if (1 < EditorSceneManager.loadedSceneCount)
            {
                //Main Camera (Stage 1.unity) 标记场景名字
                cameraNames =
                    cameras.Select(camera => new
                        {
                            cameraName = camera.name,
                            sceneName = Path.GetFileName(AssetDatabase.GetAssetOrScenePath(camera))
                        })
                        .Select(x => string.Format("{0} ({1})", x.cameraName, x.sceneName))
                        .ToArray();
            }
            else
                cameraNames = cameras.Select(c => c.name).ToArray();

            displayNames = new[] { "None", "" };
            ArrayUtility.AddRange(ref displayNames, cameraNames);
        };

        //任意时候调用
        EditorApplication.hierarchyWindowChanged();

        //Scene视图的GUI处理
        SceneView.onSceneGUIDelegate += (sceneView) =>
        {
            var cameras = Object.FindObjectsOfType<Camera>();

            GUI.skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);

            Handles.BeginGUI();

            int windowID =
                GUIUtility.GetControlID(FocusType.Passive, windowRect);
            //镜头视图窗口追加
            windowRect = GUILayout.Window(windowID, windowRect, (id) =>
            {

                selected = EditorGUILayout.Popup(selected, displayNames);

                //可以拖动
                GUI.DragWindow();

            }, "Window");

            Handles.EndGUI();
            int index = selected - 2;


            if (index >= 0)
            {
                var camera = cameras[index];
                camera.transform.position = sceneView.camera.transform.position;
                camera.transform.rotation = sceneView.camera.transform.rotation;
            }
        };
    }
    #endregion

    #region EditorApplication.hierarchyWindowItemOnGUI/projectWindowItemOnGUI
    // 获取每个游戏对象或资产的每个角色，可用于显示游戏对象信息
    [InitializeOnLoadMethod]
    static void DrawComponetIcons()
    {
        EditorApplication.hierarchyWindowItemOnGUI += (instanceID, selectionRect) =>
        {
            var go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
            if (go == null)
            {
                return;
            }

            var position = new Rect(selectionRect)
            {
                width = 16,
                height = 16,
                x = Screen.width - 20
            };

            foreach (var component in go.GetComponents<Component>())
            {
                if (component is Transform)
                {   
                    continue;
                }

                var icon = AssetPreview.GetMiniThumbnail(component);

                GUI.Label(position, icon);
                position.x -= 16;
            }
        };
    }
    #endregion

    #region EditorApplication.playmodeStateChanged
    //播放模式切换时候调用，但是无法确认当前状态是什么
    [InitializeOnLoadMethod]
    static void CheckPlaymodeState()
    {
        EditorApplication.playmodeStateChanged += () =>
        {
            if (EditorApplication.isPaused)
            {
                //暂停
                Debug.Log("暂停");
            }

            if (EditorApplication.isPlaying)
            {
                //播放中
                Debug.Log("播放中");
            }

            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                // 在播放中或者点击播放按钮后进行编译或者各种处理的状态
                // 此外，播放停止也会调用
                Debug.Log("isPlayingOrWillChangePlaymode");
            }
        };
    }
    #endregion

    #region EditorApplication.update

[MenuItem("Assets/Example/Get Texture")]
    static void TestWWW()
    {
        //画像の URL
        var www = UnityWebRequest.GetTexture("http://placehold.it/350x150");

        //画像を取得して保存する
        EditorUnityWebRequest(www, () =>
        {
            var downloadHandler = (DownloadHandlerTexture)www.downloadHandler;
            var assetPath = "Assets/New Texture.png";
            File.WriteAllBytes(assetPath, downloadHandler.data);
            AssetDatabase.ImportAsset(assetPath);
        });
    }

    static void EditorUnityWebRequest(UnityWebRequest www, Action callback)
    {
        www.Send();
        EditorApplication.CallbackFunction update = null;

        update = () =>
        {
            //毎フレームチェック
            if (www.isDone && string.IsNullOrEmpty(www.error))
            {
                callback();
                EditorApplication.update -= update;
            }
        };

        EditorApplication.update += update;
    }

    #endregion
    
}

#region 案例： EditorApplication.playmodeStateChanged
// 编译错误播放声音
[InitializeOnLoad]
public class CompileError
{
    private const string musicPath = "Assets/13callback/0.mp3";
    private const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
    
    static CompileError()
    {
        EditorApplication.playmodeStateChanged += () =>
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying)
            {
                return;
            }

            if (SceneView.sceneViews.Count == 0)
            {
                return;
            }
            EditorApplication.delayCall += () =>
            {
                // 贼强，可以获取到unity的filed
                var content =
                    typeof(EditorWindow).GetField("m_Notification", flags)
                        .GetValue(SceneView.sceneViews[0]) as GUIContent;
                if (content != null && !string.IsNullOrEmpty(content.text))
                {
                    GetAudioSource().Play();
                }
            };
        };
    }

    private static AudioSource GetAudioSource()
    {
        var gameObjectName = "HideAudioSourceObject";
        var gameObject = GameObject.Find(gameObjectName);

        if (gameObject==null)
        {
            gameObject =
                EditorUtility.CreateGameObjectWithHideFlags(gameObjectName, HideFlags.HideAndDontSave,
                    typeof(AudioSource));
        }

        var hideAudioSource = gameObject.GetComponent<AudioSource>();

        if (hideAudioSource.clip == null)
        {
            hideAudioSource.clip = AssetDatabase.LoadAssetAtPath(musicPath, typeof(AudioClip)) as AudioClip;
        }

        return hideAudioSource;
    }
}

#endregion
#region EditorApplication.modifierKeysChanged
// 当触发键盘事件时
public class TestmodifierKeysChanged : EditorWindow
{
    [MenuItem("Window/Example/TestmodifierKeysChanged")]
    static void CheckModifierKeysChanged()
    {
        GetWindow<TestmodifierKeysChanged>();
    }

    void OnEnable()
    {
        EditorApplication.modifierKeysChanged += Repaint;
    }

    void OnGUI()
    {
        GUILayout.Label(Event.current.modifiers.ToString());
    }
}

#endregion

#region EditorApplication.update
// 实现自定义回调
[InitializeOnLoad]
class EditorApplicationUtility
{
    public static Action<EditorWindow> focusedWindowChanged;

    static EditorWindow currentFocusedWindow;

    static EditorApplicationUtility()
    {
        EditorApplication.update += FocusedWindowChanged;

    }

    static void FocusedWindowChanged()
    {
        if (currentFocusedWindow != EditorWindow.focusedWindow)
        {
            currentFocusedWindow = EditorWindow.focusedWindow;
            focusedWindowChanged(currentFocusedWindow);
        }
    }
}


[InitializeOnLoad]
public class Test
{
    static Test()
    {
        EditorApplicationUtility.focusedWindowChanged += (window) => {
            Debug.Log(window);
        };
    }
}

#endregion

#region EditorApplication.globalEventHandler
// 除去game视图点击键盘即可查看效果
[InitializeOnLoad]
class EditorApplicationUtilityTest
{
    static BindingFlags flags =
        BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;

    static FieldInfo info = typeof(EditorApplication)
        .GetField("globalEventHandler", flags);

    public static EditorApplication.CallbackFunction globalEventHandler
    {
        get
        {
            return (EditorApplication.CallbackFunction)info.GetValue(null);
        }
        set
        {
            EditorApplication.CallbackFunction functions = (EditorApplication.CallbackFunction)info.GetValue(null);
            functions += value;
            info.SetValue(null, (object)functions);
        }
    }
}


[InitializeOnLoad]
public class TestglobalEventHandler
{
    static TestglobalEventHandler()
    {
        EditorApplicationUtilityTest.globalEventHandler += () => {
            Debug.Log(Event.current);
        };
    }
}

#endregion