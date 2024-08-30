using Contracts;
using Contracts.Executions;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Executions;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using Tests.Utilities;

namespace Testing
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
        [DataRow("P01", "Phase1")]
        [TestMethod]
        public void Can_Add_PhaseExecution(string name, string IC)
        {
            //Arrange
            Phases phases = new Phases(name, IC);
            PhaseExecution phaseExecution = new PhaseExecution(phases);
            Guid Id = phaseExecution.Id;


            //Execute
            _executionRepository.AddExecution(phaseExecution);
            _unitOfWork.SaveChanges();

            //Assert
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(Id);
            Assert.IsNotNull(loadedPhaseExecution);
        }

        [DataRow("O01", "Operation1")]
        [TestMethod]
        public void Can_Add_OperationExecution(string name, string IC)
        {
            //Arrange
            Operations operations = new Operations(name, IC);
            OperationExecution operationExecution = new OperationExecution(operations);
            Guid Id = operationExecution.Id;
            //Execute
            _executionRepository.AddExecution(operationExecution);
            _unitOfWork.SaveChanges();
            //Assert
            OperationExecution? LoadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(Id);
            Assert.IsNotNull(LoadedOperationExecution);
        }

        [DataRow("U01", "Unit1")]
        [TestMethod]
        public void Can_Add_UnitExecution(string name, string IC)
        {
            //Arrange
            UnitProcedure unitProcedure = new UnitProcedure(name, IC);
            UnitExecution unitExecution = new UnitExecution(unitProcedure);
            Guid Id = unitExecution.Id;
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
            Assert.IsTrue(position < PhaseExecutions.Count);
            PhaseExecution PhaseExecutionToGet = PhaseExecutions[position];

            //Execute
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(PhaseExecutionToGet.Id);

            //Assert
            Assert.IsNotNull(loadedPhaseExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_OperationExecution_By_Id(int position)
        {
            //Arrange
            var OperationExecutions = _executionRepository.GetAllExecutions<OperationExecution>().ToList();
            Assert.IsNotNull(OperationExecutions);
            Assert.IsTrue(position < OperationExecutions.Count);
            OperationExecution OperationExecutionToGet = OperationExecutions[position];

            //Execute
            OperationExecution? loadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(OperationExecutionToGet.Id);

            //Assert
            Assert.IsNotNull(loadedOperationExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_UnitExecution_By_Id(int position)
        {
            //Arrange
            var UnitExecutions = _executionRepository.GetAllExecutions<UnitExecution>().ToList();
            Assert.IsNotNull(UnitExecutions);
            Assert.IsTrue(position < UnitExecutions.Count);
            UnitExecution unitExecutionToGet = UnitExecutions[position];

            //Execute
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(unitExecutionToGet.Id);

            //Assert
            Assert.IsNotNull(loadedUnitExecution);
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
        [DataRow(0)]
        [TestMethod]
        public void Can_Update_OperationExecution(int position)
        {
            //Arrange
            var OperationExecutions = _executionRepository.GetAllExecutions<OperationExecution>().ToList();
            Assert.IsNotNull(OperationExecutions);
            Assert.IsTrue(position < OperationExecutions.Count);
            OperationExecution OperationExecutionToUpdate = OperationExecutions[position];
            DateTime Refresh = DateTime.Now;
            DateTime RefreshEnd = DateTime.Now;

            //Execute
            OperationExecutionToUpdate.StartTime = Refresh;
            OperationExecutionToUpdate.EndTime = RefreshEnd;
            _executionRepository.UpdateExecution(OperationExecutionToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            OperationExecution? loadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(OperationExecutionToUpdate.Id);
            Assert.IsNotNull(loadedOperationExecution);
            Assert.AreEqual(loadedOperationExecution.StartTime, Refresh);
            Assert.AreEqual(loadedOperationExecution.EndTime, RefreshEnd);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Update_UnitExecution(int position)
        {
            //Arrange
            var UnitExecutions = _executionRepository.GetAllExecutions<UnitExecution>().ToList();
            Assert.IsNotNull(UnitExecutions);
            Assert.IsTrue(position < UnitExecutions.Count);
            UnitExecution UnitExecutionToUpdate = UnitExecutions[position];
            DateTime Refresh = DateTime.Now;
            DateTime RefreshEnd = DateTime.Now;

            //Execute
            UnitExecutionToUpdate.StartTime = Refresh;
            UnitExecutionToUpdate.EndTime = RefreshEnd;
            _executionRepository.UpdateExecution(UnitExecutionToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(UnitExecutionToUpdate.Id);
            Assert.IsNotNull(loadedUnitExecution);
            Assert.AreEqual(loadedUnitExecution.StartTime, Refresh);
            Assert.AreEqual(loadedUnitExecution.EndTime, RefreshEnd);

        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_PhaseExecution(int position)
        {
            //Arrange
            var PhaseExecutions = _executionRepository.GetAllExecutions<PhaseExecution>().ToList();
            Assert.IsNotNull(PhaseExecutions);
            Assert.IsTrue(position < PhaseExecutions.Count);
            PhaseExecution PhaseExecutionToDelete = PhaseExecutions[position];

            //Execute
            _executionRepository.DeleteExecution(PhaseExecutionToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            PhaseExecution? loadedPhaseExecution = _executionRepository.GetExecutionById<PhaseExecution>(PhaseExecutionToDelete.Id);
            Assert.IsNull(loadedPhaseExecution);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_OperationExecution(int position)
        {
            //Arrange
            var OperationExecutions = _executionRepository.GetAllExecutions<OperationExecution>().ToList();
            Assert.IsNotNull(OperationExecutions);
            Assert.IsTrue(position < OperationExecutions.Count);
            OperationExecution OperationExecutionToDelete = OperationExecutions[position];

            //Execute
            _executionRepository.DeleteExecution(OperationExecutionToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            OperationExecution? loadedOperationExecution = _executionRepository.GetExecutionById<OperationExecution>(OperationExecutionToDelete.Id);
            Assert.IsNull(loadedOperationExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_UnitExecution(int position)
        {
            //Arrange
            var UnitExecutions = _executionRepository.GetAllExecutions<UnitExecution>().ToList();
            Assert.IsNotNull(UnitExecutions);
            Assert.IsTrue(position < UnitExecutions.Count);
            UnitExecution UnitExecutionToDelete = UnitExecutions[position];

            //Execute
            _executionRepository.DeleteExecution(UnitExecutionToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            UnitExecution? loadedUnitExecution = _executionRepository.GetExecutionById<UnitExecution>(UnitExecutionToDelete.Id);
            Assert.IsNull(loadedUnitExecution);
        }




    }
}