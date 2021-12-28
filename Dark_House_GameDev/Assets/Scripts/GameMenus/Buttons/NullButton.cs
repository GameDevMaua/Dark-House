// using System;
// using GameMenus.Implementations;
// using UnityEngine;
// using UnityEngine.EventSystems;
//
// namespace GameMenus.Buttons
// {
//     public class NullButton : BaseButton
//     {
//         public static Transform Parent;
//         private static NullButton _instace;
//         public static NullButton Instance
//         {
//             get
//             {
//
//                 if (_instace is null)
//                 {
//                     _instace = GameObject.FindObjectOfType<NullButton>();
//                 }
//
//                 if (_instace is null)
//                 {
//                     var gameObj = new GameObject("NullButton")
//                     {
//                         transform =
//                         {
//                             parent = Parent
//                         }
//                     };
//                     _instace = gameObj.AddComponent<NullButton>();
//                 }
//
//                 return _instace;
//             }
//         }
//
//         public void Inject(MenuTemplateBase menuTemplateBase, MenuManager menuManager,BaseButton first, BaseButton last)
//         {
//             _downButton = first;
//             _upButton = last;
//             base.Inject(menuTemplateBase, menuManager);
//         }
//     }
// }