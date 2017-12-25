using System;
using System.Collections;

namespace Femiani.Forms.UI.Input
{
	/// <summary>
	/// Summary description for AutoCompleteDictionaryEntry.
	/// </summary>
	[Serializable]
	public class AutoCompleteEntry : IAutoCompleteEntry
	{

		private string[] matchStrings;
		public string[] MatchStrings
		{
			get
			{
				if (this.matchStrings == null)
				{
					this.matchStrings = new string[] {this.DisplayName};
				}
				return this.matchStrings;
			}
		}

		private string displayName = string.Empty;
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				this.displayName = value;
			}
		}

        private float kinhDo = 0;
        public float KinhDo
		{
			get
			{
                return this.kinhDo;
			}
			set
			{
                this.kinhDo = value;
			}
		}

        private float viDo = 0;
        public float ViDo
        {
            get
            {
                return this.viDo;
            }
            set
            {
                this.viDo = value;
            }
        }

		public AutoCompleteEntry()
		{
		}

		public AutoCompleteEntry(string name, params string[] matchList)
		{
			this.displayName = name;
			this.matchStrings = matchList;
		}

        public AutoCompleteEntry(string name, float kd, float vd, params string[] matchList)
        {
            this.displayName = name;
            this.matchStrings = matchList;
            this.kinhDo = kd;
            this.viDo = vd;
        }

		public override string ToString()
		{
			return this.DisplayName;
		}

        public float GetKD()
        {
            return this.KinhDo;
        }

        public float GetVD()
        {
            return this.ViDo;
        }
	}
}
