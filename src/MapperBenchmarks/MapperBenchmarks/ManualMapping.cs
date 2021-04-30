using System.Linq;
using MapperBenchmarks.Models;

namespace MapperBenchmarks
{
    public static class ManualMapping
    {
        public static CustomerDTO Map(Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                HomeAddress = new AddressDTO
                {
                    Id = customer.HomeAddress.Id,
                    City = customer.HomeAddress.City,
                    Country = customer.HomeAddress.Country
                },
                Addresses = customer.Addresses.Select(customerAddress => new AddressDTO
                {
                    Id = customerAddress.Id,
                    City = customerAddress.City,
                    Country = customerAddress.Country
                }).ToArray(),
                WorkAddresses = customer.WorkAddresses.Select(customerWorkAddress => new AddressDTO
                {
                    Id = customerWorkAddress.Id,
                    City = customerWorkAddress.City,
                    Country = customerWorkAddress.Country
                }).ToList(),
                AddressCity = customer.Address.City
            };
        }
    }
}