using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreDisposeDemo.Services
{
    public class ProgrammerSentenceSvc : IDisposable {
        public List<string> programmersSentences = new List<string>()
        {
            "The trouble with programmers is that you can never tell what" +
            " a programmer is doing until it’s too late",
            "Walking on water and developing software from a specification" + 
            " are easy if both are frozen.",
            "A programming language is low level when its programs" + "" +
            " require attention to the irrelevant.",
            "In theory, theory and practice are the same. In practice, they’re not.",
            "Perl – The only language that looks the same before" + 
            " and after RSA encryption."
        };

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                disposedValue = true;
            }
        }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
    public class EngineerSentenceSvc : IDisposable {
        public List<string> engineersSentences = new List<string>()
        {
            "The best way to get a project done faster is to start sooner",
            "Even the best planning is not so omniscient" + 
            " as to get it right the first time.",
            "Any fool can write code that a computer can " + 
            "understand. Good programmers write code that" + 
            " humans can understand.",
            "Program testing can be used to show the presence" + 
            " of bugs, but never to show their absence!",
            "Prolific programmers contribute to certain disaster."
        };
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
