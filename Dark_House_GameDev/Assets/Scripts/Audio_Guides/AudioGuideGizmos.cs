using UnityEngine;

namespace Audio_Guides{
    public class AudioGuideGizmos : MonoBehaviour
    {
        private void OnDrawGizmos() {
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }
    }
}
