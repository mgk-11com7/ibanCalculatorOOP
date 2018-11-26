/*
 * Author: Stefan Sander
 * Date: 20.11.2018
 */
using System;

namespace IbanOop
{
	public class MainMenu : MenuStyleTwo,MenuInterface
	{
		#region properties
		private LanguageController _languageController;
		private int _page = 1;
		private int _pos = 0;
		public MenuChoice[] _elements;
		public CountryEntityController _countryEntityController;
		private RouteControllerInterface[] _modules;
		#endregion
		
		#region accessors
		public void SetPage(int page) {
			this._page = page;
		}
		public int GetPage() {
			return this._page;
		}
		public void SetPosition(int pos) {
			this._pos = pos;
		}
		public int GetPosition() {
			return this._pos;
		}
		public MenuChoice[] GetMenuChoiceElements () {
			return this._elements;
		}
		#endregion
		
		#region constructors
			public MainMenu(CountryEntityController CountryEntityController,LanguageController languageController)
			{
				this._languageController = languageController;
				this._countryEntityController = CountryEntityController;
				RouteControllerInterface[] Modules = this.LoadModules();
				MenuChoice[] menuElements = new MenuChoice[Modules.Length+1];
				for (int i = 0; i < Modules.Length; i++)
				{
					menuElements[i] = new MenuChoice(Modules[i].GetCaption(),Modules[i].Handle);
				}
				menuElements[Modules.Length] = new MenuChoice(languageController.loadVar("MainMenuProgramClose"),this.ExitRoute);
				this._elements = menuElements;
			}
		#endregion
		
		#region workers
		private RouteControllerInterface[] LoadModules() {
			RouteControllerInterface[]  Modules = {
				new GenerateIbanController(),
				new ValidateIbanController(),
			};
			foreach(RouteControllerInterface module in Modules) {
				module.Init(this._countryEntityController,this._languageController);
			}
			return Modules;
		}
		public void ExitRoute() {
       		System.Environment.Exit(1);
		}
			
		#endregion
	}
}
