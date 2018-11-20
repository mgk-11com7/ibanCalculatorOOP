/*
 * Author: Stefan Sander
 * Date: 20.11.2018
 */
using System;

namespace IbanOop
{
	public class MainMenuEntity : MenuEntityInterface
	{
		#region properties
		public MenuChoiceEntity[] _elements;
		public CountryEntity[] _countryEntities;
		#endregion
		
		#region accessors
		public MenuChoiceEntity[] GetMenuChoiceElements () {
			return this._elements;
		}
		#endregion
		
		#region constructors
			public MainMenuEntity(CountryEntity[] countryEntities)
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
