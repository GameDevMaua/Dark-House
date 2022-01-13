using UnityEngine;

namespace DefaultNamespace
{
    public static class Extensions
    {
        public static GameObject NextChild (this GameObject gameObject)
        {
            // Check where we are
            int thisIndex = gameObject.transform.GetSiblingIndex ();
 
            // We have a few cases to rule out
            if ( gameObject.transform.parent == null )
                return null;
            if ( gameObject.transform.parent.childCount <= thisIndex + 1 )
                return null;
 
            // Then return whatever was next, now that we're sure it's there
            return gameObject.transform.parent.GetChild (thisIndex + 1).gameObject;
        }
        
        public static GameObject PreviewsChild (this GameObject gameObject)
        {
            // Check where we are
            int thisIndex = gameObject.transform.GetSiblingIndex ();
 
            // We have a few cases to rule out
            if ( gameObject.transform.parent == null )
                return null;
            if ( thisIndex <= 0)
                return null;
 
            // Then return whatever was next, now that we're sure it's there
            return gameObject.transform.parent.GetChild (thisIndex - 1).gameObject;
        }
        
        public static GameObject GetLastChildren (this GameObject gameObject)
        {
            
            return gameObject.transform.GetChild(gameObject.transform.childCount-1).gameObject;
        }
        public static GameObject GetFirstChildren (this GameObject gameObject)
        {
            
            return gameObject.transform.GetChild(0).gameObject;
        }
    }
    
   
}