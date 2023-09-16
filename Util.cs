namespace WebApplication2
{
	public static class AbbId
	{
		public static int toId(this string? s)
		{
			int res = 0;
			foreach (char c in s)
			{
				res = res * 100 + (int)c;
			}
			return res;
		}
	}
}
