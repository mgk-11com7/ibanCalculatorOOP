/*
 * User: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:23
 * 
 */
using System;

namespace IbanOop
{
	
	
	/// <summary>
	/// Description of MenuChoice.
	/// </summary>
	public struct MenuChoiceStruct
	{
		public string _caption;	// element caption to be displayed in the menu
		public MenuChoiceCallback _callback;	// holds a callback function delegate to be called when selected, if null menu returns element id
		
		public MenuChoiceStruct(string caption) {
			_caption = caption;
			_callback = null;
		}		
		
		public MenuChoiceStruct(string caption,MenuChoiceCallback callback) {
			_caption = caption;
			_callback = callback;
		}
	}
}