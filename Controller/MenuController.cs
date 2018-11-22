/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	
	public class MenuController
	{
		#region properties
		public delegate void MenuChoiceCallback();
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
				MenuIOHandler.output(this._Menu);
				selected =	MenuIOHandler.input(this._Menu);
			}
			if (this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback!=null) {
				this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback();
			}
			return this._Menu.GetPosition();
		}
		public void run() {
			while(true) {	//Main Menu runs in endless loop until exit is chosen
				this.handle();
			}
		}
	}
}
