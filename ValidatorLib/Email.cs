namespace ValidatorLib
{
	public static class Email
	{
		/// <summary>
		/// Method for validating input string for a correct email address.<para />
		/// Correct email is:<para />
		/// Only one @ in string.<para />
		/// Only one subdomain is valid. -> someName@somesubdomain.domain.xy is valid but someName@sub2.sub1.domain.xy is not.<para />
		/// Valid top level domains are: only .com, .cz, .sk<para />
		/// Invalid strings with valid top domains are logged into file: C:\EmailValidator\CheckThisEmails.txt<para />
		/// Valid name before @ is at least 3 character long (dots excluded) but no more than 25, dots included.<para />
		/// Valid part after @ is 6 character long but no more than 25, dots included. If the domain is 6 char long, there must be only one dot (no subdomain).<para />
		/// Valid characters are only ASCII characters.<para />
		/// We don't want asdf@asdf.cz or com or sk.
		/// </summary>
		/// <param name="input">Input string which must be validated.</param>
		/// <returns>True/false value for input string.</returns>
		public static bool Validate(string input)
		{
			return false;
		}
	}
}