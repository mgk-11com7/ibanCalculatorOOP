/*
 * Author: Stefan Sander
 * Since: 22.11.2018
 */
using System;

namespace IbanOop
{
	public interface MenuStyleInterface
	{
		 string GetElementSelectedPrefix();
		 string GetElementNotSelectedPrefix();
		 int GetMaxElementsPerPage();
	}
}