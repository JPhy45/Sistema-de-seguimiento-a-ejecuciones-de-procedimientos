using Contracts;
using Contracts.Procedures;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Procedures;
using Domain.Domain.Entities;
using Tests.Utilities;


namespace Testing
{
    [TestClass]
    public class ProcedureControlTest
    {
        private IProcedureControlRepository _basesRepository;
        private IUnitOfWork _unitOfWork;

        public ProcedureControlTest()
        {
            AplicationContext Context = new AplicationContext(ConnectionStringProvider.GetConnectionString());
            _basesRepository = new ProcedureControlRepository(Context);
            _unitOfWork = new UnitOfWork(Context);

        }
        [DataRow("P02", "Phase2")]
        [DataRow("P01", "Phase1")]
        [TestMethod]
        public void Can_Add_Phase(string name, string IC)
        {
            //Arrange
            Phases phases = new Phases(name, IC);
            Guid Id = phases.Id;

            //Execute
            _basesRepository.Add(phases);
            _unitOfWork.SaveChanges();

            //Assert
            Phases? loaded = _basesRepository.GetById<Phases>(Id);
            Assert.IsNotNull(loaded);

        }
        [DataRow("Operation2", "Operation2")]
        [DataRow("O01", "Operation1")]
        [TestMethod]
        public void Can_Add_Operation(string name, string IC)
        {
            //Arrange

            Operations operations = new Operations(name, IC);
            Guid Id = operations.Id;

            //Execute
            _basesRepository.Add(operations);
            _unitOfWork.SaveChanges();
            //Assert
            Operations? LoadedOperation = _basesRepository.GetById<Operations>(Id);
            Assert.IsNotNull(LoadedOperation);
        }

        [DataRow("U02", "Unit2")]
        [DataRow("U01", "Unit1")]
        [TestMethod]
        public void Can_Add_UnitProcedure(string name, string IC)
        {
            //Arrange
            UnitProcedure unitProcedure = new UnitProcedure(name, IC);
            Guid Id = unitProcedure.Id;
            //Execute
            _basesRepository.Add(unitProcedure);
            _unitOfWork.SaveChanges();
            //Assert
            UnitProcedure? loadedUnitProcedure = _basesRepository.GetById<UnitProcedure>(Id);
            Assert.IsNotNull(loadedUnitProcedure);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Phase_By_Id(int position)
        {
            //Arrange
            var Phases = _basesRepository.GetAll<Phases>().ToList();
            Assert.IsNotNull(Phases);
            Assert.IsTrue(position < Phases.Count);
            Phases PhaseToGet = Phases[position];

            //Execute
            Phases? loadedPhase = _basesRepository.GetById<Phases>(PhaseToGet.Id);

            //Assert
            Assert.IsNotNull(loadedPhase);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Operation_By_Id(int position)
        {
            //Arrange
            var Operations = _basesRepository.GetAll<Operations>().ToList();
            Assert.IsNotNull(Operations);
            Assert.IsTrue(position < Operations.Count);
            Operations OperationToGet = Operations[position];

            //Execute
            Operations? loadedOperation = _basesRepository.GetById<Operations>(OperationToGet.Id);

            //Assert
            Assert.IsNotNull(loadedOperation);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_UnitProcedure_By_Id(int position)
        {
            //Arrange
            var UnitProcedure = _basesRepository.GetAll<UnitProcedure>().ToList();
            Assert.IsNotNull(UnitProcedure);
            Assert.IsTrue(position < UnitProcedure.Count);
            UnitProcedure UnitProcedureToGet = UnitProcedure[position];

            //Execute
            UnitProcedure? loadedUnitProcedure = _basesRepository.GetById<UnitProcedure>(UnitProcedureToGet.Id);

            //Assert
            Assert.IsNotNull(loadedUnitProcedure);
        }

        [TestMethod]
        public void Cannot_Get_Phase_By_Invalid_Id()
        {
            Phases? loadedPhase = _basesRepository.GetById<Phases>(Guid.Empty);
            Assert.IsNull(loadedPhase);
        }

        [TestMethod]
        public void Cannot_Get_Operation_By_Invalid_Id()
        {
            Operations? loadedOperation = _basesRepository.GetById<Operations>(Guid.Empty);
            Assert.IsNull(loadedOperation);
        }

        [TestMethod]
        public void Cannot_Get_UnitProcedure_By_Invalid_Id()
        {
            UnitProcedure? loadedUnitProcedure = _basesRepository.GetById<UnitProcedure>(Guid.Empty);
            Assert.IsNull(loadedUnitProcedure);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_Phase(int position)
        {
            //Arrange
            var Phases = _basesRepository.GetAll<Phases>().ToList();
            Assert.IsNotNull(Phases);
            Assert.IsTrue(position < Phases.Count);
            Phases PhaseToUpdate = Phases[position];
            string Conection = new string("A");

            //Execute
            PhaseToUpdate.Name = Conection;
            _basesRepository.Update(PhaseToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            Phases? loadedPhase = _basesRepository.GetById<Phases>(PhaseToUpdate.Id);
            Assert.IsNotNull(loadedPhase);
            Assert.AreEqual(loadedPhase.Name, Conection);

        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Update_Operation(int position)
        {
            //Arrange
            var Operations = _basesRepository.GetAll<Operations>().ToList();
            Assert.IsNotNull(Operations);
            Assert.IsTrue(position < Operations.Count);
            Operations OperationToUpdate = Operations[position];
            string Conection = new string("A");

            //Execute
            OperationToUpdate.Name = Conection;
            _basesRepository.Update(OperationToUpdate);
            _unitOfWork.SaveChanges();

            //Assert
            Operations? loadedOperation = _basesRepository.GetById<Operations>(OperationToUpdate.Id);
            Assert.IsNotNull(loadedOperation);
            Assert.AreEqual(loadedOperation.Name, Conection);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Update_UnitProcedure(int position)
        {
            //Arrange
            var UnitProcedure = _basesRepository.GetAll<UnitProcedure>().ToList();
            Assert.IsNotNull(UnitProcedure);
            Assert.IsTrue(position < UnitProcedure.Count);
            UnitProcedure UnitProcedureToUpdate = UnitProcedure[position];
            string Conection = new string("A");

            //Execute
            UnitProcedureToUpdate.Name = Conection;
            _basesRepository.Update(UnitProcedureToUpdate);

            //Assert
            UnitProcedure? loadedUnitProcedure = _basesRepository.GetById<UnitProcedure>(UnitProcedureToUpdate.Id);
            Assert.IsNotNull(loadedUnitProcedure);
            Assert.AreEqual(loadedUnitProcedure.Name, Conection);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Delete_Phase(int position)
        {
            //Arrange
            var Phases = _basesRepository.GetAll<Phases>().ToList();
            Assert.IsNotNull(Phases);
            Assert.IsTrue(position < Phases.Count);
            Phases PhaseToDelete = Phases[position];

            //Execute
            _basesRepository.Delete(PhaseToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            Phases? loadedPhase = _basesRepository.GetById<Phases>(PhaseToDelete.Id);
            Assert.IsNull(loadedPhase);

        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Delete_Operation(int position)
        {
            //Arrange
            var Operations = _basesRepository.GetAll<Operations>().ToList();
            Assert.IsNotNull(Operations);
            Assert.IsTrue(position < Operations.Count);
            Operations OperationToDelete = Operations[position];

            //Execute
            _basesRepository.Delete(OperationToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            Operations? loadedOperations = _basesRepository.GetById<Operations>(OperationToDelete.Id);
            Assert.IsNull(loadedOperations);
        }

        [DataRow(0)]
        [TestMethod]

        public void Can_Delete_unitProcedure(int position)
        {
            //Arrange
            var UnitProcedure = _basesRepository.GetAll<UnitProcedure>().ToList();
            Assert.IsNotNull(UnitProcedure);
            Assert.IsTrue(position < UnitProcedure.Count);
            UnitProcedure UnitProcedureToDelete = UnitProcedure[position];

            //Execute
            _basesRepository.Delete(UnitProcedureToDelete);
            _unitOfWork.SaveChanges();

            //Assert
            UnitProcedure? loadedUnitProcedure = _basesRepository.GetById<UnitProcedure>(UnitProcedureToDelete.Id);
            Assert.IsNull(loadedUnitProcedure);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Phase_By_Operation(int position)
        {
            //Arrange
            Phases phase = new Phases("P1", "Phase1");
            Operations operation1 = new Operations("O1", "Operation1");
            Operations operation2 = new Operations("O2", "Operation2");

            operation1.Phases.Add(phase);
            operation2.Phases.Add(phase);

            //Execute
            _basesRepository.Add(phase);
            _basesRepository.Add(operation1);
            _basesRepository.Add(operation2);
            _unitOfWork.SaveChanges();

            Operations? loadedOperation = _basesRepository.GetById<Operations>(operation1.Id);
            Assert.IsNotNull(loadedOperation);
            Assert.IsTrue(position < loadedOperation.Phases.Count);
            Phases loadedPhase = loadedOperation.Phases.First();
            Assert.AreEqual(loadedPhase, phase);
        }
    }
}