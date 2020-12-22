using UnityEngine;
using Scripts.Views.Popup;
using System;
using System.Collections.Generic;

namespace Scripts.Configurations.Popup
{
    [CreateAssetMenu(fileName = "PopUpSystemConfiguration", menuName = "PopUpSystem/Configuration", order = 1)]
    public class PopupSystem : ScriptableObject
    {
        private readonly Stack<PopupView> _stack = new Stack<PopupView>();

        [SerializeField] private RestartPopupView _restartPopupPrefab;

        public void ShowRestartPopup(string message, Action restart, Action menu)
        {
            RestartPopupView obj = Instantiate(_restartPopupPrefab);
            _stack.Push(obj);
            obj.SortOrder = _stack.Count;
            obj.Show(message, restart, menu, ()=> { _stack.Pop(); });
        }
    }
}
