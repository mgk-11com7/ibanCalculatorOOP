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
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors

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
