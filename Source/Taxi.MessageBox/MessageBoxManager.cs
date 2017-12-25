using System;
using System.IO;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Threading;

namespace Taxi.MessageBox
{
    public class MessageBoxManager
    {
        #region Fields
		private static Hashtable _messageBoxes = new Hashtable();
		private static Hashtable _savedResponses = new Hashtable();

        private static Hashtable _standardButtonsText = new Hashtable();
		#endregion

        #region Static ctor
        static MessageBoxManager()
        {
            GetMessageButton();
        }
        #endregion

		#region Methods

        public static void GetMessageButton()
        {

            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;                
                Thread.CurrentThread.CurrentCulture = culture;
                ResourceManager rm = new ResourceManager("Taxi.MessageBox.MessageBox", Assembly.GetExecutingAssembly());
                #region Mặc định
                _standardButtonsText[MessageBoxButtonsBA.OK.ToString()] = "Ok";
                _standardButtonsText[MessageBoxButtonsBA.Cancel.ToString()] = "Cancel";
                _standardButtonsText[MessageBoxButtonsBA.Yes.ToString()] = "Yes";
                _standardButtonsText[MessageBoxButtonsBA.No.ToString()] = "No"; _standardButtonsText[MessageBoxButtonsBA.Abort.ToString()] = "Abort";
                _standardButtonsText[MessageBoxButtonsBA.Retry.ToString()] = "Retry";
                _standardButtonsText[MessageBoxButtonsBA.Ignore.ToString()] = "Ignore";
                #endregion
                //Assembly current = typeof(MessageBoxManager).Assembly;
                //string[] resources = current.GetManifestResourceNames();

                //ResourceManager rm = new ResourceManager("Taxi.MessageBox.MessageBox", typeof(MessageBoxManager).Assembly);
                _standardButtonsText[MessageBoxButtonsBA.OK.ToString()] = rm.GetString("Ok");
                _standardButtonsText[MessageBoxButtonsBA.Cancel.ToString()] = rm.GetString("Cancel");
                _standardButtonsText[MessageBoxButtonsBA.Yes.ToString()] = rm.GetString("Yes");
                _standardButtonsText[MessageBoxButtonsBA.No.ToString()] = rm.GetString("No");
                _standardButtonsText[MessageBoxButtonsBA.Abort.ToString()] = rm.GetString("Abort");
                _standardButtonsText[MessageBoxButtonsBA.Retry.ToString()] = rm.GetString("Retry");
                _standardButtonsText[MessageBoxButtonsBA.Ignore.ToString()] = rm.GetString("Ignore");
            }
            catch(Exception ex)
            {
               // System.Diagnostics.Debug.Assert(false, "Unable to load resources for MessageBoxEx", ex.ToString());

                //Load default resources
                _standardButtonsText[MessageBoxButtonsBA.OK.ToString()] = "Ok";
                _standardButtonsText[MessageBoxButtonsBA.Cancel.ToString()] = "Cancel";
                _standardButtonsText[MessageBoxButtonsBA.Yes.ToString()] = "Yes";
                _standardButtonsText[MessageBoxButtonsBA.No.ToString()] = "No";_standardButtonsText[MessageBoxButtonsBA.Abort.ToString()] = "Abort";
                _standardButtonsText[MessageBoxButtonsBA.Retry.ToString()] = "Retry";
                _standardButtonsText[MessageBoxButtonsBA.Ignore.ToString()] = "Ignore";
            }
        }
		/// <summary>
		/// Creates a new message box with the specified name. If null is specified
		/// in the message name then the message box is not managed by the Manager and
		/// will be disposed automatically after a call to Show()
		/// </summary>
		/// <param name="name">The name of the message box</param>
		/// <returns>A new message box</returns>
        /// 
		public static MessageBoxBA CreateMessageBox(string name)
		{
			if(name != null && _messageBoxes.ContainsKey(name))
			{
				string err = string.Format("A MessageBox with the name {0} already exists.",name);
				throw new ArgumentException(err,"name");
			}

            MessageBoxBA msgBox = new MessageBoxBA();
			msgBox.Name = name;
			if(msgBox.Name != null)
			{
				_messageBoxes[name] = msgBox;
			}

			return msgBox;
		}

		/// <summary>
		/// Gets the message box with the specified name
		/// </summary>
		/// <param name="name">The name of the message box to retrieve</param>
		/// <returns>The message box with the specified name or null if a message box
		/// with that name does not exist</returns>
        public static MessageBoxBA GetMessageBox(string name)
		{
			if(_messageBoxes.Contains(name))
			{
				return _messageBoxes[name] as MessageBoxBA;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Deletes the message box with the specified name
		/// </summary>
		/// <param name="name">The name of the message box to delete</param>
		public static void DeleteMessageBox(string name)
		{
			if(name == null)
				return;

			if(_messageBoxes.Contains(name))
			{
				MessageBoxBA msgBox = _messageBoxes[name] as MessageBoxBA;
				msgBox.Dispose();
				_messageBoxes.Remove(name);
			}
		}

		public static void WriteSavedResponses(Stream stream)
		{
			throw new NotImplementedException("This feature has not yet been implemented");
		}

		public static void ReadSavedResponses(Stream stream)
		{
			throw new NotImplementedException("This feature has not yet been implemented");
		}

		/// <summary>
		/// Reset the saved response for the message box with the specified name.
		/// </summary>
		/// <param name="messageBoxName">The name of the message box whose response is to be reset.</param>
		public static void ResetSavedResponse(string messageBoxName)
		{
            if(messageBoxName == null)
                return;

			if(_savedResponses.ContainsKey(messageBoxName))
			{
				_savedResponses.Remove(messageBoxName);
			}
		}

		/// <summary>
		/// Resets the saved responses for all message boxes that are managed by the manager.
		/// </summary>
		public static void ResetAllSavedResponses()
		{
			_savedResponses.Clear();
		}
		#endregion

		#region Internal Methods
		/// <summary>
		/// Set the saved response for the specified message box
		/// </summary>
		/// <param name="msgBox">The message box whose response is to be set</param>
		/// <param name="response">The response to save for the message box</param>
        internal static void SetSavedResponse(MessageBoxBA msgBox, string response)
		{
            if(msgBox.Name == null)
                return;

			_savedResponses[msgBox.Name] = response;
		}

		/// <summary>
		/// Gets the saved response for the specified message box
		/// </summary>
		/// <param name="msgBox">The message box whose saved response is to be retrieved</param>
		/// <returns>The saved response if exists, null otherwise</returns>
        internal static string GetSavedResponse(MessageBoxBA msgBox)
		{
			string msgBoxName = msgBox.Name;
            if(msgBoxName == null)
            {
                return null;
            }

			if(_savedResponses.ContainsKey(msgBoxName))
			{
				return _savedResponses[msgBox.Name].ToString();
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// Returns the localized string for standard button texts like,
        /// "Ok", "Cancel" etc.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static string GetLocalizedString(string key)
        {
            if(_standardButtonsText.ContainsKey(key))
            {
                return (string)_standardButtonsText[key];
            }
            else
            {
                return null;
            }
        }
		#endregion
    }
}
