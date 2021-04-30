using System;
using System.Collections.Generic;
using AutoMapper;
using ExpressMapper.Extensions;
using MapperBenchmarks.Models;
using Mapster;

namespace MapperBenchmarks
{
    public static class BenchmarkHelper
    {
        private static readonly IMapper _automapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Address, AddressDTO>();
            cfg.CreateMap<Customer, CustomerDTO>();
        }));
        public static Customer SetupCustomerInstance()
        {
            return new Customer
            {
                Address = new Address { City = "istanbul", Country = "turkey", Id = 1, Street = "istiklal cad." },
                HomeAddress = new Address { City = "istanbul", Country = "turkey", Id = 2, Street = "istiklal cad." },
                Id = 1,
                Name = "Enes Emre Demir",
                Credit = 234.7m,
                WorkAddresses = new List<Address>
                {
                    new Address {City = "istanbul", Country = "turkey", Id = 5, Street = "istiklal cad."},
                    new Address {City = "izmir", Country = "turkey", Id = 6, Street = "konak"}
                },
                Addresses = new[]
                {
                    new Address {City = "istanbul", Country = "turkey", Id = 3, Street = "istiklal cad."},
                    new Address {City = "izmir", Country = "turkey", Id = 4, Street = "konak"}
                }
            };
        }

        public static void ConfigureMapster(Customer customerInstance)
        {
            customerInstance.Adapt<Customer, CustomerDTO>();    //exercise
        }
        public static void ConfigureExpressMapper(Customer customerInstance)
        {
            ExpressMapper.Mapper.Register<Address, AddressDTO>();
            ExpressMapper.Mapper.Register<Customer, CustomerDTO>();
            ExpressMapper.Mapper.Map<Customer, CustomerDTO>(customerInstance);  //exercise
        }
        public static void ConfigureAutoMapper(Customer customerInstance)
        {
            _automapper.Map<Customer, CustomerDTO>(customerInstance);    //exercise
        }

        public static void ConfigureTinyMapper(Customer customerInstance)
        {
            Nelibur.ObjectMapper.TinyMapper.Bind<Address, AddressDTO>();
            Nelibur.ObjectMapper.TinyMapper.Bind<Customer, CustomerDTO>();
            Nelibur.ObjectMapper.TinyMapper.Map<Customer, CustomerDTO>(customerInstance); //exercise
        }
        public static void ConfigureAgileMapper(Customer customerInstance)
        {
            AgileObjects.AgileMapper.Mapper.Map(customerInstance).ToANew<CustomerDTO>(); //exercise
        }
        public static void TestMapsterAdapter<TSrc, TDest>(TSrc item, int iterations)
            where TSrc : class
            where TDest : class, new()
        {
            Loop(item, get => get.Adapt<TSrc, TDest>(), iterations);
        }

        public static void TestExpressMapper<TSrc, TDest>(TSrc item, int iterations)
            where TSrc : class
            where TDest : class, new()
        {
            Loop(item, get => ExpressMapper.Mapper.Map<TSrc, TDest>(get), iterations);
        }

        public static void TestAutoMapper<TSrc, TDest>(TSrc item, int iterations)
            where TSrc : class
            where TDest : class, new()
        {
            Loop(item, get => _automapper.Map<TSrc, TDest>(get), iterations);
        }
        public static void TestTinyMapper<TSrc, TDest>(TSrc item, int iterations)
            where TSrc : class
            where TDest : class, new()
        {
            Loop(item, get => Nelibur.ObjectMapper.TinyMapper.Map<TSrc, TDest>(get), iterations);
        }
        public static void TestAgileMapper<TSrc, TDest>(TSrc item, int iterations)
            where TSrc : class
            where TDest : class, new()
        {
            Loop(item, get => AgileObjects.AgileMapper.Mapper.Map(get).ToANew<TDest>(), iterations);
        }

        public static void TestManualMapping(Customer item, int iterations)
        {
            Loop(item, get => ManualMapping.Map(get) , iterations);
        }
        public static void TestCodeGen(Customer item, int iterations)
        {
            Loop(item, get => CustomerMapper.Map(get), iterations);
        }
        private static void Loop<T>(T item, Action<T> action, int iterations)
        {
            for (var i = 0; i < iterations; i++) action(item);
        }
    }

}