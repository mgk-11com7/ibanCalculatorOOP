/*
 * Author: Stefan Sander
 * Since: 26.11.2018
 */
using System;

namespace IbanOop
{
	public class IbanCalculator
	{
		#region properties
		public LanguageController _languageController;
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
			public IbanCalculator()
			{
				LanguageController languageController = new LanguageController("german");
				new MenuController(new MainMenu(new CountryEntityController(),languageController),languageController).run();
			}
		#endregion
		
		#region workers
		#endregion
	}
}
