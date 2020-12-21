using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Controllers.Popup
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private string _message;
        [SerializeField] private Text _messageText;
        [SerializeField] private List<string> _buttonTexts;
        [SerializeField] private List<Button> _buttons;



        public void Show()
        {
            //this.transform.DOScale(1, 1);
        }
        public void Hide()
        {
            //this.transform.DOScale(0, 1);
        }
    }
}
