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

        [SerializeField] private List<PopupView> _popupViews;

        public void ShowPopup(int id, string message, params Action[] actions)
        {
            PopupView obj = Instantiate(_popupViews[id]);
            _stack.Push(obj);
            obj.SortOrder = _stack.Count;
            obj.Show(message, () => { _stack.Pop(); }, actions);
        }
    }
}
