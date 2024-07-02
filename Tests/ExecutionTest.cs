using Contracts;
using Contracts.Executions;
using DataAccess.Contexts;
using DataAccess.Repositories.Executions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Utilities;
using Da

namespace Tests
{
    [TestClass]
    public class ExecutionTest
    {
        private IExecutionRepository _executionRepository;
        private IUnitOfWork _unitOfWork;

        public ExecutionTest()
        {
            AplicationContext Context = new AplicationContext(ConnectionStringProvider.GetConnectionString());
            _executionRepository = new ExecutionRepository(Context);
            _unitOfWork = new UnitOfWork(Context);
        }
    }
}
