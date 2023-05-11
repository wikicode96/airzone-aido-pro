using RestSharp;
using Newtonsoft.Json.Linq;

private JObject AirzoneCall()
{
	string uri = "http://192.168.1.50:3000/api/v1/hvac";
	string body = "{\"systemID\":1,\"zoneID\":1}";

	var client = new RestClient(uri);
	var request = new RestRequest();

	System.Net.ServicePointManager.Expect100Continue = false;
	request.Method = Method.Post;

	request.AddBody(body);

	var response = client.Execute(request);
	JObject json = JObject.Parse(response.Content);

	JObject values = (JObject)json["data"][0];

	return values;
}
