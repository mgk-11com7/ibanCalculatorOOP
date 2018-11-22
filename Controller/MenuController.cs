/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:22
 * 
 */
using System;

namespace IbanOop
{
	
	public class MenuController
	{
		public delegate void MenuChoiceCallback();
		
		#region properties
		private MenuInterface _Menu;
		#endregion
		
		#region accessors
		#endregion
		
		public MenuController(MenuInterface MenuInterface)
		{
			this._Menu = MenuInterface;
		}
		
		
		public int handle() {
			bool selected=false;
			while(selected==false) {
				Console.Clear();
				MenuView.output(this._Menu.GetMenuChoiceElements(),this._Menu.GetMaxElementsPerPage(),this._Menu.GetPage(),this._Menu.GetPosition(),this._Menu.GetElementSelectedPrefix(),this._Menu.GetElementNotSelectedPrefix());
				MenuResponse response =	MenuView.input(this._Menu.GetMenuChoiceElements(),this._Menu.GetMaxElementsPerPage(),this._Menu.GetPage(),this._Menu.GetPosition(),this._Menu.GetElementSelectedPrefix(),this._Menu.GetElementNotSelectedPrefix());
	        	this._Menu.SetPosition(response._pos);
	        	this._Menu.SetPage(response._page);
				selected = response._selected;
			}
			if (this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback!=null) {
				this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback();
			}
			return this._Menu.GetPosition();
		}
		
	}
}
