/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class SelectCountryMenu : MenuInterface
	{
		#region properties
		private int _page = 1;
		private int _pos = 0;
		private int _maxElementsPerPage = 10;
		private string _elementSelected = "[X] ";
		private string _elementNotSelected = "[ ] ";
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors

		#region properties
		public MenuChoiceEntity[] _elements;
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
		public int GetMaxElementsPerPage() {
			return this._maxElementsPerPage;
		}
		public string GetElementSelectedPrefix() {
			return this._elementSelected;
		}
		public string GetElementNotSelectedPrefix() {
			return this._elementNotSelected;
			
		}
		public MenuChoiceEntity[] GetMenuChoiceElements () {
			return this._elements;
		}
		#endregion
		
		#region constructors
			public SelectCountryMenu(CountryEntity[] countryEntities)
			{
				this._countryEntities = countryEntities;
				MenuChoiceEntity[] menuElements= new MenuChoiceEntity[countryEntities.Length];
				for(int i = 0; i < countryEntities.Length; i++)
				{
					menuElements[i] =  new MenuChoiceEntity(countryEntities[i]._countryName);
				}
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
