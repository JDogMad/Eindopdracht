using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht {
    // Dit is een eigen event geschreven om een fout op te vangen.
    internal class MyEvent {
        public delegate void FoutHandler();

        public event FoutHandler foutOpvangen; 

        public void FoutHandlerMethode() {
            FoutMelding();
        }

        protected virtual void FoutMelding() {
            foutOpvangen?.Invoke();
        }
    }
}
