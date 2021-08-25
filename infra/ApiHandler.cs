using System;
using Newtonsoft.Json;
using OpenProject.configurations;
using OpenProject.infra.beans;
using RestSharp;
using RestSharp.Authenticators;

namespace OpenProject.infra
{
	public class ApiHandler
	{
		private readonly IRestClient _client;
		private Config _config;
		private Logger _logger;

		public ApiHandler()
		{
			_config = new Config();
			_client = new RestClient(_config.apiUrl);
			_client.Authenticator = new HttpBasicAuthenticator("apikey", _config.apiKey);
			_logger = Logger.GetInstance();
		}

		internal IRestResponse GetProjectById(string projectId)
		{
			var request = CreateRequest($"projects/{projectId}", Method.GET);

			return Execute(request);
		}

		private T Execute<T>(IRestRequest request) where T : new()
		{
			var response = Execute(request);
			CheckIfResponseContainsException(response);

			return JsonConvert.DeserializeObject<T>(response.Content);
		}

		private IRestResponse Execute(IRestRequest request)
		{
			var response = _client.Execute(request);
			CheckIfResponseContainsException(response);
			_logger.LogActionAccordingToResponse(response);

			return response;
		}

		private void CheckIfResponseContainsException(IRestResponse response)
		{
			if (response.ErrorException != null)
			{
				string message = $"ERROR retrieving response - {response.ErrorException.Message}";
				_logger.Log(message);
				var exception = new Exception(message, response.ErrorException);
				throw exception;
			}
		}

		private void SerializeAndAddToRequestBody(IRestRequest request, object obj)
		{
			string serializedProject = JsonConvert.SerializeObject(obj);
			request.AddJsonBody(serializedProject);
		}

		internal Project UpdateProjectById(string projectId, object bodyData)
		{
			var request = CreateRequest($"projects/{projectId}", Method.PATCH);
			request.AddJsonBody(bodyData);

			return Execute<Project>(request);
		}

		internal Project CreateNewProject(object newProject)
		{
			var request = CreateRequest($"projects", Method.POST);
			SerializeAndAddToRequestBody(request, newProject);
			var response = Execute(request);

			return JsonConvert.DeserializeObject<Project>(response.Content);
		}

		internal IRestResponse DeleteProjectById(string projectId)
		{
			var request = CreateRequest($"projects/{projectId}", Method.DELETE);
			request.AddHeader("Content-Type", @"application/json");
			var response = Execute(request);

			return response;
		}

		internal WorkPackage CreateWorkPackageInProject(string projectId, object workPackage)
		{
			var request = CreateRequest($"projects/{projectId}/work_packages", Method.POST);
			SerializeAndAddToRequestBody(request, workPackage);
			var response = Execute(request);

			return JsonConvert.DeserializeObject<WorkPackage>(response.Content);
		}

		internal WorkPackage GetWorkPackageById(string workPackageId)
		{
			var request = CreateRequest($"work_packages/{workPackageId}", Method.GET);
			var response = Execute(request);

			return JsonConvert.DeserializeObject<WorkPackage>(response.Content);
		}

		internal WorkPackage UpdateWorkPackageById(string workPackageId, object workPackage)
		{
			var request = CreateRequest($"work_packages/{workPackageId}", Method.PATCH);
			SerializeAndAddToRequestBody(request, workPackage);
			var response = Execute(request);

			return JsonConvert.DeserializeObject<WorkPackage>(response.Content);
		}

		private IRestRequest CreateRequest(string apiEndPoint, Method requestMethod)
		{
			return new RestRequest(apiEndPoint, requestMethod);
		}
	}
}