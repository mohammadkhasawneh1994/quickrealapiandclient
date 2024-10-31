using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Edition;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;

namespace Robbochinni.Driver.Business.Operations
{
    public class CarManager : Manager
    {
        private readonly ICommand<AddCar> _carCommand;
        private readonly ICommand<AddUser> _userCommand;

        private readonly IQuery<CarByDriverId, CarInfo> _carByDriverQuery;
        private readonly IQuery<CarByLocation, CarInfo> _carByNearestQuery;
        private readonly IQuery<AllQuery, CarInfo> _allCarsQuery;

        public CarManager(ResultBuilder resultBuilder,
                          ICommand<AddCar> carCommand,
                          ICommand<AddUser> userCommand,
                          IQuery<CarByDriverId, CarInfo> carByDriverQuery,
                          IQuery<AllQuery, CarInfo> allCarsQuery,
                          IQuery<CarByLocation, CarInfo> carByNearestQuery) : base(resultBuilder)
        {
            _carCommand = carCommand;
            _userCommand = userCommand;
            _carByDriverQuery = carByDriverQuery;
            _allCarsQuery = allCarsQuery;
            _carByNearestQuery = carByNearestQuery;
        }

        public async Task<Result> Add(AddNewCar addCar)
        {
            try
            {
                _carByDriverQuery.SetInput(new CarByDriverId(addCar.DriverId));
                var isDriverOwnCar = await _carByDriverQuery.IsExist();
                if (isDriverOwnCar) throw new Exception("This User Already Own A Car");

                var Id = await _carCommand.Insert(new AddCar(addCar.DriverId, addCar.Brand, addCar.Class, addCar.Year, addCar.Color, addCar.Code, addCar.Number, Mag.Enums.RideType.Passenger, new Location(0.00M, 0.00M, "none")));
                var userId = await _userCommand.Update(new EditUserRole(Guid.Parse("8176DB54-AE70-4200-B686-574C5B9BE5EA")), addCar.DriverId);

                if (Id == Guid.Empty || userId == Guid.Empty) throw new Exception("Nothing Happened");

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(Id);
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }
            
        }

        public async Task<Result> GetAll()
        {
            try
            {
                var cars = await _allCarsQuery.GetMany();

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(cars);
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }

        }

        public async Task<Result> GetNearest(CarByLocation byLocation)
        {
            try
            {
                _carByNearestQuery.SetInput(byLocation);
                var cars = await _carByNearestQuery.GetMany();

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(cars);
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }

        }

        public async Task<Result> SetLocation(EditCarLocAndType updateCar, Guid? carId)
        {
            try
            {
                var Id = await _carCommand.Update(updateCar, carId);

                if (Id == Guid.Empty) throw new Exception("Nothing Happened");

                return _resultBuilder.Success!
                    .SetMessage("Entity Found")
                    .SetPayload(Id);
            }
            catch (Exception ex)
            {
                return _resultBuilder.Error!.SetException(ex);
            }

        }
    }
}
