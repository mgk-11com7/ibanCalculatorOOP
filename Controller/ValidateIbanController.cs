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
		
		public ValidateIbanController(CountryEntity[] countryEntities)
		{
			ValidateIbanView ValidateIbanView = new ValidateIbanView();
			IbanEntity IbanEntity = new IbanEntity(ValidateIbanView.FetchIban(countryEntities));
			IbanEntity GeneratedIbanEntity = GenerateIbanController.GenerateIban(IbanEntity.GetCountryCode(),IbanEntity.GetBban());
			Console.WriteLine(IbanEntity.GetIban());
			Console.WriteLine(GeneratedIbanEntity.GetIban());
			Console.ReadLine();
		}
		#endregion
		
	}
}
