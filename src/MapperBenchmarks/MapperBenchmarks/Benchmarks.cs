using BenchmarkDotNet.Attributes;
using MapperBenchmarks.Models;

namespace MapperBenchmarks
{
    [KeepBenchmarkFiles(false)]
    public class Benchmarks
    {
        private Customer _customerInstance;

        [Benchmark]
        public void MapsterTest()
        {
            BenchmarkHelper.TestMapsterAdapter<Customer, CustomerDTO>(_customerInstance, 1_000_000);
        }

        [Benchmark]
        public void ExpressMapperTest()
        {
            BenchmarkHelper.TestExpressMapper<Customer, CustomerDTO>(_customerInstance, 1_000_000);
        }

        [Benchmark]
        public void AutoMapperTest()
        {
            BenchmarkHelper.TestAutoMapper<Customer, CustomerDTO>(_customerInstance, 1_000_000);
        }

        [Benchmark]
        public void TinyMapperTest()
        {
            BenchmarkHelper.TestTinyMapper<Customer, CustomerDTO>(_customerInstance, 1_000_000);
        }

        [Benchmark]
        public void AgileMapperTest()
        {
            BenchmarkHelper.TestAgileMapper<Customer, CustomerDTO>(_customerInstance, 1_000_000);
        }
        [Benchmark]
        public void ManualMappingTest()
        {
            BenchmarkHelper.TestManualMapping(_customerInstance, 1_000_000);
        }
        [Benchmark]
        public void CodegenTest()
        {
            BenchmarkHelper.TestCodeGen(_customerInstance, 1_000_000);
        }

        [GlobalSetup(Target = nameof(MapsterTest))]
        public void SetupMapster()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            BenchmarkHelper.ConfigureMapster(_customerInstance);
        }

        [GlobalSetup(Target = nameof(ExpressMapperTest))]
        public void SetupExpressMapper()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            BenchmarkHelper.ConfigureExpressMapper(_customerInstance);
        }

        [GlobalSetup(Target = nameof(AutoMapperTest))]
        public void SetupAutoMapper()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            BenchmarkHelper.ConfigureAutoMapper(_customerInstance);
        }

        [GlobalSetup(Target = nameof(TinyMapperTest))]
        public void SetupTinyMapper()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            BenchmarkHelper.ConfigureTinyMapper(_customerInstance);
        }
        [GlobalSetup(Target = nameof(AgileMapperTest))]
        public void SetupAgileMapper()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            BenchmarkHelper.ConfigureAgileMapper(_customerInstance);
        }
        [GlobalSetup(Target = nameof(ManualMappingTest))]
        public void SetupManualMapping()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            ManualMapping.Map(_customerInstance);
        }
        [GlobalSetup(Target = nameof(CodegenTest))]
        public void SetupCodegen()
        {
            _customerInstance = BenchmarkHelper.SetupCustomerInstance();
            CustomerMapper.Map(_customerInstance);
        }
    }
}