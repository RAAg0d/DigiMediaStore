var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DigiMediaStore>("digimediamanager");

builder.Build().Run();
