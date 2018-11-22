/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	public class MenuChoice 
	{
		public string _caption;	// element caption to be displayed in the menu
		public MenuController.MenuChoiceCallback _callback;	// holds a callback function delegate to be called when selected, if null menu returns element id
		
		public MenuChoice(string caption) {
			_caption = caption;
			_callback = null;
		}		
		
		public MenuChoice(string caption,MenuController.MenuChoiceCallback callback) {
			_caption = caption;
			_callback = callback;
		}
	}
}