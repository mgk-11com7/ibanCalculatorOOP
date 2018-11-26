/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class SelectCountryMenu : MenuStyleTwo,MenuInterface
	{
		#region properties
		private int _page = 1;
		private int _pos = 0;
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors

		#region properties
		public MenuChoice[] _elements;
		public CountryEntity[] _countryEntities;
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
			public SelectCountryMenu(LanguageController languageController,CountryEntity[] countryEntities)
			{
				this._countryEntities = countryEntities;
				MenuChoice[] menuElements= new MenuChoice[countryEntities.Length+1];
				for(int i = 0; i < countryEntities.Length; i++)
				{
					menuElements[i] =  new MenuChoice(countryEntities[i]._countryName);
				}
				menuElements[countryEntities.Length] =  new MenuChoice(languageController.loadVar("SelectCountryMenuBackToMainMenu"));
				this._elements = menuElements;
			}
		#endregion
		
		#region workers
			
		#endregion
		#endregion
		
		#region workers
		#endregion
	}
}
