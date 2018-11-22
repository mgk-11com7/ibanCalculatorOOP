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
				MenuIOHandler.output(this._Menu.GetMenuChoiceElements(),this._Menu.GetMaxElementsPerPage(),this._Menu.GetPage(),this._Menu.GetPosition(),this._Menu.GetElementSelectedPrefix(),this._Menu.GetElementNotSelectedPrefix());
				MenuResponse response =	MenuIOHandler.input(this._Menu.GetMenuChoiceElements(),this._Menu.GetMaxElementsPerPage(),this._Menu.GetPage(),this._Menu.GetPosition(),this._Menu.GetElementSelectedPrefix(),this._Menu.GetElementNotSelectedPrefix());
				this._Menu.SetPosition(response.GetPos());
				this._Menu.SetPage(response.GetPage());
				selected = response.GetSelected();
			}
			if (this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback!=null) {
				this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback();
			}
			return this._Menu.GetPosition();
		}
	}
}
