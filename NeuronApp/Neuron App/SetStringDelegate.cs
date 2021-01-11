using System;

namespace Neuron_App
{
    internal class SetStringDelegate : Form3
    {
        private Action<string> setResult;

        public SetStringDelegate(Action<string> setResult)
        {
            this.setResult = setResult;
        }
    }
}