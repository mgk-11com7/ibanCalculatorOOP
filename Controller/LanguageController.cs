/*
 * Author: Stefan Sander
 * Since: 26.11.2018
 */
using System;

using System.Xml.Linq;
using System.Collections.Generic;

namespace IbanOop
{
	public class LanguageController
	{
		#region properties
		private string _ressource;
		private string _language = "german";
		private Dictionary<string, string> _languageVars;
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		public void loadLanguage(string language) {
			this._language = language;
			this._ressource = this.LoadLanguageFile(language);
		}
		public LanguageController(string language)
		{
			this.loadLanguage(language);
				//Console.ReadLine();
		}
		#endregion
		
		#region workers
		public string loadVar(string tag) {
		     var startTag = "<" + tag + ">";
		     int startIndex = this._ressource.IndexOf(startTag) + startTag.Length;
		     int endIndex = this._ressource.IndexOf("</" + tag + ">", startIndex);
		     return this._ressource.Substring(startIndex, endIndex - startIndex);
		}
		
		private string LoadLanguageFile(string language) {
			XElement languageFile = XElement.Load(@"../../Ressources/Language/"+language+".xml");
			return languageFile.ToString();
		}
		#endregion
	}
}
