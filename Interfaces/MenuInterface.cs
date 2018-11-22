/*
 * Author: Stefan Sander
 * Date: 22.11.2018
 */
using System;


namespace IbanOop
{
	public interface MenuInterface
	{
		MenuChoice[] GetMenuChoiceElements();
		string GetElementSelectedPrefix();
		string GetElementNotSelectedPrefix();
		int GetMaxElementsPerPage();
		int GetPage();
		void SetPage(int page);
		int GetPosition();
		void SetPosition(int pos);
	}
}
