using UnityEngine;
using System.Collections;

public class DrawIconTest : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "ExampleAsset Icon.jpg", true);
    }
}
