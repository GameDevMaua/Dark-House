using Player;
using UnityEngine;

namespace Audio_Guides{
    public class AudioGuideGizmos : MonoBehaviour
    {
        private void Awake() {
            transform.position = new Vector3(transform.position.x, transform.position.y, PlayerSingleton.Instance.transform.position.z - 0.5f);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }
    }
}
