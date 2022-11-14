using System;
namespace RecipeAPI.Models
{
	public class Response
	{
		public int statusCode { get; set; }
		public string statusDescription { get; set; }
		public object? returnList { get; set; }
	}
}

