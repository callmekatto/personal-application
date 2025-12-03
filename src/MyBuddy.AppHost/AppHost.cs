using Projects;

var WEBAPI_PORT = 5000;
var WASMCLIENT_PORT = 5001;
var builder = DistributedApplication.CreateBuilder(args);

var webApi = builder.AddProject<MyBuddy_WebAPI>("webapi", c => { c.LaunchProfileName = "aspire"; c.ExcludeKestrelEndpoints = true; })
	.WithHttpsEndpoint(port: WEBAPI_PORT, name: "myEndpoint");

var wasmClient = builder.AddExternalService("wasm-client", "https://localhost:7000");
//var wasmClient = builder.AddProject<MyBuddy_WasmClient>("wasmclient")
//	.WithEndpoint(
//		endpointName: "https",
//		callback: static endpoint =>
//		{
//			//changing the fixed port from the launchsettings, otherwise conflict
//			endpoint.Port = 7094;
//			//setting the 'random' Aspire proxy to a fixed port. (for CORS purposes)
//			endpoint.TargetPort = 43211;
//		})
//	.WithEndpoint(
//		endpointName: "http",
//		callback: static endpoint =>
//		{
//			//for 'http' the Aspire proxy is now a random port chosen by Aspire
//			//change http port for launch conflict of first project 
//			endpoint.Port = 5009;
//		})
//	.WithExternalHttpEndpoints()
//	.WithReference(webApi); ;
//.WithReference(webApi)
//.WaitFor(webApi)
//.OnResourceReady(
//(r, c, x) =>
//{
//	Console.WriteLine();
//	return Task.CompletedTask;
//})
//.WithHttpsEndpoint(port: WASMCLIENT_PORT, name: "myEndpoint")
//.WithExternalHttpEndpoints();

//builder.AddExecutable("run-browser", @"C:\Program Files\Google\Chrome\Application\chrome.exe", ".", ["--remote-debugging-port=9222", $"https://localhost:{WASMCLIENT_PORT}/counter"]);

builder.Build().Run();
