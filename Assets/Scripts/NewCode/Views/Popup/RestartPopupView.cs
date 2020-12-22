using System;

namespace Scripts.Views.Popup
{
    public class RestartPopupView : PopupView
    {
        public void Show(string message, Action restart,Action menu, Action closed)
        {
            this._messageText.text = message;
            this._buttons[0].onClick.AddListener(() =>
            {
                Destroy(this.gameObject, this.Hide());
                restart();
            });
            this._buttons[1].onClick.AddListener(() =>
            {
                Destroy(this.gameObject, this.Hide());
                menu();
            });
            base.Show();

        }
    }
}
