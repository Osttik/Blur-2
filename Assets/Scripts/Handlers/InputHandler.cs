using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Handlers
{
    public class InputHandler
    {
        public VoidFunction OnButtonPush { get; set; }
        public VoidFunction AfterButtonClick { get; set; }
        public VoidFunction OnButtonClick { get; set; }
        public delegate void VoidFunction();

        private bool _isClicked;

        public InputHandler()
        {
            OnButtonClick = new VoidFunction(Kastul);
            OnButtonPush = new VoidFunction(Kastul);
            AfterButtonClick = new VoidFunction(Kastul);

            _isClicked = false;
        }

        public void Click(bool isClicked)
        {
            if (_isClicked && isClicked)
            {
                OnButtonPush.Invoke();
            }

            if (!_isClicked && isClicked)
            {
                OnButtonClick.Invoke();
                _isClicked = true;
            }

            if (_isClicked && !isClicked)
            {
                AfterButtonClick.Invoke();
                _isClicked = false;
            }
        }

        private void Kastul() { }
    }
}
