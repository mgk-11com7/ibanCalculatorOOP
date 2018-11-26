/*
 * Author: Stefan Sander
 * Date: 22.11.2018
 */
using System;


namespace IbanOop
{
	public interface RouteControllerInterface
	{
		string GetCaption(); // string to be displayed in the menu
		void Handle(); // holds the MenuChoice callback
		void Init(CountryEntityController CountryEntityController,LanguageController LanguageController);
	}
}