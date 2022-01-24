

using UnityEngine;

namespace Game_Scripts.Scriptable_Objects{
    [CreateAssetMenu(menuName = "Serializable_Dictionary/StringSoundDictionary")]
    public class StringSoundDictionary : SerializableDictionary<string,AudioClip>{
        
    }
}