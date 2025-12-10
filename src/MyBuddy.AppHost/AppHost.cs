using Projects;
using Scalar.Aspire;

var WEBAPI_PORT = 5000;
var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<MyBuddy_Web_API>("webapi", c => { c.LaunchProfileName = "aspire"; c.ExcludeKestrelEndpoints = true; })
	.WithHttpsEndpoint(port: WEBAPI_PORT, name: "myEndpoint");

//builder.AddExecutable("run-browser", @"C:\Program Files\Google\Chrome\Application\chrome.exe", ".", ["--remote-debugging-port=9222", $"https://localhost:{WASMCLIENT_PORT}/counter"]);

var scalar = builder.AddScalarApiReference(o => { })
	.WithApiReference(webApi);


builder.Build().Run();
