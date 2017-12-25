//Created by Luong Van Tuyen,PL
//Created date Dec 06 2007
//Propose:Manage and make message about the most of errors in Taxi Software
using System;
using System.Runtime.Serialization;

namespace Taxi.Exceptions
{
    [Serializable]
    public class EFilingException : Exception
    {
        private MessageBox.MessageBoxBA  oMessageBox = new MessageBox.MessageBoxBA();

        /// <summary>
        /// Initializes a new instance of the EFilingException class with default properties.
        /// </summary>
        public EFilingException()
        { }
        /// <summary>
        /// Initializes a new instance of the EFilingException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public EFilingException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the EFilingException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. If the inner parameter is not a null reference (<b>Nothing</b> in Visual Basic), the current exception is raised in a catch block that handles the inner exception.</param>
        public EFilingException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Initializes a new instance of the EFilingException class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected EFilingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
