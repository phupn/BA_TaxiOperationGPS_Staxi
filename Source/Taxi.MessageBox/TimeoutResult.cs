using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.MessageBox
{
    public enum TimeoutResult
    {
        /// <summary>
        /// On timeout the value associated with the default button is set as the result.
        /// This is the default action on timeout.
        /// </summary>
        Default,

        /// <summary>
        /// On timeout the value associated with the cancel button is set as the result. If
        /// the messagebox does not have a cancel button then the value associated with 
        /// the default button is set as the result.
        /// </summary>
        Cancel,

        /// <summary>
        /// On timeout MessageBoxExResult.Timeout is set as the result.
        /// </summary>
        Timeout
    }
}
