/*
 * Author: Stefan Sander
 * Date: 20.11.2018
 */
using System;

namespace IbanOop
{
	public class MainMenu : MenuInterface
	{
		#region properties
		private int _page = 1;
		private int _pos = 0;
		private  int _maxElementsPerPage = 10;
		private string _elementSelected = "[X] ";
		private string _elementNotSelected = "[ ] ";
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
			public MainMenu(CountryEntity[] countryEntities)
			{
				this._countryEntities = countryEntities;
				
				MenuChoiceEntity[] menuElements= {
					new MenuChoiceEntity("IBAN generieren",this.GenerateIbanRoute),
					new MenuChoiceEntity("IBAN validieren",this.ValidateIbanRoute),
					new MenuChoiceEntity("Programm beenden",this.ExitRoute),
				};
				this._elements = menuElements;
			}
		#endregion
		
		#region workers
		public void ExitRoute() {
       		System.Environment.Exit(1);
		}
		
		public void GenerateIbanRoute() {
			GenerateIbanController ibanGenerator = new GenerateIbanController(this._countryEntities);
		}
		
		public void ValidateIbanRoute() {
			ValidateIbanController ibanValidator = new ValidateIbanController(this._countryEntities);
		}
			
		#endregion
	}
}
