using UnityEngine;
using System.Collections;
using System.Reflection;
using UnityEditor;
/// <summary>
/// 预览的使用
/// </summary>
[CustomEditor(typeof(PreviewExample))]
public class PreviewExampleInspector : Editor {
    #region 基础知识
    // 显示预览
    //public override bool HasPreviewGUI()
    //{
    //    return true;
    //}

    // 标签
    //public override GUIContent GetPreviewTitle()
    //{
    //    return new GUIContent("测试预览");
    //}

    // 预览设置
    //public override void OnPreviewSettings()
    //{
    //    GUIStyle preLabel = new GUIStyle("preLabel");
    //    GUIStyle preButton = new GUIStyle("preButton");

    //    GUILayout.Label("预览label", preLabel);
    //    GUILayout.Button("预览button", preButton);
    //}
    // 预览效果
    //public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    //{
    //    GUI.Box(r, "预览");
    //}
    #endregion

    #region 预览摄像机
    //private PreviewRenderUtility previewRenderUtility;
    //private GameObject previewObject;

    //void OnEnable()
    //{
    //    // 真正绘制场景中的对象
    //    previewRenderUtility = new PreviewRenderUtility(true);

    //    // 设置fieldofview
    //    previewRenderUtility.m_CameraFieldOfView = 30f;

    //    // 设置剪切面
    //    previewRenderUtility.m_Camera.nearClipPlane = 0.3f;
    //    previewRenderUtility.m_Camera.farClipPlane = 1000;

    //    // 获得上方的游戏组件
    //    var component = (Component)target;
    //    previewObject = component.gameObject;
    //}

    //public override bool HasPreviewGUI()
    //{
    //    return true;
    //}

    //public override void OnPreviewGUI(Rect r, GUIStyle background)
    //{
    //    previewRenderUtility.BeginPreview(r, background);
    //    var previewCamera = previewRenderUtility.m_Camera;
    //    previewCamera.transform.position = previewObject.transform.position + new Vector3(0, 2.5f, -5);
    //    previewCamera.transform.LookAt(previewObject.transform);
    //    previewCamera.Render();
    //    previewRenderUtility.EndAndDrawPreview(r);
    //}
    #endregion

    #region 创建一个预览对象
    private PreviewRenderUtility previewRenderUtility;
    private GameObject previewObject;

    void OnEnable()
    {
        var component = (Component) target;
        previewObject = Instantiate(component.gameObject);
        previewObject.hideFlags = HideFlags.HideAndDontSave;
        previewObject.SetActive(false);

        var flags = BindingFlags.Static | BindingFlags.NonPublic;
        var propInfo = typeof(Camera).GetProperty("PreviewCullingLayer", flags);
        int previewLayer = (int) propInfo.GetValue(null, new object[0]);

        previewRenderUtility = new PreviewRenderUtility(true);
        previewRenderUtility.m_Camera.cullingMask = 1 << previewLayer;

        previewObject.layer = previewLayer;
        foreach (Transform transform in previewObject.transform)
        {
            transform.gameObject.layer = previewLayer;
        }
    }

    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        previewRenderUtility.BeginPreview(r, background);
        previewObject.SetActive(true);
        previewRenderUtility.m_Camera.Render();
        previewObject.SetActive(false);
        previewRenderUtility.EndAndDrawPreview(r);
    }

    #endregion
}
