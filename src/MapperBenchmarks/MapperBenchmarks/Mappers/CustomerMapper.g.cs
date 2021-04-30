using System.Collections.Generic;
using MapperBenchmarks;
using MapperBenchmarks.Models;

namespace MapperBenchmarks
{
    public static partial class CustomerMapper
    {
        public static CustomerDTO Map(Customer p1)
        {
            return p1 == null ? null : new CustomerDTO()
            {
                Id = p1.Id,
                Name = p1.Name,
                Address = p1.Address == null ? null : new Address()
                {
                    Id = p1.Address.Id,
                    Street = p1.Address.Street,
                    City = p1.Address.City,
                    Country = p1.Address.Country
                },
                HomeAddress = p1.HomeAddress == null ? null : new AddressDTO()
                {
                    Id = p1.HomeAddress.Id,
                    City = p1.HomeAddress.City,
                    Country = p1.HomeAddress.Country
                },
                Addresses = funcMain1(p1.Addresses),
                WorkAddresses = funcMain2(p1.WorkAddresses),
                AddressCity = p1.Address == null ? null : p1.Address.City
            };
        }
        public static AddressDTO Map(Address p4)
        {
            return p4 == null ? null : new AddressDTO()
            {
                Id = p4.Id,
                City = p4.City,
                Country = p4.Country
            };
        }
        
        private static AddressDTO[] funcMain1(Address[] p2)
        {
            if (p2 == null)
            {
                return null;
            }
            AddressDTO[] result = new AddressDTO[p2.Length];
            
            int v = 0;
            
            int i = 0;
            int len = p2.Length;
            
            while (i < len)
            {
                Address item = p2[i];
                result[v++] = item == null ? null : new AddressDTO()
                {
                    Id = item.Id,
                    City = item.City,
                    Country = item.Country
                };
                i++;
            }
            return result;
            
        }
        
        private static List<AddressDTO> funcMain2(ICollection<Address> p3)
        {
            if (p3 == null)
            {
                return null;
            }
            List<AddressDTO> result = new List<AddressDTO>(p3.Count);
            
            IEnumerator<Address> enumerator = p3.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Address item = enumerator.Current;
                result.Add(item == null ? null : new AddressDTO()
                {
                    Id = item.Id,
                    City = item.City,
                    Country = item.Country
                });
            }
            return result;
            
        }
    }
}