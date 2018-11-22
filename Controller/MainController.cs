/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	public class MainController
	{
		
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		public MainController()
		{
			this.Init();
			this.Handle();
		}
		#endregion
		
		#region workers
		#region publicworkers
		private void Init() {
		}
		
		private void Handle() {
			MainMenu MainMenu = new MainMenu(new CountryEntityController());
			
			MenuController mainMenu = new MenuController(MainMenu);
			while(true) {	//Main Menu runs in endless loop until exit is chosen
				mainMenu.handle();
			}
		}
		#endregion
		
		
		#region static methods
		
		#endregion 
		
		#region privateworkers
		#endregion
			
		#endregion
		
	}
}
