/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	public class ValidateIbanController : RouteControllerInterface
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
			IbanEntity IbanEntity = new IbanEntity(ValidateIbanIOHandler.ValidateIbanInput(),CountryEntityController);
			CountryEntity CountryEntity = IbanEntity.GetCountryEntity();
		    ValidateIbanIOHandler.ValidateIbanOutput(IbanEntity.Validate(),CountryEntity,IbanEntity.GetIban(),true,0);
			AbstractIOHandler.Wait(true);
		}
		#endregion
		
	}
}
