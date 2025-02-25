﻿namespace Jab;

internal record ServiceProviderDescription
{
    public ServiceProviderDescription(IReadOnlyList<ServiceRegistration> serviceRegistrations, RootService[] rootServices, Location? location)
    {
        Location = location;
        RootServices = rootServices;
        ServiceRegistrations = serviceRegistrations;
        ServiceRegistrationsLookup = new Dictionary<ITypeSymbol, ServiceRegistration>(SymbolEqualityComparer.Default);

        foreach (var registration in serviceRegistrations)
        {
            ServiceRegistrationsLookup[registration.ServiceType] = registration;
        }
    }

    public Dictionary<ITypeSymbol,ServiceRegistration> ServiceRegistrationsLookup { get; }

    public Location? Location { get; }
    public RootService[] RootServices { get; }
    public IReadOnlyList<ServiceRegistration> ServiceRegistrations { get; }
}