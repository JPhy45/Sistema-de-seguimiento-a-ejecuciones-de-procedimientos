using Contracts;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Executions;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using Tests.Utilities;

namespace Testing
{
    [TestClass]
    public class ExecutionTest
    {
        private ExecutionRepository _executionRepository;
        private IUnitOfWork _unitOfWork;

        public ExecutionTest()
        {
            AplicationContext Context = new AplicationContext(ConnectionStringProvider.GetConnectionString());
            _executionRepository = new ExecutionRepository(Context);
            _unitOfWork = new UnitOfWork(Context);

        }
        [DataRow("P01","Phase1")]
        [TestMethod]
        public void Can_Add_PhaseExecution(string name, string IC)
        {
            //Arrange
            Phases phases = new Phases(name, IC);
            PhaseExecution phaseExecution = new PhaseExecution(phases);


            //Execute
            _executionRepository.AddExecution(phaseExecution);
            _unitOfWork.SaveChanges();

            //Assert
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(Id);
            Assert.IsNotNull(loadedPhaseExecution);
        }

        [DataRow("O01","Operation1")]
        [TestMethod]
        public void Can_Add_OperationExecution(string name, string IC)
        {       
            //Arrange
            Guid Id = Guid.NewGuid();
            Operations operations = new Operations(name, IC);
            OperationExecution operationExecution = new OperationExecution(operations);
            //Execute
            _executionRepository.AddExecution(operationExecution);
            _unitOfWork.SaveChanges();
            //Assert
            OperationExecution? LoadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(Id);
            Assert.IsNotNull(LoadedOperationExecution);
        }

        [DataRow("U01","Unit1")]
        [TestMethod]
        public void Can_Add_UnitExecution(string name, string IC)
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            UnitProcedure unitProcedure = new UnitProcedure(name, IC);
            UnitExecution unitExecution = new UnitExecution(unitProcedure);
            //Execute
            _executionRepository.AddExecution(unitExecution);
            _unitOfWork.SaveChanges();
            //Assert
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(Id);
            Assert.IsNotNull(loadedUnitExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_PhaseExecution_By_Id(int position)
        {
            //Arrange
            var PhaseExecutions = _executionRepository.GetAllExecutions<PhaseExecution>().ToList();
            Assert.IsNotNull(PhaseExecutions);
            Assert.IsTrue(position <  PhaseExecutions.Count);
            PhaseExecution PhaseExecutionToGet = PhaseExecutions[position];

            //Execute
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(PhaseExecutionToGet.Id);

            //Assert
            Assert.IsNotNull(loadedPhaseExecution);
        }

        [DataRow(1)]
        [TestMethod]
        public void Can_Get_OperationExecution_By_Id(int position)
        {
            //Arrange
            var OperationExecutions = _executionRepository.GetAllExecutions<OperationExecution>().ToList();
            Assert.IsNotNull(OperationExecutions);
            Assert.IsTrue (position < OperationExecutions.Count);
            OperationExecution OperationExecutionToGet = OperationExecutions[position];

            //Execute
            OperationExecution? loadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(OperationExecutionToGet.Id);
        
            //Assert
            Assert.IsNotNull (loadedOperationExecution);
        }

        [DataRow(2)]
        [TestMethod]
        public void Can_Get_UnitExecution_By_Id(int position)
        {
            //Arrange
            var UnitExecutions = _executionRepository.GetAllExecutions<UnitExecution>().ToList();
            Assert.IsNotNull(UnitExecutions);
            Assert.IsTrue(position <= UnitExecutions.Count);
            UnitExecution unitExecutionToGet = UnitExecutions[position];

            //Execute
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(unitExecutionToGet.Id);
            
            //Assert
            Assert.IsNotNull (loadedUnitExecution);
        }

        [TestMethod]
        public void Cannot_Get_PhaseExecution_By_Invalid_Id()
        {
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(Guid.Empty);
            Assert.IsNull(loadedPhaseExecution);
        }

        [TestMethod]
        public void Cannot_Get_OperationExecution_By_Invalid_Id()
        {
            OperationExecution? loadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(Guid.Empty);
            Assert.IsNull(loadedOperationExecution);
        }

        [TestMethod]
        public void Cannot_Get_UnitExecution_By_Invalid_Id()
        {
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(Guid.Empty);
            Assert.IsNull(loadedUnitExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_PhaseExecution(int position)
        {
            //Arrange
            var PhaseExecutions = _executionRepository.GetAllExecutions<PhaseExecution>().ToList();
            Assert.IsNotNull(PhaseExecutions);
            Assert.IsTrue(position < PhaseExecutions.Count);
            PhaseExecution PhaseExecutionToUpdate = PhaseExecutions[position];
            DateTime Refresh = DateTime.Now;
            DateTime RefreshEnd = DateTime.Now;

            //Execute
            PhaseExecutionToUpdate.StartTime = Refresh;
            PhaseExecutionToUpdate.EndTime = RefreshEnd;
            _executionRepository.UpdateExecution(PhaseExecutionToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(PhaseExecutionToUpdate.Id);
            Assert.IsNotNull(loadedPhaseExecution);
            Assert.AreEqual(loadedPhaseExecution.StartTime, Refresh);
            Assert.AreEqual(loadedPhaseExecution.EndTime, RefreshEnd);
        }
    
    }
}