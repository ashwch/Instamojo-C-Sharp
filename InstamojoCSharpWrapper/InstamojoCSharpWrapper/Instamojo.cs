using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RestSharp;

namespace InstamojoCSharpWrapper
{




	public class Instamojo
	{

		const string endPoint = "http://locals.instamojo.com:5000/api/1.1/";
		readonly string _api_key;
		readonly string _auth_token;

		public Instamojo(string api_key, string auth_token) {
			_api_key = api_key;
			_auth_token = auth_token;
		}

		public T Execute<T>(string path, string method) where T : new()
		{
			if (method == "get") {
				method = Method.GET;
			} else if (method == "post") {
				method = Method.POST;
			}
			else if (method == "patch") {
				method = Method.PATCH;
			}
	        else if (method == "delete") {
				method = Method.DELETE;
			}
			else if (method == "put") {
				method = Method.PUT;
			}

			var request = new RestRequest(endPoint + path, method);
			request.AddHeader("X-Api-Key", _api_key);
			request.AddHeader("X-Api-Key", _auth_token);

			RestResponse response = client.Execute(request);
			if (response.ErrorException != null) {
				content = "Error retrieving response.  Check inner details for more info.";
				Console.WriteLine(content);
				return content;
			}
			var content = response.Content; // raw content as string
			Console.WriteLine(content);
			return content;
		}

	}

}

