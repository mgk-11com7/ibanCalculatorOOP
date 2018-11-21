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
			CountryEntity countryEntity = new CountryEntity();
			foreach(CountryEntity e in countryEntities) {
				if (e._countryCode==countryCode)
					countryEntity=e;
			}
			return countryEntity;
		}
		
		public ValidateIbanController(CountryEntity[] countryEntities)
		{
			ValidateIbanView ValidateIbanView = new ValidateIbanView();
			IbanEntity IbanEntity = new IbanEntity(ValidateIbanView.FetchIban(countryEntities));
			string countryCode = IbanEntity.GetCountryCode();
			IbanEntity GeneratedIbanEntity = GenerateIbanController.GenerateIban(countryCode,IbanEntity.GetBban());
			
		    CountryEntity CountryEntity = ValidateIbanController.GetCountryEntityByCountryCode(countryEntities,countryCode);
		    
			bool success;
			if (GeneratedIbanEntity.GetIban()==IbanEntity.GetIban()) {
				success = true;
			} else {
				success = false;
			}
		    ValidateIbanView.FetchIbanOutput(success,CountryEntity._ibanFormat,IbanEntity.GetIban(),true);
			MainController.Wait(true);
		}
		#endregion
		
	}
}
