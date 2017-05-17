#region ScriptableWizard

using UnityEditor;

public class ExampleScriptableWizard : ScriptableWizard
{
    [MenuItem("Window/ExampleScriptableWizard")]
    static void Open()
    {
        DisplayWizard<ExampleScriptableWizard>("Example Wizard");
    }
}
#endregion