/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	public class ValidateIbanRoute : RouteInterface
	{
		#region properties
		private string _caption = "IBAN validieren";
		private CountryEntityController _countryEntityController;
		#endregion
		
		#region accessors
		public string GetCaption() {
			return this._caption;
		}
		#endregion
		public void Init(CountryEntityController CountryEntityController) {
			this._countryEntityController = CountryEntityController;
		}
		#region workers
		
		public void Handle()
		{
			CountryEntityController CountryEntityController = this._countryEntityController;
			ValidateIbanIOHandler ValidateIbanIOHandler = new ValidateIbanIOHandler(CountryEntityController);
			IbanEntity IbanEntity = ValidateIbanIOHandler.ValidateIbanInput();
			CountryEntity CountryEntity = IbanEntity.GetCountryEntity();
		    ValidateIbanIOHandler.ValidateIbanOutput(IbanEntity.Validate(),CountryEntity._ibanFormat,IbanEntity.GetIban(),true);
			InputOutputUtilities.Wait(true);
		}
		#endregion
	}
}
