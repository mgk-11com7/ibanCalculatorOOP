/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 03:53
 * 
 */
using System;

namespace IbanOop
{
	public class ValidateIbanController
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		

		#region workers
		public static CountryEntity GetCountryEntityByCountryCode(CountryEntity[] countryEntities,string countryCode) {
			CountryEntity countryEntity = new CountryEntity("",0,"","");
			foreach(CountryEntity e in countryEntities) {
				if (e._countryCode==countryCode)
					countryEntity=e;
			}
			return countryEntity;
		}
		
		public ValidateIbanController(CountryEntity[] countryEntities)
		{
			InputController InputController = new InputController();
			
			string iban = InputController.fetchIban(countryEntities);
		}
		#endregion
		
	}
}
