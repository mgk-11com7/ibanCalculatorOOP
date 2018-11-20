/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:23
 * 
 */
using System;

namespace IbanOop
{
	public class MenuChoiceEntity 
	{
		public string _caption;	// element caption to be displayed in the menu
		public MenuChoiceCallback _callback;	// holds a callback function delegate to be called when selected, if null menu returns element id
		
		public MenuChoiceEntity(string caption) {
			_caption = caption;
			_callback = null;
		}		
		
		public MenuChoiceEntity(string caption,MenuChoiceCallback callback) {
			_caption = caption;
			_callback = callback;
		}
	}
}